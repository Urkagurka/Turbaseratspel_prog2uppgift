using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbaseratspel_prog2uppgift
{
    class Warrior : Character                   //warrior ärver från character
    {

        public Warrior() : base("wariorrr", new Random().Next(200,250), new Random().Next(5, 35), 1)    //Konstruktor för warrior
        {
        }
    }
}
