using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    // Метод для создания копии персоны с изменённым именем
    public Person WithName(string newName)
    {
        return new Person(newName, Age);
    }

    // Метод для создания копии персоны с изменённым возрастом
    public Person WithAge(int newAge)
    {
        return new Person(Name, newAge);
    }
}

struct PersonList
{
    private List<Person> persons;

    public PersonList(List<Person> initialPersons)
    {
        persons = new List<Person>(initialPersons);
    }

    public void AddPerson(Person person)
    {
        persons.Add(person);
    }

    public void PrintAll()
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }

    // Метод для создания копии списка персон с добавленной новой персоной
    public PersonList WithAddedPerson(Person newPerson)
    {
        List<Person> newPersons = new List<Person>(persons);
        newPersons.Add(newPerson);
        return new PersonList(newPersons);
    }

    // Метод для создания копии списка персон с удалённой персоной
    public PersonList WithoutPerson(Person personToRemove)
    {
        List<Person> newPersons = new List<Person>(persons);
        newPersons.Remove(personToRemove);
        return new PersonList(newPersons);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаём несколько персон
        Person person1 = new Person("Alice", 30);
        Person person2 = new Person("Bob", 25);

        // Добавляем их в список
        var list = new PersonList(new List<Person> { person1, person2 });

        // Выводим список
        Console.WriteLine("Initial list:");
        list.PrintAll();
        Console.WriteLine();

        // Создаём копию первой персоны с изменённым именем
        var person1Copy = person1.WithName("Charlie");
        Console.WriteLine("Person 1 copy with changed name:");
        Console.WriteLine(person1Copy);
        Console.WriteLine();

        // Создаём копию списка с добавленной новой персоной
        var newList = list.WithAddedPerson(new Person("David", 40));
        Console.WriteLine("List with added person:");
        newList.PrintAll();
        Console.WriteLine();

        // Создаём копию списка с удалённой второй персоной
        var listWithoutSecondPerson = list.WithoutPerson(person2);
        Console.WriteLine("List without second person:");
        listWithoutSecondPerson.PrintAll();
    }
}