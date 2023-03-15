using ExampleClassLibrary;
using System.Text.Json;

User user = new User("Bob", 23, new Address() { City = "Moscow", Street = "Tverskaya"});

JsonSerializerOptions options = new JsonSerializerOptions()
{
    AllowTrailingCommas = true,
    WriteIndented = true,

};

using (FileStream stream = new FileStream("user.json", FileMode.Create))
{
    JsonSerializer.Serialize(stream, user, options);
}



using(FileStream stream = new FileStream("user.json", FileMode.OpenOrCreate))
{
    User user2 = JsonSerializer.Deserialize<User>(stream, options)!;
    Console.WriteLine($"Name: {user2.Name}, Age: {user2.Age}");
}

