using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameVisualStudio2022
{
    public class Card
    {
        public string suit;
        public string rank;
        //value of card is updated with the values dictionary key
        public int value;

        //public Card()
        //{
        //}

        //create a class constructor with multiple parameters
        public Card(string cardsuit, string cardrank, int cardvalue)  //Dictionary<string, int>
        {
            suit = cardsuit;
            rank = cardrank;
            value = cardvalue;
        }
        public string returnCardInfo()
        {
            return $"{rank} of {suit}";
            //Console.WriteLine($"{rank} of {suit}");
        }
    }
}
