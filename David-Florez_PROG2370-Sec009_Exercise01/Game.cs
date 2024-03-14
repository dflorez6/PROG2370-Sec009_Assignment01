using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;


namespace david_florez_prog2370_sec009_exercise01
{
    // Class
    public class Game
    {
        //====================
        // Global Variables / Constants
        //====================
        const int PLAYER_ONE = 1;
        const int PLAYER_TWO = 2;

        //====================
        // Attributes or properties
        //====================
        public Dictionary<string, int> GameBoard { get; set; }
        public int CurrentPlayer { get; set; }
        public bool GameFinished { get; set; }

        //====================
        // Constructors
        //====================
        // Default
        public Game()
        {
            GameBoard = new Dictionary<string, int>() {
                {"btnA1", 0}, {"btnA2", 0}, {"btnA3", 0},
                {"btnB1", 0}, {"btnB2", 0}, {"btnB3", 0},
                {"btnC1", 0}, {"btnC2", 0}, {"btnC3", 0}
            };
            CurrentPlayer = 1;
            GameFinished = false;
        }

        // Non-default
        public Game(Dictionary<string, int> gameBoard, int currentPlayer, bool gameFinished)
        {
            GameBoard = gameBoard;
            CurrentPlayer = currentPlayer;
            GameFinished = gameFinished;
        }

        //====================
        // Methods
        //====================
        // UpdateGameBoard()
        // Description: Method to update abstract representation of game board (game.GameBoard)
        // and the form buttons with corresponding images depending on the player that clicked
        // a button (game tile)
        // Parameters: string, Dictionary<string, int>, int, Button
        // Returns: void
        public void UpdateGameBoard(string buttonName, Dictionary<string, int>  gameBoard, int currentPlayer, Button buttonClicked)
        {
            // Initial Declarations
            Image playerOneSymbol = Properties.Resources.mark_x;
            Image playerTwoSymbol = Properties.Resources.mark_o;            

            // Updates gameBoard values depending on the gameCell clicked
            gameBoard[buttonName] = currentPlayer;

            // Assigns image to player
            if (currentPlayer == PLAYER_ONE)
            {
                buttonClicked.BackgroundImage = playerOneSymbol;
            }
            else if (currentPlayer == PLAYER_TWO)
            {
                buttonClicked.BackgroundImage = playerTwoSymbol;
            }
            
            // Disables clicked game tile
            buttonClicked.Enabled = false;
        }

        // determineVictory()
        // Description: Method that defines the rules of the game. It will identify
        // if there is a victory or a tie.
        // Parameters: Dictionary<string, int>, int
        // Returns: void
        public void determineVictory(Dictionary<string, int> gameBoard, int currentPlayer)
        {
            
            if (
                // Horizontal possible vitories                
                (gameBoard["btnA1"] == PLAYER_ONE && gameBoard["btnA2"] == PLAYER_ONE && gameBoard["btnA3"] == PLAYER_ONE) || (gameBoard["btnA1"] == PLAYER_TWO && gameBoard["btnA2"] == PLAYER_TWO && gameBoard["btnA3"] == PLAYER_TWO) ||
                (gameBoard["btnB1"] == PLAYER_ONE && gameBoard["btnB2"] == PLAYER_ONE && gameBoard["btnB3"] == PLAYER_ONE) || (gameBoard["btnB1"] == PLAYER_TWO && gameBoard["btnB2"] == PLAYER_TWO && gameBoard["btnB3"] == PLAYER_TWO) ||
                (gameBoard["btnC1"] == PLAYER_ONE && gameBoard["btnC2"] == PLAYER_ONE && gameBoard["btnC3"] == PLAYER_ONE) || (gameBoard["btnC1"] == PLAYER_TWO && gameBoard["btnC2"] == PLAYER_TWO && gameBoard["btnC3"] == PLAYER_TWO) ||
                // Vertical possible vitories
                (gameBoard["btnA1"] == PLAYER_ONE && gameBoard["btnB1"] == PLAYER_ONE && gameBoard["btnC1"] == PLAYER_ONE) || (gameBoard["btnA1"] == PLAYER_TWO && gameBoard["btnB1"] == PLAYER_TWO && gameBoard["btnC1"] == PLAYER_TWO) ||
                (gameBoard["btnA2"] == PLAYER_ONE && gameBoard["btnB2"] == PLAYER_ONE && gameBoard["btnC2"] == PLAYER_ONE) || (gameBoard["btnA2"] == PLAYER_TWO && gameBoard["btnB2"] == PLAYER_TWO && gameBoard["btnC2"] == PLAYER_TWO) ||
                (gameBoard["btnA3"] == PLAYER_ONE && gameBoard["btnB3"] == PLAYER_ONE && gameBoard["btnC3"] == PLAYER_ONE) || (gameBoard["btnA3"] == PLAYER_TWO && gameBoard["btnB3"] == PLAYER_TWO && gameBoard["btnC3"] == PLAYER_TWO) ||
                // Diagonal possible vitories
                (gameBoard["btnA1"] == PLAYER_ONE && gameBoard["btnB2"] == PLAYER_ONE && gameBoard["btnC3"] == PLAYER_ONE) || (gameBoard["btnA1"] == PLAYER_TWO && gameBoard["btnB2"] == PLAYER_TWO && gameBoard["btnC3"] == PLAYER_TWO) ||
                (gameBoard["btnC1"] == PLAYER_ONE && gameBoard["btnB2"] == PLAYER_ONE && gameBoard["btnA3"] == PLAYER_ONE) || (gameBoard["btnC1"] == PLAYER_TWO && gameBoard["btnB2"] == PLAYER_TWO && gameBoard["btnA3"] == PLAYER_TWO)
               )
            {
                GameFinished = true;
                MessageBox.Show($"Player {currentPlayer} is the winner!");
            }
            else if (
                    // Tie
                    (gameBoard["btnA1"] == PLAYER_ONE || gameBoard["btnA1"] == PLAYER_TWO) && (gameBoard["btnA2"] == PLAYER_ONE || gameBoard["btnA2"] == PLAYER_TWO) && (gameBoard["btnA3"] == PLAYER_ONE || gameBoard["btnA3"] == PLAYER_TWO) &&
                    (gameBoard["btnB1"] == PLAYER_ONE || gameBoard["btnB1"] == PLAYER_TWO) && (gameBoard["btnB2"] == PLAYER_ONE || gameBoard["btnB2"] == PLAYER_TWO) && (gameBoard["btnB3"] == PLAYER_ONE || gameBoard["btnB3"] == PLAYER_TWO) &&
                    (gameBoard["btnC1"] == PLAYER_ONE || gameBoard["btnC1"] == PLAYER_TWO) && (gameBoard["btnC2"] == PLAYER_ONE || gameBoard["btnC2"] == PLAYER_TWO) && (gameBoard["btnC3"] == PLAYER_ONE || gameBoard["btnC3"] == PLAYER_TWO)
                )
            {
                GameFinished = true;
                MessageBox.Show("No winner. It's a tie!");
            }
            else
            {
                // Keep Playing
                GameFinished = false;
            }

        }

    }

}