using laboop.BLL.GameAccounts;
using laboop.BLL.Games;
using laboop.DAL;
using laboop.UI;
using laboop.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new DbContext();
            var uis = new List<IUI>() 
            {
                new StartGame(context),
                new ShowPlayers(context),
                new ShowPlayerById(context),
                new ShowGames(context)
            };
            while (true)
            {
                for (int i = 0; i < uis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {uis[i].Show()}");
                }
                var actionIndex = Convert.ToInt32(Console.ReadLine());
                if (actionIndex > 0 && actionIndex <= uis.Count)
                {
                   uis[actionIndex - 1].Action();
                }
                else
                    Console.WriteLine($"Invalid value.");

            }
        }
    }
}

