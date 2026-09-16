using DeckRPGServer.Models;

namespace DeckRPGServer.Data
{
    public static class SeedData
    {
        public static readonly Card[] Cards =
        {
            new Card { Id = 1, Price = 300 },
            new Card { Id = 2, Price = 500 },
            new Card { Id = 3, Price = 700 },
        };

        public static readonly Weapon[] Weapons =
        {
            new Weapon { Id = 1, Price = 1000 },
            new Weapon { Id = 2, Price = 1500 },
            new Weapon { Id = 3, Price = 2000 },
        };
    }
}