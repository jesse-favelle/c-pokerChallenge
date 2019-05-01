public class Player
{
    public string Name { get; set; }
    public string Hand { get; set; }
    public int HandRank { get; set; }
    public int Total { get; set; }
    public int HighCard1 { get; set; }
    public int HighCard2 { get; set; }
    public int HighCard3 { get; set; }
    public int HighCard4 { get; set; }
    public int HighCard5 { get; set; }

    public Player()
    {

    }

    public Player(string name, string hand, int handRank, int total, int highCard1, int highCard2,
    int highCard3, int highCard4, int highCard5)
    {
        Name = name;
        Hand = hand;
        HandRank = handRank;
        Total = total;
        HighCard1 = highCard1;
        HighCard2 = highCard2;
        HighCard3 = highCard3;
        HighCard4 = highCard4;
        HighCard5 = highCard5;

    }
}