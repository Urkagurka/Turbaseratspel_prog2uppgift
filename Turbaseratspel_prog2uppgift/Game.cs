using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbaseratspel_prog2uppgift
{
    internal class Game
    {
        private Character player1;
        private Character enemy1;
        public int playerCharacterType;
        string playerName;
        private int enemiesDefeated = 0;
        
        public Game() { 
            
        }

        public int getEnemiesDefeated ()
        {
            return enemiesDefeated;
        }
        public void run() {
            Console.WriteLine("Vill du spela?");
            Console.WriteLine("1. Starta spel");
            Console.WriteLine("2. Avsluta spel");
            int val = int.Parse(Console.ReadLine());
            if (val == 2) 
            {
                return;
            }
            Console.WriteLine("Vad är ditt namn");
            playerName = Console.ReadLine();
            Console.WriteLine("Vad är du för något?");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Wizard");
            int playerCharacterType = int.Parse(Console.ReadLine());
            
            if(playerCharacterType == 1) 
            {
                player1 = new Warrior();
            }
            else if(playerCharacterType == 2) 
            {
                player1 = new Wizard();
            }
            else
            {
                Console.WriteLine("dwa");
            }

            Console.WriteLine("Välkommen " + player1.Name);

            while (player1.isAlive())
            {

                if (new Random().Next(1,2) == 1)
                {
                    enemy1 = new Warrior();
                }
                else
                {
                    enemy1 = new Wizard();
                }

                Console.WriteLine("Nu möter du " + enemy1.Name);


                while (player1.isAlive() && enemy1.isAlive())
                {
                    Console.WriteLine(player1.Name + " har " + player1.HP + " hp kvar");
                    Console.WriteLine(enemy1.Name + " har " + enemy1.HP + " hp kvar");
                    Console.WriteLine();
                    Console.WriteLine("Vad gör du?");
                    player1.printYourSkills();
                    try
                    {
                        int action = int.Parse(Console.ReadLine());
                        Console.Clear();
                        player1.doActionTo(action, enemy1);
                    }
                    catch
                    {
                        Console.WriteLine("Din attack misslyckades så otroligt att du förlorade striden direkt");
                        player1.die();
                    }

                    // kolla om båda lever

                    Console.WriteLine(enemy1.Name + " gör sitt drag");
                    enemy1.makeRandomMoveTo(player1);


                }
                if (player1.isAlive())
                {
                    enemiesDefeated += 1;
                }
            }
        }

        //private bool isGameOver()
        //{
        //    return !player1.isAlive() || !enemy1.isAlive();
            //runda över istället möjligen gå tillbaka till början eller liknande.
            //ge poäng till spelaren om fienden är död och spara i en fil
        //}
    }
}
