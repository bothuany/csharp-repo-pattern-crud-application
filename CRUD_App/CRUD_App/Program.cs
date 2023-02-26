using CRUD_App.Entities;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var repository = new UserRepository(configuration);

        // GetAll
        Console.WriteLine("GetAll():");
        printAll(repository);
        Console.WriteLine("*************************************");
        // GetById
        var entityById = repository.GetById(1);
        Console.WriteLine("GetById(1):");
        Console.WriteLine(entityById);
        Console.WriteLine("*************************************");
        // Insert
        var newUser = new User { first_name = "Recep Batuhan", last_name = "Dikmen", email = "rbdikmen@gmail.com", gender = "Male" };
        repository.Insert(newUser);
        Console.WriteLine("Insert(newUser):");
        printAll(repository);
        Console.WriteLine("*************************************");
        // Update
        newUser.first_name = "Oscar";
        newUser.email = "oscar@gmail.com";
        repository.Update(newUser);

        Console.WriteLine("Update(newUser):");
        printAll(repository);
        Console.WriteLine("*************************************");
        // Delete
        repository.Delete(newUser.Id);

        Console.WriteLine("Delete(newUser):");
        printAll(repository);
    }
    static void printAll(UserRepository repository)
    {
        var entities = repository.GetAll();

        foreach (var entity in entities)
        {
            Console.WriteLine(entity);
        }

    }
}