using System;
using Turbaseratspel_prog2uppgift;

namespace turbaseratspel
{
    class Program
    {
        static void Main(string[] args) 
        {
            Game game = new Game(); //skapar spel
            game.run();             //kör spel
            Console.WriteLine("Du fick " + game.getEnemiesDefeated() + " poäng"); // hur många poäng

        }
    }
}