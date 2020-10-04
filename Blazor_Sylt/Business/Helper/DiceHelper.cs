using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_Sylt.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor_Sylt.Business.Helper
{
    public class DiceHelper
    {
        public double GetSingleScore(Dice die)
        {
            if (die.Value.Equals(1))
                return 1;
            if (die.Value.Equals(5))
                return 0.5;

            return 0;
        }

        public double GetTotalScore(List<Dice> diceList)
        {
            double totalResult = 0;
            for (int i = 1; i < 7; i++)
            {
                var result = diceList.FindAll(x => x.Value == i);

                int res = result.Count;
                if (res == 0)
                {
                    continue;
                }

                var value = result.FirstOrDefault().Value;
                if (value == 1)
                {
                    // Triss i 3:or = 10
                    value = 10;
                }

                if (res <= 2 && result.Any(x => x.Value == 1 || x.Value == 5))
                {
                    foreach (var die in result)
                    {
                        if (die.Value.Equals(1))
                            totalResult += 1;
                        if (die.Value.Equals(5))
                            totalResult += 0.5;
                    }

                }

                if (res == 3)
                {
                    totalResult += value;
                    continue;
                }
                if (res == 4)
                {
                    totalResult += value * 2;
                    continue;
                }
                if (res == 5)
                {
                    totalResult += value * 2 * 2;
                    continue;
                }
                if (res == 6)
                {
                    totalResult += value * 2 * 2 * 2;
                }


            }

            return totalResult;
        }
    }
}
