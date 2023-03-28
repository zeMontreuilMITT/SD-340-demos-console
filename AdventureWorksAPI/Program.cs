using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// SERVICES
builder.Services.AddDbContext<AdventureWorksLt2019Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb"));
});

var app = builder.Build();

// CUSTOMER/PERSON
app.MapGet("/person/details", (string? firstName, string? lastName, AdventureWorksLt2019Context db) =>
{

	if(String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(lastName))
	{
		return Results.BadRequest();
	} else
	{
        Customer person;

        if (String.IsNullOrEmpty(firstName))
        {
            person = db.Customers.First(c => c.LastName.StartsWith(lastName));
        }
        else if (String.IsNullOrEmpty(lastName))
        {
            person = db.Customers.First(c => c.FirstName.StartsWith(firstName));
        }
        else
        {
            person = db.Customers.First(c => c.FirstName.StartsWith(firstName) && c.LastName.StartsWith(lastName));
        }

        return Results.Ok(new
        {
            TestKey = "Test Value",
            CustomerValues = person
        }) ;
    }

});


// PRODUCT
// each map has delegate "Handler" defined
app.MapGet("/product", ProductsMethods.GetProduct);

// ADDRESS
// HTTP GET
app.MapGet("/address", (AdventureWorksLt2019Context db) =>
{
    return Results.Ok(new
    {
        TestValue = "Testing Testing",
        Addressess = db.Addresses.ToList()
    });
});

app.MapGet("/address/details", (int id, AdventureWorksLt2019Context db) =>
{
    Address address = db.Addresses.Find(id);

    return Results.Ok();
});

// HTTP POST
app.MapPost("/address", (AdventureWorksLt2019Context db, Address address) =>
{
    db.Add(address);
    db.SaveChanges();

    return Results.Created($"/address/details?id={address.AddressId}", address);
});

app.MapPut("/address/{id}", (int id, AdventureWorksLt2019Context db, Address address) =>
{
    // search for address
    Address editingAddress = db.Addresses.Find(id);

    if (editingAddress == null)
    {
        // add new address
    } else
    {
        // edit existing address found;
    }
});

app.Run();