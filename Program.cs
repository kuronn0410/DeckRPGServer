using DeckRPGServer.Data;
using DeckRPGServer.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// ‚±‚±‚ÅSQLite‚ð“o˜^‚·‚é
builder.Services.AddDbContext<DeckRPGDbContext>(options =>
    options.UseSqlite("Data Source=deckrpg.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DeckRPGDbContext>();
    int playerCount = context.Players.Count();
    if (playerCount == 0)
    {
        Player player = new Player
        {
            Id = 1,
            Money = 1000,
        };
        context.Players.Add(player);
        context.SaveChanges();
    }
}


app.MapGet("/player/1", (DeckRPGDbContext context) =>
    {
        var player = context.Players.Find(1);
        if (player != null)
        {
            return player.Money;
        }
        return 0;
    }
);

app.MapGet("/", () => "Hello World!");

app.Run();
