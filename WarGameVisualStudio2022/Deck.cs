using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameVisualStudio2022
{
    public class Deck
    {
        //public Deck() //default constructor
        //{

        //}
        public Deck(Stack<Card> myDeck)    //custom
        {
            MyDeck = myDeck;
        }
        public Stack<Card> MyDeck { get; set; }  //property of the deck class is that it has a list of cardclass type objects.
        //with a for loop in the main program we will populate the instance with 52 different instances of the cardclass type.

        //create a method to remove a card from the deck and store it in a variable
        public Card GetCard() //returns a cardclass object
        {
            var card = MyDeck.Pop();
            //var cardlist = new List<Card>();
            //cardlist.Add(MyDeck.Pop());   //pop the first item off the stack and return it to our variable
            return card; //return this cardclass object (from our stack of cardclass objects) so we can use it in our program
        }

        //create a method to return all items in the deck
        public void ReturnDeckInfo()
        {
            string deckContains = "";
            foreach (var i in MyDeck)
            {
                deckContains += "\n" + i.returnCardInfo();
            }
            Console.WriteLine("The deck has" + deckContains);
        }
    }
}
