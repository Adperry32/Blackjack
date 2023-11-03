using Stripe.Checkout;
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
        bool playerBust = false;
        bool fiveCardWinner = false;
        bool dealerTurn = false;

        public void PlayRound()
        {
            Console.Clear();
            DealInitialCards();
            PlayersTurn();
            DealersTurn();
            DeclareWinner();

            //reset game 
            ResetGame();

        }

        public void DealInitialCards()
        {
            int playerX = 5;
            int playerY = 12;
            int dealerX = 5;
            int dealerY = 5;

            _deck.Shuffle();
            ShowScore();

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
            int rotations = 2;

            while (_player.Score < 21 && rotations < 5)
            {
                dealerTurn = false;
                ShowScore();

                //get user input to add card to hand or stay with current points
                Console.SetCursorPosition(25, 18);
                Console.WriteLine("Player's turn. Do you want to HIT or STAND? (Type 'H' for Hit, 'S' for Stand)");
                string choice = Console.ReadLine();

                if (choice.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    _player.AddCard(_deck.Deal(1)[0]);
                    _player.Draw(playerX, playerY);
                    playerX += 10;

                    //clear players turn question/statement from the console
                    Console.SetCursorPosition(25, 18);
                    Console.Write(new string(' ', Console.WindowWidth));

                    //check if player busted
                    if (_player.Score > 21)
                    {
                        playerBust = true;
                        DeclareWinner();
                    }

                    if (_player.Score == 21)
                    {
                        DeclareWinner();
                    }
                    rotations++;
                    if (rotations >= 5)
                    {
                        fiveCardWinner = true;
                        DeclareWinner();
                    }
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
            dealerTurn = true;


            int dealerX = 25;
            int dealerY = 5;

            //reveal dealers first card
            _dealer.ShowFirstCard = true;
            _dealer.Draw(15, 5);
            ShowScore();

            while (_dealer.Score <= 17)
            {
                //check if player bust before dealing additional cards
                if (playerBust == true)
                {
                    Console.SetCursorPosition(25, 22);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(25, 22);
                    Console.WriteLine("**Dealer Wins** ");
                    break;
                }
                _dealer.AddCard(_deck.Deal(1)[0]);
                _dealer.Draw(dealerX, dealerY);
                dealerX += 10;

                //sleep to simulate dealer thinking/flipping new card
                Thread.Sleep(1500);
            }
        }

        public void DeclareWinner()
        {
            ShowScore();

            if (fiveCardWinner == true)
            {
                Console.WriteLine("Five cards drawn - Player Wins " + _player.Score);
            }


            else if (_dealer.Score > 21)
            {
                Console.SetCursorPosition(25, 23);
                Console.WriteLine("Winner Winner (!!Player!!)  Dealer Bust^^ " + _dealer.Score);
                Thread.Sleep(3000);
                Console.Clear();
            }
            else if (_player.Score > 21)
            {
                Console.SetCursorPosition(25, 25);
                Console.WriteLine("Winner Winner (^^Dealer^^)   Player Bust!! " + _player.Score);
                Thread.Sleep(3000);
                Console.Clear();
            }
            else if (_dealer.Score > _player.Score)
            {
                Console.SetCursorPosition(25, 25);
                Console.WriteLine("Winner Winner (^^Dealer^^) Score: " + _dealer.Score);
                Thread.Sleep(3000);
                Console.Clear();
            }
            else if (_player.Score > _dealer.Score)
            {
                Console.SetCursorPosition(25, 25);
                Console.WriteLine("Winner Winner (!!Player!!) Score: " + _player.Score);
                Thread.Sleep(3000);
                Console.Clear();
            }
            else
            {
                Console.SetCursorPosition(25, 23);
                Console.WriteLine(" Its a push (tie)!");
                Thread.Sleep(3000);
                Console.Clear();
            }
           
        }

        public void ShowScore()
        {
            if (dealerTurn == true)
            {
                Console.SetCursorPosition(85, 5);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" __________________ ");
                Console.SetCursorPosition(85, 6);
                Console.WriteLine("|       SCORE      |");
                Console.SetCursorPosition(85, 7);
                Console.WriteLine("|------------------|");
                Console.SetCursorPosition(85, 8);
                Console.WriteLine("|                  |");
                Console.SetCursorPosition(85, 9);
                Console.WriteLine($"|Player:{_player.Score}         |");
                Console.SetCursorPosition(85, 10);
                Console.WriteLine($"|Dealer:{_dealer.Score}         |");
                Console.SetCursorPosition(85, 11);
                Console.WriteLine("|__________________|");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(85, 5);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" __________________ ");
                Console.SetCursorPosition(85, 6);
                Console.WriteLine("|       SCORE      |");
                Console.SetCursorPosition(85, 7);
                Console.WriteLine("|------------------|");
                Console.SetCursorPosition(85, 8);
                Console.WriteLine("|                  |");
                Console.SetCursorPosition(85, 9);
                Console.WriteLine($"|Player:{_player.Score}         |");
                Console.SetCursorPosition(85, 10);
                Console.WriteLine($"|Dealer:{0}          |");
                Console.SetCursorPosition(85, 11);
                Console.WriteLine("|__________________|");
                Console.ResetColor();
            }

        }

        public void ResetGame()
        {
            dealerTurn = false;
            _dealer = new BlackjackHand(true);
            _player = new BlackjackHand();
            _deck = new Deck();

            _player.Score = 0;
            _dealer.Score = 0;
        }
    }
}
