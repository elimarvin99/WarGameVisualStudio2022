using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameVisualStudio2022
{
    public class Player
    {
        public Player() //default constructor
        {

        }

        //we are including the dictionary here so we can access it from our class, but its set to static so it's not actually a property of the class
        public static Dictionary<string, int> ValuesDic = new Dictionary<string, int>
        {
                {"Two", 2 }, {"Three", 3}, {"Four", 4 }, {"Five", 5 }, {"Six", 6}, {"Seven", 7}, {"Eight", 8}, {"Nine", 9}, {"Ten", 10}, {"Jack", 11}, {"Queen", 12}, {"King", 13}, {"Ace", 14}
         };

        public Stack<Card> Cards = new Stack<Card>() { };
        //default value at 0 and we will add cards to each players hand as the game progresses
        public int Value = 0;
        public Player(Stack<Card> cards, int value, int aces)            //custom constructor
        {
            Cards = cards;
        }
        //the card passed into the hand will be taken from the deal method of the Deck class
        public void AddCard(Card card)
        {
            Cards.Push(card); //push the card put in as a parameter to our players stack of cards
        }
        //this method is to remove from player to table, or we can just pop from our Cards stack directly
        public Card RemoveCard()
        {
            return Cards.Pop();
        }
    }
}
