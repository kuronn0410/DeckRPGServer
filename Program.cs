using DeckRPGServer.Data;
using DeckRPGServer.Models;
using DeckRPGServer.Requests;
using DeckRPGServer.Responses;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// ‚±‚±‚ÅSQLite‚ð“o˜^‚·‚é
builder.Services.AddDbContext<DeckRPGDbContext>(options =>
    options.UseSqlite("Data Source=deckrpg.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DeckRPGDbContext>();

    /*----Players-----*/
    var player = context.Players.Find(1);

    if (player == null)
    {
        context.Players.Add(new Player
        {
            Id = 1,
            Money = 1000,
        });
    }

    /*----Cards-----*/
    foreach (var card in SeedData.Cards)
    {
        var existingCard = context.Cards.Find(card.Id);

        if (existingCard == null)
        {
            context.Cards.Add(card);
        }
        else
        {
            existingCard.Price = card.Price;
        }
    }

    /*----Weapons-----*/
    foreach (var weapon in SeedData.Weapons)
    {
        var existingWeapon = context.Weapons.Find(weapon.Id);
        if (existingWeapon == null)
        {
            context.Weapons.Add(weapon);
        }
        else
        {
            existingWeapon.Price = weapon.Price;
        }
    }
    context.SaveChanges();
}

app.MapGet("/player/1", (DeckRPGDbContext context) =>
    {
        var player = context.Players.Find(1);
        if (player == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(player);
    }
);

app.MapPost("/shop/cards/buy",(BuyCardRequest request, DeckRPGDbContext context) =>
    {

        var card = context.Cards.Find(request.CardId);

        if (card == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(new PriceResponse
            {
                Price = card.Price

            }
        );

    }

);



app.MapGet("/", () => "Hello World!");

app.Run();
