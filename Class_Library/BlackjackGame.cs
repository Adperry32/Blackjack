using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public  class BlackjackGame
    {
        BlackjackHand _dealer = new BlackjackHand(true);
        BlackjackHand _player = new BlackjackHand();    
        Deck _deck = new Deck();


        public void PlayRound()
        {
            Console.Clear();
            DealInitialCards();
            PlayersTurn();
            DealersTurn();
            DeclareWinner();

        }

        public void DealInitialCards() 
        {
            _deck.Shuffle();

            //deal two cards to player and dealer

        }

        public void PlayersTurn() 
        {
            int playerX = 30;
            int playerY = 10;   
            while(_player.Score < 21)
            {
                Console.WriteLine("Player's turn. Do you want to HIT or STAND? (Type 'H' for Hit, 'S' for Stand) ");
                string Choice = Console.ReadLine();

                if(Choice.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    _deck.Deal(1);
                    _player.Draw(playerX, playerY);
                }
            }

        }
        public void DealersTurn()
        {

        }

        public void DeclareWinner()
        {

        }
    }
}
