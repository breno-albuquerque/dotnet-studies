using System.Collections;

// Demo 1 - Manualmente iterar sobre uma lista.
var list = new List<string>();

list.Add("Item_1");
list.Add("Item_2");
list.Add("Item_3");

var enumarator = list.GetEnumerator();

    // Inicia na posição -1, então movemos para a 0.
enumarator.MoveNext();
var item1 = enumarator.Current;
enumarator.MoveNext();
var item2 = enumarator.Current;
enumarator.MoveNext();
var item3 = enumarator.Current;

Console.WriteLine($"Manualmente iterando sobre lista: {item1}, {item2}, {item3}");

// Demo 2 - Criando uma coleção iterável com foreach
var listOfStendents = new ListOfStudent(new[] { new Student("Name_1"), new Student("Name_2"), new Student("Name_3") });

foreach (Student student in listOfStendents)
{
    Console.WriteLine($"Iterando com foreach: {student.Name}");
}

public class Student
{
    public string Name { get; set; }
    
    public Student(string name)
    {
        Name = name;
    }
}

    // Não é necessário implementar IEnumerable e IEnumerator para funcionar com foreach,
    // É necessário ter o método GetEnumerator() e a propriedade Current,
    // Porém, o padrão do .NET é implementar essas interfaces que já expões esse método e propriedade
public class ListOfStudent : IEnumerator, IEnumerable
{
    private readonly Student[] _students;

    private int _position = -1;
    
    public ListOfStudent(Student[] students)
    {
        _students = students;
    }
    
    public bool MoveNext()
    {
        _position++;
        return (_position < _students.Length);
    }

    public void Reset()
    {
        _position = 0;
    }

    public object Current => _students[_position];
    
    // O Enumerator pode ser uma classe separada,
    // Nesse caso para exemplificar implementa nessa mesma classe
    public IEnumerator GetEnumerator()
    {
        return this;
    }
}