using System;
using Memory_Match;

namespace Program
{
    public class MemoG
    {
        
        static void Main(string[] args)
        {
            MemoryMatchGame game = new MemoryMatchGame();
            game.InitializeGrid();

            Console.WriteLine("Welcome to the Memory Match Game");
            Console.WriteLine("You're going to enter coordinates for 2 squares. If the 2 squares you pick match, you gain points/win.");
            Console.WriteLine();

            while (!game.AllSquaresRevealed())
            {
                Console.Clear();
                Console.WriteLine($"Player 1 : {game.player1Score} - Player 2: {game.player2Score} ");

                game.DisplayGrid(game.revealedCards);
                game.PlayerInput();
            }

            Console.WriteLine("Game Over!");
            game.DisplayGrid(game.revealedCards);


            if (game.player1Score > game.player2Score)
            {
                Console.WriteLine("PLayer 1 has won the game!");
            }
            else if (game.player2Score > game.player1Score)
            {
                Console.WriteLine("Player 2 has won the game!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

        }
    }

    
}
