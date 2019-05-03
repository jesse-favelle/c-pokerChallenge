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
                 new Player { Name="Joe", Hand="10D, JD, QD, KD, AD"},
                new Player { Name="Bob", Hand="5C, 6C, 7C, 8C, 9C"}
            };

            myPokerGame.checkHand(players);
            myPokerGame.checkWinner(players);

        }
    }
}