using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class BlackjackGame
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
            int playerX = 10;
            int playerY = 15;
            int dealerX = 10;
            int dealerY = 10;

            _deck.Shuffle();

            //deal two cards to player and dealer and draw to console alternating 
            _player.AddCard(_deck.Deal(2)[0]);
            _player.Draw(playerX, playerY);
            playerX += 10;

            
            _dealer.AddCard(_deck.Deal(2)[0]);
            Console.SetCursorPosition(dealerX, dealerY);
            Console.WriteLine("XX");
            dealerX += 10;

            _player.AddCard(_deck.Deal(2)[1]);
            _player.Draw(playerX, playerY);

            _dealer.AddCard(_deck.Deal(2)[1]);
            _dealer.Draw(dealerX, dealerY);
            

        }

        public void PlayersTurn()
        {
            int playerX = 30;
            int playerY = 15;
            while (_player.Score < 21)
            {
                Console.WriteLine("Player's turn. Do you want to HIT or STAND? (Type 'H' for Hit, 'S' for Stand) ");
                string choice = Console.ReadLine();

                if (choice.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    _deck.Deal(1);
                    _player.Draw(playerX, playerY);
                    playerX += 10;
                }
                else if(choice.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    //break out of loop
                    break;
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
