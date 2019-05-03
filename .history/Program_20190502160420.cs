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
        
            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="10H, JH, QH, KH, AH"},
                new Player { Name="Bob", Hand="3C, 4C, 5C, 6C, 7C"},
                new Player { Name="Sally", Hand="2C, 4D, 5S, 10C, JH"}
            };

            myPokerGame.checkHand(players);
            myPokerGame.checkWinner(players);

        }
    }
}