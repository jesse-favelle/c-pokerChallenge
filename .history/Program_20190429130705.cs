using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/*
Assumptions:
- Aces are high.
- There can be more than one of the same card as it is asking to test for a kicker if there are more 
than one players with a three of a kind.
- Names and cards follow the correct format as given in examples.
 */

namespace Poker
{
    public class Program
    {
        public static void Main()
        {
            PokerGame myPokerGame = new PokerGame();
            Console.WriteLine("How many Players are playing?");
        var foo = Console.ReadLine();
        if (int.TryParse(foo, out int number1)) {

            
            
        }
        else
        {
            Console.WriteLine("You need to enter a valid number");
        }
        



            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2H, 4D, 10C, 10D, 10H"},
                new Player { Name="Bob", Hand="3C, 4D, 10H, 10S, 10D"},
                new Player { Name="Sally", Hand="2C, 4D, 5S, 10C, JH"}
            };

            myPokerGame.checkHand(players);
            myPokerGame.checkWinner(players);

        }
    }
}