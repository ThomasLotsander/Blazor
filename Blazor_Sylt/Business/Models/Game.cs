using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_Sylt.Business.Helper;
using Blazor_Sylt.Service.SyltServices;

namespace Blazor_Sylt.Business.Models
{
    public class Game
    {
        DiceLogic _diceLogic = new DiceLogic();
        public List<Player> Players { get; set; } = new List<Player>();

        public List<Dice> RollDices(List<Dice> dices = null)
        {
            Random rnd = new Random();
            if (dices == null || dices.Count <= 0)
            {
                dices = new List<Dice>();
                for (int i = 0; i < 6; i++)
                {
                    dices.Add(new Dice() { Locked = false, Value = rnd.Next(1, 7) });
                }

            }
            else
            {
                foreach (var dice in dices.Where(x => x.Locked != true))
                {
                    dice.Value = rnd.Next(1, 7);
                }
            }
            

            
            if(dices.All(x => x.Locked == true))
            {
                // Alla tärningar är slagna och spelaren får ett nytt slag. 
                return RollDices();

            }
            return dices;
        }

        public Player CurrentPlayer { get; set; }

        public void ScorePoints(Player player)
        {
            foreach (var playerDice in player.Dices)
            {
                //player.TotalPoint += playerDice.GetSingleScore();
            }
        }
    }
}
