using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using SqlDataAccess.Context;
using SqlDataAccess.Models;

//  Acesso pelo DataSqlClient
void DataSqlClientMethod1()
{
    var conn1 = DataContext.GetConnection();

    conn1.Open();

    var command = new SqlCommand();

    command.Connection = conn1;
    command.CommandType = System.Data.CommandType.Text;
    command.CommandText = "SELECT * FROM [ROLE]";

    var reader = command.ExecuteReader();
    reader.Read();

    Console.WriteLine(reader.GetString(1));

    command.Dispose();
    conn1.Close();
    conn1.Dispose();
}
void DataSqlClientMethod2()
{
    using (var conn2 = DataContext.GetConnection())
    {
        using (var command = new SqlCommand())
        {
            command.Connection = conn2;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM [ROLE]";

            conn2.Open();

            var reader = command.ExecuteReader();
            reader.Read();

            Console.WriteLine(reader.GetString(1));
        }
    }
}

//  Acesso pelo Dapper
void Query(SqlConnection connection)
{
    //  Usa alias para mapear sql
    Console.WriteLine("Buscando role pelo mapeamento via alias do sql: \n");

    var roles = connection.Query<Role>(
        "SELECT [ID] as Id, [ROLE_NAME] as RoleName, [DATE_INSERTION] as DateInsertion, [DATE_ALTERATION] as DateAlteration FROM [ROLE]"
        );

    foreach (var role in roles)
    {
        Console.WriteLine(
            $"Id: {role.Id}, RoleName: {role.RoleName}, DateInsertion: {role.DateInsertion}, DateAlteration: {role.DateAlteration}"
            );
    }
}
void ExecuteInsert(SqlConnection connection)
{
    //  Usa parâmetros para prevenir sql injection
    Console.WriteLine("Realizando execute com insert e parâmetros \n");

    var result = connection.Execute(
        "INSERT INTO [ROLE] (ROLE_NAME, DATE_INSERTION, DATE_ALTERATION) VALUES (@RoleName, @DateInsertion, @DateAlteration)",
        new { RoleName = "UNKNOWN", DateInsertion = DateTime.Now, DateAlteration = DateTime.Now }
        );

    Console.WriteLine("Insert realizado");
}
void ExecuteUpdate(SqlConnection connection)
{
    Console.WriteLine("Realizando execute com update e parâmetros \n");

    var result = connection.Execute(
        "UPDATE [ROLE] SET [ROLE_NAME] = @NewRoleName WHERE [ROLE_NAME] = @OldRoleName",
        new { NewRoleName = "ADMINISTRATOR", OldRoleName = "ADMIN" }
        );

    Console.WriteLine("Update realizado");
}
void ExecuteInsertMany(SqlConnection connection)
{
    Console.WriteLine("Realizando execute com insert e array de parâmetros \n");

    var result = connection.Execute(
        "INSERT INTO [ROLE] (ROLE_NAME, DATE_INSERTION, DATE_ALTERATION) VALUES (@RoleName, @DateInsertion, @DateAlteration)",
        new[] {
                new { RoleName = "INSERT_ONE", DateInsertion = DateTime.Now, DateAlteration = DateTime.Now },
                new { RoleName = "INSERT_TWO", DateInsertion = DateTime.Now, DateAlteration = DateTime.Now }
        }
    );

    Console.WriteLine("Insert many realizado");
}
void ExecuteScalar(SqlConnection connection)
{
    //  Também da para montar a query usando OUTPUT inserted.[ID]
    Console.WriteLine("Usando Execute Scalar tipando retorno como int e selecionando o identity através do SCOPE_IDENTITY");

    var result = connection.ExecuteScalar<int>(
        "INSERT INTO [ROLE] (ROLE_NAME, DATE_INSERTION, DATE_ALTERATION) VALUES (@RoleName, @DateInsertion, @DateAlteration) SELECT SCOPE_IDENTITY()",
        new { RoleName = "SCALAR4", DateInsertion = DateTime.Now, DateAlteration = DateTime.Now }
        );

    Console.WriteLine($"Id retornado: {result}");
}
void OneToOne(SqlConnection connection)
{
    Console.WriteLine("Realizando query com mapeamento One to One \n");

    var sql = @"
            SELECT u.[ID] as Id, [USER_ROLE] as ROLE, [DOCUMENT] as Document, [EMAIL] as Email, [PASSWORD] as Password, u.[DATE_INSERTION] as DateInsertion, u.[DATE_ALTERATION] as DateAlteration, r.[ID] as Id, r.[ROLE_NAME] as RoleName
            FROM [USER] as u
            INNER JOIN [ROLE] as r
            ON u.[USER_ROLE] = r.[ID]
        ";

    var result = connection.Query<User, Role, User>(
        sql,
        (user, role) =>
        {
            user.UserRole = role;
            return user;
        }, splitOn: "Id");

    foreach (var item in result)
        Console.WriteLine("USER + ROLE: " + item.Email + " " + item.UserRole.RoleName);
}
void OneToMany(SqlConnection connection)
{
    var sql = @"
            SELECT
                [ROLE].[ID] as Id,
                [ROLE].[ROLE_NAME] as RoleName,
                [USER].[ID] as Id,
                [USER].[EMAIL] as Email
            FROM
                [ROLE]
            INNER JOIN
                [USER] ON [USER].[USER_ROLE] = [ROLE].[ID]
        ";

    var roles = new List<Role>();

    var result = connection.Query<Role, User, Role>(
        sql,
        (role, user) =>
        {
            var rol = roles.Where(x => x.Id == role.Id).FirstOrDefault();
            if (rol == null)
            {
                rol = role;
                role.Users.Add(user);
                roles.Add(role);
            }
            else
            {
                rol.Users.Add(user);
            }
            return rol;
        }, splitOn: "Id");

    foreach (var role in roles)
    {
        Console.WriteLine($"Role - {role.RoleName}, Users:");
        foreach (var user in role.Users)
        {
            Console.WriteLine(user.Id + " - " + user.Email);
        }
    }
}
void CreateUser(SqlConnection connection)
{
    var sql = "INSERT INTO [USER] ([USER_ROLE], [DOCUMENT], [EMAIL], [PASSWORD], [DATE_INSERTION], [DATE_ALTERATION])" +
    "VALUES (@userrole, @document, @email, @password, @dateinsertion, @datealteration)";

    var result = connection.Execute(sql, new { userrole = 1, document = "12312312397", email = "email9@email.com", password = "123", dateinsertion = DateTime.Now, datealteration = DateTime.Now });
}
void Transaction(SqlConnection connection)
{
    var role = new Role()
    {
        RoleName = "Transaction",
        DateInsertion = DateTime.Now,
        DateAlteration = DateTime.Now,
    };

    var sql = @"INSERT INTO [ROLE] (ROLE_NAME, DATE_INSERTION, DATE_ALTERATION) VALUES (@RoleName, @DateInsertion, @DateAlteration)";

    connection.Open();

    using (var transaction = connection.BeginTransaction())
    {
        var rows = connection.Execute(sql, role, transaction);

        //transaction.Rollback();
        transaction.Commit();

        Console.WriteLine("Linhas afetadas: " + rows);
    }
}

//  Outros acessos com Dapper
IEnumerable<T> QueryWithGenerics<T>(string query)
{
    using (var connection = DataContext.GetConnection())
        return connection.Query<T>(query);
}


using (var connection = DataContext.GetConnection())
{
    //CreateUser(connection);
    Transaction(connection);
}