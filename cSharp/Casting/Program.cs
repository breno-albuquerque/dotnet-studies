using Casting.Entities;

//  Upcasting
void Upcasting()
{
    Person p = new Person();
    PhysicalPerson pp = new PhysicalPerson();
    
    Person p1 = (Person)pp;
    Person p2 = pp as Person;
}

// Downcasting
void Downcasting()
{
    Person p1 = new PhysicalPerson();
    
    if (p1 is PhysicalPerson physicalPerson)
    {
        PhysicalPerson p2 = physicalPerson;
        var cpf = p2.Cpf;
    }

    if (p1 is JuridicalPerson juridicalPerson)
    {
        JuridicalPerson p2 = juridicalPerson;
        var cnpj = p2.Cnpj;
    }
}

Upcasting();
Downcasting();