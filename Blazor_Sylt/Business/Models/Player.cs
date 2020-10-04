using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Sylt.Business.Models
{
    public class Player
    {

        public Player(string name)
        {
            Name = name;
            TotalPoint = 0;
            NumberOfSylt = 0;
        }

        public string Name { get; set; }
        public double TotalPoint { get; set; }
       
        public int NumberOfSylt { get; set; }

        public bool IsSylt { get; set; }
        public List<Dice> Dices { get; set; } = new List<Dice>();

    }
}
