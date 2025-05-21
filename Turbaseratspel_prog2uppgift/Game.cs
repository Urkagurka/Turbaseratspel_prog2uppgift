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
        private string playerName;
        private int enemiesDefeated = 0;
        
        public Game() { 
            
        }

        public int getEnemiesDefeated ()                                    //gör att jag kan komma åt mängden enemies defeated
        {
            return enemiesDefeated;
        }
        public string getPlayerName ()                                      //gör att jag kan komma åt player name
        {
            return playerName;
        }
        public void run() {                                                 //kör spelet
            Console.WriteLine("Vill du spela?");
            Console.WriteLine("1. Starta spel");
            Console.WriteLine("2. Avsluta spel");
            int val = int.Parse(Console.ReadLine());                        //väljer om du vill spela eller inte
            if (val == 2)                                                   //om du valde 2 vilket är att avsluta avslutar den spelet
            {                                                               //den skickar 0 poäng om man väljer att avsluta
                return;
            }
            Console.WriteLine("Vad är ditt namn");
            playerName = Console.ReadLine();                                //du väljer ditt namn vilket är det som står vid dina poäng
            Console.WriteLine("Vad är du för något?");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Wizard");
            int playerCharacterType = int.Parse(Console.ReadLine());        //du väljer vilken charactertype du har vilket blir till vilken klass du är
            
            if(playerCharacterType == 1)                                    //här skapar den en warrior om man väljer 1
            {
                player1 = new Warrior();
            }
            else if(playerCharacterType == 2)                               //här skapar den en wizard om man väljer 2
            {
                player1 = new Wizard();
            }
            else
            {
                Console.WriteLine("nah");
                return;
            }

            Console.WriteLine("Välkommen " + playerName);                   //här välkomnar den dig

            while (player1.isAlive())                                       //kör medans spelaren lever
            {

                if (new Random().Next(1,3) == 1)                            //slumpar vilken fiende som skapas
                {
                    enemy1 = new Warrior();
                }
                else
                {
                    enemy1 = new Wizard();
                }

                Console.WriteLine("Nu möter du " + enemy1.Name);            //berättar vem du möter


                while (player1.isAlive() && enemy1.isAlive())               //körs medans spelare och fiende är vid liv
                {
                    Console.WriteLine(player1.Name + " har " + player1.HP + " hp kvar");    //berättar hur mycket hp du har kvar
                    Console.WriteLine(enemy1.Name + " har " + enemy1.HP + " hp kvar");      //berättar hur mycket hp fiende har kvar
                    Console.WriteLine();
                    Console.WriteLine("Vad gör du?");
                    player1.printYourSkills();                              //skriver de olika attackerna
                    try                                                     //Felhantering
                    {
                        int action = int.Parse(Console.ReadLine());         //vilken action du gör
                        Console.Clear();                                    //clearar allt tidigare i konsollen
                        player1.doActionTo(action, enemy1);                 //gör actionen
                    }
                    catch                                                   //Om det blir ett error i try    
                    {
                        Console.WriteLine("Din attack misslyckades så otroligt att du förlorade striden direkt");
                        player1.die();                                      //dödar spelaren
                        return;
                    }

                    Console.WriteLine(enemy1.Name + " gör sitt drag");
                    enemy1.makeRandomMoveTo(player1);                       //fienden slumpar sin attack


                }
                if (player1.isAlive())                                      //om spelaren är vid liv har den besegrat fienden.
                {
                    enemiesDefeated += 1;                                   //ge spelaren poäng
                }
            }
        }
    }
}
