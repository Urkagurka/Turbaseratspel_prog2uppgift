using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbaseratspel_prog2uppgift
{
    class Wizard : Character                //Wizard ärver från character
    {
        public Wizard() : base("Evil Wizard", new Random().Next(75, 150), new Random().Next(5, 69), 2)  //konstruktor för Wizard
        {
        }
    }
}
