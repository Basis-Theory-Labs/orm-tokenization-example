using EntityFrameworkCore.DataTokenization;
using Microsoft.EntityFrameworkCore;
using ORMTokenizationExample;

var options = new DbContextOptionsBuilder<DatabaseContext>()
    .UseInMemoryDatabase("InMemoryDatabase")
    .Options;

var apiKey = Environment.GetEnvironmentVariable("BT_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    Console.WriteLine("Missing BT_API_KEY environment variable.");
    Environment.Exit(-1);
}
var tokenizationProvider = new TokenizationProvider(apiKey);

using var context = new DatabaseContext(options, tokenizationProvider);

var user = new User
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john@doe.com",
    Age = 22
};

context.Users.Add(user);
context.SaveChanges();

Console.WriteLine($"Users count: {context.Users.Count()}");

user = context.Users.First();

Console.WriteLine($"User: {user.FirstName} {user.LastName} - {user.Email} - {user.Age}");

user.Email = "jane@doe.com";
context.SaveChanges();

context.ChangeTracker.Clear();
user = context.Users.First();

Console.WriteLine($"User: {user.FirstName} {user.LastName} - {user.Email} - {user.Age}");
