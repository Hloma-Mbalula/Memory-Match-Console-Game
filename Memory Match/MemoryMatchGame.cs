using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Match
{
    
    public class MemoryMatchGame
    {
        public int player1Score = 0;
        public int player2Score = 0;
        public int currentPlayer = 1;
        char[,] grid = new char[4, 4];
        public bool[,] revealedCards = new bool[4, 4];
        char[] characters = {
            'A', 'A', 'B', 'B',
            'C', 'C', 'D', 'D',
            'E', 'E', 'F', 'F',
            'G', 'G', 'H', 'H'
        };
        
        public void InitializeGrid()
        {
            var random = new Random();
            // Shuffle loop
            for(int i = characters.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                char temp = characters[i];
                characters[i] = characters[j];
                characters[j] = temp;
            }
            // Transfer the shuffled into a 2D array

            int counter = 0;
            for( int row = 0; row < grid.GetLength(0); row++)
            {
                for( int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = characters[counter];
                    counter++;

                }
            }

        }

        // Method to display the grid
        public void DisplayGrid(bool[,] revealedCards)
        {
            Console.WriteLine("   A    B    C    D");
            Console.WriteLine("  ------------------");

            for ( int row = 0; row < grid.GetLength(0); row++)
            {
                Console.Write(row + 1 + " ");
                for( int col = 0; col < grid.GetLength(1); col++)
                {
                    if (revealedCards[row, col])
                    {
                        Console.Write($" {grid[row, col]} | ");
                    }
                    else
                    {
                        Console.Write(" * | ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("  ------------------");
            }
        }

        // Player Input Method
         public void PlayerInput()
        {
            Console.WriteLine($"Player {currentPlayer}, its your turn");
            Console.WriteLine("Select your first square coordinates.");
            string choice1 = Console.ReadLine();

            Console.WriteLine("Select your second square coordinates.");
            string choice2 = Console.ReadLine();



            if( choice1.Length == 2 && choice2.Length == 2)
            {
                char col1 = choice1[0];
                char row1 = choice1[1];

                char col2 = choice2[0];
                char row2 = choice2[1];
                //Validate coordinates are within bounds
                if( "ABCD".Contains(col1) && "1234".Contains(row1) &&
                    "ABCD".Contains(col2) && "1234".Contains(row2) )
                {
                    // calculate array indices
                    int colIndex1 = col1 - 'A';
                    int rowIndex1 = row1 - '1';

                    int colIndex2 = col2 - 'A';
                    int rowIndex2 = row2 - '1';
                    // Ensure that the chosen squares are different
                    if (colIndex1 == colIndex2 && rowIndex1 == rowIndex2)
                    {
                        Console.WriteLine("You have selected the same square twice. Please pick two different squares.");
                        return;
                    }
                    //Check if both squares are hidden
                    if (!revealedCards[rowIndex1, colIndex1] && !revealedCards[rowIndex2, colIndex2])
                    {
                        // Reveal the chosen square
                        revealedCards[rowIndex1, colIndex1] = true;
                        revealedCards[rowIndex2, colIndex2] = true;
                        DisplayGrid(revealedCards);

                        // Check for a match
                        if (grid[rowIndex1, colIndex1] == grid[rowIndex2, colIndex2])
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Its a match!");
                            if (currentPlayer == 1) player1Score++;
                            else player2Score++;
                            
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Not a match! Switching turns");
                            revealedCards[rowIndex1,colIndex1] = false;
                            revealedCards[rowIndex2, colIndex2] = false;
                            DisplayGrid(revealedCards);
                            
                            currentPlayer = (currentPlayer == 1) ? 2 : 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please pick again, some of the cards you picked have already been revealed.");
                        
                    }
                }
                else
                {
                    Console.WriteLine("The characters you entered were out of bounds. Please look at the grid and try again.");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Format!");
            };

            
            
        }

        public bool AllSquaresRevealed()
        {
            for (int row = 0; row < revealedCards.GetLength(0); row++)
            {
                for(int col = 0; col < revealedCards.GetLength(1); col++)
                {
                    if (!revealedCards[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    
    }
}
