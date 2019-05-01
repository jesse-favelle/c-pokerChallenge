public class Card
{
    public char Suit { get; set; }
    public int Value { get; set; }

    public Card()
    {}
    
    public Card(char suit, int value)
    {
        Suit = suit;
        Value = value;
    }
}