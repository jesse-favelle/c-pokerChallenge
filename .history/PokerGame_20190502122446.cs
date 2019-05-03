using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class PokerGame
{


    public void checkWinner(List<Player> players)
    {
        Player player = sortWinners(players);

        Console.WriteLine(player.Name + " wins!");

    }

    public Player sortWinners(List<Player> players)
    {
        return players.OrderByDescending(x => x.HandRank).ThenByDescending(x => x.Total)
         .ThenByDescending(x => x.HighCard1).ThenByDescending(x => x.HighCard2).ThenByDescending(x => x.HighCard3)
         .ThenByDescending(x => x.HighCard4).ThenByDescending(x => x.HighCard5).First();
    }

    public List<Player> checkHand(List<Player> players)
    {
        List<Card> playerHand = new List<Card>();

        foreach (Player Player in players)
        {
            playerHand = convertToCards(Player.Hand);

            if (IsFlush(playerHand, Player)) continue;
            if (IsThreeOfAKind(playerHand, Player)) continue;
            if (IsPair(playerHand, Player)) continue;

            //Check for High Card winner
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).First().Value;
            Player.HighCard2 = playerHand.OrderByDescending(x => x.Value).ElementAt(1).Value;
            Player.HighCard3 = playerHand.OrderByDescending(x => x.Value).ElementAt(2).Value;
            Player.HighCard4 = playerHand.OrderByDescending(x => x.Value).ElementAt(3).Value;
            Player.HighCard5 = playerHand.OrderByDescending(x => x.Value).ElementAt(4).Value;
        }

        return players;
    }

    private bool IsFlush(List<Card> playerHand, Player Player)
    {
        //group hand to check all same suit
        var query = from card in playerHand
                    group card by card.Suit into cards
                    where cards.Count() == 5
                    select new { Value = cards.Key, Count = cards.Count() };

        if (query.Count() == 1)
        {
            Player.HandRank = 3;
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).First().Value;
            Player.HighCard2 = playerHand.OrderByDescending(x => x.Value).ElementAt(1).Value;
            Player.HighCard3 = playerHand.OrderByDescending(x => x.Value).ElementAt(2).Value;
            Player.HighCard4 = playerHand.OrderByDescending(x => x.Value).ElementAt(3).Value;
            Player.HighCard5 = playerHand.OrderByDescending(x => x.Value).ElementAt(4).Value;
            return true;
        }

        return false;
    }

    private bool IsFourOfAKind(List<Card> playerHand, Player Player)
    {
        //group hand by value and check if 4 of the same count
        var query = from card in playerHand
                    group card by card.Value into cards
                    where cards.Count() == 4
                    select new { Value = cards.Key, Count = cards.Count() };

        if (query.Count() == 1)
        {
            Player.HandRank = 7;
            Player.Total = query.First().Value * 4;
            //Store high cards that aren't part of the 3 of a kind
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 4 != Player.Total).First().Value;
            return true;
        }

        return false;

    }

    private bool IsThreeOfAKind(List<Card> playerHand, Player Player)
    {
        //group hand by value and check if 3 of the same count
        var query = from card in playerHand
                    group card by card.Value into cards
                    where cards.Count() == 3
                    select new { Value = cards.Key, Count = cards.Count() };

        if (query.Count() == 1)
        {
            Player.HandRank = 3;
            Player.Total = query.First().Value * 3;
            //Store high cards that aren't part of the 3 of a kind
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 3 != Player.Total).First().Value;
            Player.HighCard2 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 3 != Player.Total).ElementAt(1).Value;
            return true;
        }

        return false;

    }

    public static bool isTwoPair(List<Card> playerHand, Player Player)
    {

        var query = from card in playerHand
                    group card by card.Value into cards
                    where cards.Count() == 2
                    select new { Value = cards.Key, Count = cards.Count() };

        if (query.Count() == 2)
        {
            Player.HandRank = 1;
            Player.Total = query.OrderByDescending(x => x.Value).First().Value * 2;
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 2 != Player.Total).First().Value;

            return true;
        }

        return false;

    }

    public static bool IsPair(List<Card> playerHand, Player Player)
    {
        var query = from card in playerHand
                    group card by card.Value into cards
                    where cards.Count() == 2
                    select new { Value = cards.Key, Count = cards.Count() };

        if (query.Count() == 1)
        {
            Player.HandRank = 1;
            Player.Total = query.First().Value * 2;
            Player.HighCard1 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 2 != Player.Total).First().Value;
            Player.HighCard2 = playerHand.OrderByDescending(x => x.Value).Where(x => x.Value * 2 != Player.Total).ElementAt(1).Value;

            return true;
        }

        return false;
    }

    public static List<Card> convertToCards(string hand)
    {
        var cards = new List<Card>();
        string[] cardArray;
        cardArray = hand.Split(' ');

        for (int i = 0; i < cardArray.Length; i++)
        {
            char first = cardArray[i][0];

            //convert face cards and 10 to proper value
            switch (first)
            {
                case '1':
                    cards.Add(new Card { Suit = cardArray[i][2], Value = 10 });
                    break;

                case 'J':
                    cards.Add(new Card { Suit = cardArray[i][1], Value = 11 });
                    break;

                case 'Q':
                    cards.Add(new Card { Suit = cardArray[i][1], Value = 12 });
                    break;

                case 'K':
                    cards.Add(new Card { Suit = cardArray[i][1], Value = 13 });
                    break;

                case 'A':
                    cards.Add(new Card { Suit = cardArray[i][1], Value = 14 });
                    break;

                default:
                    cards.Add(new Card { Suit = cardArray[i][1], Value = int.Parse(first.ToString()) });
                    break;
            }

        }

        return cards;
    }
}