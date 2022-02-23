using EFIntro;

var db = new AddressBookContext();

    WriteToDb(db);
    ReadFromDb(db);


void ReadFromDb(AddressBookContext db)
{
    var persons = db.Persons
        .Where(p => p.FirstName.StartsWith("C")).ToList();

    foreach (var person in persons)
    {
        //Console.WriteLine($"{person.FirstName} {person.LastName}");
        Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
    }
}

void WriteToDb(AddressBookContext db)
{
    db.Persons.Add(new Person() { FirstName = "Claes", LastName = "Engelin" });

    db.Persons.AddRange(new[]
    {
        new Person() { FirstName = "Tom", LastName="Sawyer"},
        new Person() { FirstName = "Huckleberry", LastName="Finn"},
        new Person() { FirstName= "Charlie", LastName="Brown"}
    });

    db.SaveChanges();
}