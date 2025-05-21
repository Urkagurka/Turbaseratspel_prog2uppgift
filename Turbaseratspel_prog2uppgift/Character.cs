using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Turbaseratspel_prog2uppgift
{
    class Character                  //basklassen för spelartyperna
    {
        public string Name { get; }  //Namnet på karaktären
        private int hp;              //Hur mycket liv karaktären har kvar
        private int damage;          //Hur mycket skada en karaktär gör
        private int characterType;   //Vilken typ karaktären är

        public Character(string name, int hp, int damage, int characterType)    //konstruktor för character
        {
            this.Name = name;
            this.hp = hp;
            this.damage = damage;
            this.characterType = characterType;
            
        }
        public int HP                //getter för hp
        { 
            get { return hp; } 
        }
        
        public void die()            //döda karaktären direkt
        {
            hp = 0;
        }

        public void printYourSkills() //Skriver ut vilka actions som kan göras
        {   
            Console.WriteLine("1: Kasta kniv");
            Console.WriteLine("2: Sparka pung");
            Console.WriteLine("3: Fireball");
            Console.WriteLine("4: Heala");
        }

        public void doActionTo(int action, Character subject) //unför vald action mot subject / subject är karaktärens fiende så för enemy är det spelare
        {
            switch (action)                                   //de olika actions som kan göras
            {
                case 1:                                       //attack 1 vilket blir att kasta kniv
                    Console.WriteLine("Kastar kniv");         
                    if (characterType == 1)                   //Om characterType = 1 så är det en warrior och gör då mer skada än en wizard med att kasta kniv
                    {
                        if(new Random().Next(1,11) > 6)       //Om attacken träffar eller inte
                        {
                            Console.WriteLine("Kniven träffar och gör " + (damage + 20) + " skada");
                            subject.hp -= (damage + 20);      //Gör skada
                            
                        }
                        else
                        {
                            Console.WriteLine("Kniven missar");
                            
                        }
                    }
                    else if (characterType == 2)              //kastasr kniv som wizard
                    {
                        if(new Random().Next(1,11) > 9)       //slumpar om man missar eller träffar
                        {
                            Console.WriteLine("Kniven träffar och gör " + (damage - 5) + " skada");
                            subject.hp -= (damage - 5);
                            
                        }
                        else
                        {
                            Console.WriteLine("Kniven missar");
                            
                        }
                    }
                    Console.WriteLine();
                    break;
                case 2:                                       //pung spark attack
                    Console.WriteLine("Sparkar pung");
                    if (characterType == 1)
                    {
                        if (new Random().Next(1, 11) > 3)     //slumpar om träff eller miss
                        {
                            Console.WriteLine("Sparken träffar och gör " + (damage + 10) + " skada");
                            subject.hp -= (damage + 10);      //gör skada på subject
                            
                        }
                        else
                        {
                            Console.WriteLine("Sparken missar");
                            
                        }
                    }
                    else if (characterType == 2)
                    {
                        Console.WriteLine("Wizard är för svag och gör ingen skada.");
                        Console.WriteLine("Det gör 0 skada");
                    }
                    Console.WriteLine();
                    break;
                case 3:                                       //kasta eldklot attack
                    Console.WriteLine("Kastar eldklot");
                    if (characterType == 1)                             
                    {
                        if (new Random().Next(1, 11) > 8)
                        {
                            Console.WriteLine("Ett svagt eldklot kastas och gör " + (5) + " skada");
                            subject.hp -= (5);

                        }
                        else
                        {
                            Console.WriteLine("Eldklotet missar");

                        }
                    }
                    else if (characterType == 2)
                    {
                        int fireBall = new Random().Next(1, 11);
                        if (fireBall > 9)                       //Slumpar om ännu starkare eldklot
                        {
                            Console.WriteLine("Ett enoromt eldklot kastas och gör " + (damage + 25) + " skada");
                            subject.hp -= (damage + 25);

                        }
                        else if (fireBall > 4)                  //normalstort eldklot
                        {
                            Console.WriteLine("Eldklotet träffar och gör " + (damage + 10) + " skada");
                            subject.hp -= (damage + 10);

                        }
                        else
                        {
                            Console.WriteLine("Eldklotet missar");

                        }
                    }
                    Console.WriteLine();
                    break;
                case 4:                                       
                    Console.WriteLine("Healar...");
                    int heal = new Random().Next(20,50);        //slumpar om healing
                    if (characterType == 1)
                    {
                        if (new Random().Next(1, 11) > 6)
                        {
                            Console.WriteLine("Healar " + (heal -20) + " hp");
                            this.hp += (heal - 20);             //healar den som använder acitonen
                            
                        }
                        else
                        {
                            Console.WriteLine("Healingen misslyckas");
                            
                        }
                    }
                    else if (characterType == 2)
                    {
                         Console.WriteLine("Healar " + (heal + 30) + " hp");
                         this.hp += (heal + 30);
                         
                    }
                    Console.WriteLine();
                    break;
                default:                                        //om man försöker göra en action som inte finns
                    Console.WriteLine("Förstår inte...gör ingenting");
                    Console.WriteLine();
                    break;
            }

        }

        public void makeRandomMoveTo(Character subject)                     //Fienden gör ett random move
        {
            int randomMove = 1 + new Random().Next(4);                      //random move melllan 1-4 move
            doActionTo(randomMove, subject);                                //anropar doActionTo
        }

        public bool isAlive()                                               //kollar om folk lever
        {
            return hp > 0;
        }
    }
}
