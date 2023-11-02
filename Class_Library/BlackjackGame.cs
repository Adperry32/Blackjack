using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            int playerX = 5;
            int playerY = 12;
            int dealerX = 5;
            int dealerY = 5;

            _deck.Shuffle();

            //deal two cards to player and dealer and draw to console alternating 
            _player.AddCard(_deck.Deal(1)[0]);
            _player.Draw(playerX, playerY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PLAYER***");
            Console.ResetColor();
            playerX += 10;


            _dealer.AddCard(_deck.Deal(1)[0]);
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("**DEALER**");
            _dealer.Draw(dealerX, dealerY);
            Console.ResetColor();
            dealerX += 10;

            _player.AddCard(_deck.Deal(1)[0]);
            _player.Draw(playerX, playerY);

            _dealer.AddCard(_deck.Deal(1)[0]);
            _dealer.Draw(dealerX, dealerY);


        }

        public void PlayersTurn()
        {
            int playerX = 25;
            int playerY = 12;
            while (_player.Score < 21)
            {
                Console.SetCursorPosition(25, 18);
                Console.WriteLine("Player's turn. Do you want to HIT or STAND? (Type 'H' for Hit, 'S' for Stand) ");
                string choice = Console.ReadLine();

                if (choice.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    _player.AddCard(_deck.Deal(1)[0]);
                    _player.Draw(playerX, playerY);
                    playerX += 10;

                    //clear players turn question/statement from the console
                    Console.SetCursorPosition(25, 18);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                else if (choice.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    //break out of loop
                    //clear previous string and add new statement
                    Console.SetCursorPosition(25, 18);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(25, 18);
                    Console.WriteLine("Player is Standing with " + _player.Score);
                    break;
                }
            }

        }
        public void DealersTurn()
        {

            int dealerX = 25;
            int dealerY = 5;

            //reveal dealers first card
            _dealer.ShowFirstCard = true;
            _dealer.Draw(15, 5);


            while (_dealer.Score <= 16)
            {
                _dealer.AddCard(_deck.Deal(1)[0]);
                _dealer.Draw(dealerX, dealerY);
                dealerX += 10;
                Thread.Sleep(4000);
            }
        }

        public void DeclareWinner()
        {

        }
    }
}
