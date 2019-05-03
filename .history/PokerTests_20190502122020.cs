using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;


namespace PokerTests
{
    public class CardTests
    {

        [Fact]
        public void TestIsHandFlush()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 3D, 4D, 5D, 10D"},
            };

            testPoker.checkHand(players);
            Assert.Equal(3, players.Max(x => x.HandRank));


        }

        [Fact]
        public void TestIsHandThreeOfAKind()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 4D, 4S, 10D"},
            };

            testPoker.checkHand(players);
            Assert.Equal(2, players.Max(x => x.HandRank));

        }
        [Fact]
        public void TestIsHandPair()
        {

            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 4C, 3S, 10D"},
            };

            testPoker.checkHand(players);
            Assert.Equal(1, players.Max(x => x.HandRank));

        }
        [Fact]
        public void TestIsHandHiCard()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 5C, 3S, 10D"},
            };

            testPoker.checkHand(players);
            Assert.Equal(0, players.Max(x => x.HandRank));

        }

        [Fact]
        public void TestFlushWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 5D, 3D, 10D"},
                new Player { Name="Bob", Hand="5C, 7D, 8H, 9S, QD"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }

        [Fact]
        public void TestFourOfAKindWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 10D, 10C, 10D, 10D"},
                new Player { Name="Bob", Hand="5C, 7D, 8H, 9S, QD"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("7", player.HandRank);
        }

        [Fact]
        public void TestThreePairWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10C, 10D, 10D"},
                new Player { Name="Bob", Hand="5C, 7D, 8H, 9S, QD"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }
        [Fact]
        public void TestPairWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10C, 10D, 9D"},
                new Player { Name="Bob", Hand="5C, 7D, 8H, 9S, QD"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }
        [Fact]
        public void TestHiCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10C, 8D, 9D"},
                new Player { Name="Bob", Hand="5C, 7D, 8H, 9S, QD"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Bob", player.Name);
        }

        [Fact]
        public void TestBothFlushWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10D, 8D, 9D"},
                new Player { Name="Bob", Hand="5H, 7H, 8H, 9H, QH"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Bob", player.Name);
        }

        [Fact]
        public void TestBothThreePair1stHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10D, 10C, 10D"},
                new Player { Name="Bob", Hand="5H, 7D, 10H, 10H, 10H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Bob", player.Name);
        }

        [Fact]
        public void TestBothThreePair1stHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="2D, 4D, 10D, 10C, 10D"},
                new Player { Name="Bob", Hand="5H, 7D, 10H, 10H, 10H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Bob", player.Name);
        }

        [Fact]
        public void TestBothThreePair2ndHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="3D, 4D, 10D, 10C, 10D"},
                new Player { Name="Bob", Hand="2C, 4H, 10H, 10H, 10H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }
        [Fact]
        public void TestBothPair1stHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="3D, 4D, 10D, 10C, 9D"},
                new Player { Name="Bob", Hand="2C, 4H, 10H, 10H, 8H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }

        [Fact]
        public void TestBothPair2ndHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="3D, 4D, 10D, 10C, 9D"},
                new Player { Name="Bob", Hand="2C, 3H, 10H, 10H, 9H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Joe", player.Name);
        }
        [Fact]
        public void TestBothHighCardWinner()
        {
            PokerGame testPoker = new PokerGame();

            List<Player> players = new List<Player>
            {
                new Player { Name="Joe", Hand="3D, 4D, QD, JC, 9D"},
                new Player { Name="Bob", Hand="2C, 4H, KH, AH, 8H"}

            };

            testPoker.checkHand(players);
            testPoker.checkWinner(players);
            Player player = testPoker.sortWinners(players);
            Assert.Equal("Bob", player.Name);
        }
    }
}