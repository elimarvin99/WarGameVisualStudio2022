using WarGameVisualStudio2022;


static bool GameWinCheck(Player playerOne, Player playerTwo)
{
    if (playerOne.Cards.Count == 0)
    {
        Console.WriteLine("Player One out of cards! Game Over");
        Console.WriteLine("Player Two Wins!");
        return false;
    }
    else if (playerTwo.Cards.Count == 0)
    {
        Console.WriteLine("Player Two out of cards! Game Over");
        Console.WriteLine("Player One Wins!");
        return false;
    }
    else return true;
}

static bool RoundWinCheck(Player playerOne, Player playerTwo, Stack<Card> playerOneHand, Stack<Card> playerTwoHand)
{
    var playerOneFirstCard = playerOneHand.Pop(); //this is automatically the last card, the card at index 0
    var playerTwoFirstCard = playerTwoHand.Pop();
    if (playerOneFirstCard.value > playerTwoFirstCard.value)
    {
        Console.WriteLine("Player One has won this round");
        for (int i = 0; i < playerOneHand.Count; i++)
        {
            playerOne.AddCard(playerOneHand.Pop());
            playerOne.AddCard(playerTwoHand.Pop());
        }
        return false;
    }
    else if (playerOneFirstCard.value < playerTwoFirstCard.value)
    {
        Console.WriteLine("Player Two has won this round");
        for (int i = 0; i < playerTwoHand.Count; i++)
        {
            playerTwo.AddCard(playerOneHand.Pop());
            playerTwo.AddCard(playerTwoHand.Pop());
        }
        return false;
    }
    else
    {
        return true;
    }
}

static bool WarLossCheck(Player playerOne, Player playerTwo, Stack<Card> playerOneHand, Stack<Card> playerTwoHand)
{
    Console.WriteLine("WAR!!!");
    if (playerOne.Cards.Count < 5)
    {
        Console.WriteLine("Player One unable to play war! Game over at War");
        Console.WriteLine("Player Two Wins! Player One Loses!");
        return false;
    }
    else if (playerTwo.Cards.Count < 5)
    {
        Console.WriteLine("Player Two unable to play war! Game over at War");
        Console.WriteLine("Player One Wins! Player Two Loses!");
        return false;
    }
    else
    {
        return true;
    }

}

var suits = new[] { "Hearts", "Diamonds", "Spades", "Clubs" };
var ranks = new[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
//create a dictionary of all card names with their given values, that way we can refernce the cards value throughout the game to see if < 21.
var values = new Dictionary<string, int> {
                {"Two", 2 },{"Three", 3 }, {"Four", 4 }, {"Five", 5 }, {"Six", 6}, {"Seven", 7}, {"Eight", 8}, {"Nine", 9}, {"Ten", 10}, {"Jack", 11}, {"Queen", 12}, {"King", 13}, {"Ace", 14}
            };

var ourDeck = new Deck(new Stack<Card>());

foreach (var num in suits)
{
    foreach (var i in ranks)
    {
        //values[i] accesses the key to the int value of each car
        ourDeck.MyDeck.Push(new Card(num, i, values[i]));    //adding cards to stack, and cards value is updated with the values dictionary
    }
}
ourDeck.ReturnDeckInfo();

var shuffledDeck = ourDeck.MyDeck.OrderBy(i => Guid.NewGuid()).ToList();    //this method doesn't work because we are reutrning a list not a stack

//create a new deckclass instance so we can populate it from the now shuffleddeck list
var ourDeck2 = new Deck(new Stack<Card>());
foreach (var i in shuffledDeck)
{
    ourDeck2.MyDeck.Push(i);
}

var playerOne = new Player();
var playerTwo = new Player();
//divide half the deck to each player
for (int i = 0; i < 26; i++)
{
    playerOne.Cards.Push(ourDeck2.GetCard());
    playerTwo.Cards.Push(ourDeck2.GetCard());
}
Console.WriteLine("Player one's cards");
Console.WriteLine($"{playerOne.Cards.Count}");
foreach (var item in playerOne.Cards)
{
    Console.WriteLine(item.returnCardInfo());
}
Console.WriteLine("Player two's cards");
Console.WriteLine(playerOne.Cards.Count);
foreach (var item in playerTwo.Cards)
{
    Console.WriteLine(item.returnCardInfo());
}
//hand needs to be a stack that way we can remove the cards from them and give them to the winner after each turn
var playerOneHand = new Stack<Card>();
var playerTwoHand = new Stack<Card>();

var roundNumber = 0;
var gameOn = true;

while (gameOn)
{
    roundNumber++;
    Console.WriteLine($"Round Number {roundNumber}:");
    gameOn = GameWinCheck(playerOne, playerTwo); //if someone wins (a factor checked at the begining of each round than loop is exited
    playerOneHand.Push(playerOne.RemoveCard());
    playerTwoHand.Push(playerTwo.RemoveCard());

    
    var War = RoundWinCheck(playerOne,playerTwo,playerOneHand,playerTwoHand);
    
    while (War)
    {
        gameOn = WarLossCheck(playerOne, playerTwo, playerOneHand, playerTwoHand);

            for (int i = 0; i < 5; i++)
            {
                playerOneHand.Push(playerOne.RemoveCard());
                playerTwoHand.Push(playerTwo.RemoveCard());
            }
            War = RoundWinCheck(playerOne, playerTwo, playerOneHand, playerTwoHand); //will continue checking for winner of war
        //sometimes can be war after war
        //if war is false (someone has won the round) than the while loop starts the next round
        
    }
}

