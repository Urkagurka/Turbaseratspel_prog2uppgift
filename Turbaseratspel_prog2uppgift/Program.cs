using System;
using Turbaseratspel_prog2uppgift;

namespace turbaseratspel
{
    class Program
    {
        static void Main(string[] args) 
        {
            Game game = new Game();                                                     //skapar spel
            game.run();                                                                 //kör spel
            Console.WriteLine("Du fick " + game.getEnemiesDefeated() + " poäng");       //hur många poäng
            try                                                                         //felhantering. Om det blir något error hoppar den till catch
            {
                StreamWriter sw = new StreamWriter("points.txt", true);
                sw.WriteLine();
                sw.Write(game.getPlayerName() + "   " + game.getEnemiesDefeated());     //skriver ut namnet på spelaren och mängden poäng
                sw.Close();                                                             //släpper filen
            } 
            catch                                                                       //felhantering. Kör om det blir error på try
            {
                Console.WriteLine("Det gick inte att skriva upp dina poäng");
            }
        }
    }
}