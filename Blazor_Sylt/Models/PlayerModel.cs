using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Sylt.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }

        public int NumerOfStrokes { get; set; }
        public int NumerOfSylt { get; set; }
        public int NumerOfStrokesWithoutSylt { get; set; }
        public int NumerOfNothing { get; set; }
        public int NumerOfThreePair { get; set; }
        public int NumerOfStraight { get; set; }

        public int HigestStrok { get; set; }



        public int NumberOfTotalWin { get; set; }
        public int NumberOfTotalLosses { get; set; }


    }
}
