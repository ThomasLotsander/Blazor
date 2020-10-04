using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Blazor_Sylt.Business.Models;

namespace Blazor_Sylt.Service.SyltServices
{
    public class DiceLogic
    {
        public bool CheckIfStraight(List<Dice> dices)
        {
            return dices.GroupBy(d => d.Value).Count() == 6;
        }

        public bool CheckIfThreePair(List<Dice> dices)
        {
            var groupedDices = dices.GroupBy(d => d.Value);
            return groupedDices.Count() == 3;
        }

        public bool CheckIfNothing(List<Dice> dices)
        {
            var hasValueDices = dices.Any(d => d.Value == 1 || d.Value == 5);
            if (hasValueDices)
            {
                return false;
            }

            if (dices.Count() >= 6 && CheckIfThreePair(dices))
            {
                return false;
            }

            var groupedDices = dices.GroupBy(d => d.Value).ToList();
            var result = groupedDices.OrderByDescending(c => c.Key).ToList();

            if (result[0].Count() >= 3)
            {
                return false;
            }
            
            return true;
        }

        public bool CheckIfSylt(List<Dice> dices)
        {
            return CheckIfNothing(dices);
        }
    }
}
