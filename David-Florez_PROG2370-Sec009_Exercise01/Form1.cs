using System.Collections.Generic;
using System.Numerics;

namespace david_florez_prog2370_sec009_exercise01
{
    public partial class Form1 : Form
    {
        //====================
        // Initializations
        //====================
        const int PLAYER_ONE = 1;
        const int PLAYER_TWO = 2;
        List<Button> buttons = new List<Button>();
        Game game = new Game();


        public Form1()
        {
            InitializeComponent();
        }

        //====================
        // Event Triggered Methods
        //====================       
        // CheckButton
        // This method is in charge of checking each button clicked in order to play
        // the game:
        // 1. Checks the player's turn
        // 2. Calls the method that updates the game board
        // 3. Calls the method that checks if there is a victory, a tie or players
        // continue to play the game
        // 4. When game is finished (game.GameFinished == true) it disables all buttons
        // so nobody can click on any button && resets the game board        
        private void CheckButton(object sender, EventArgs e)
        {
            try
            {
                // Identifies the button that is being clicked & stores the button
                // name for later reference
                Button buttonClicked = (Button)sender;
                string buttonName = buttonClicked.Name;

                // Player 1 starts playing
                if (game.CurrentPlayer == PLAYER_ONE)
                {
                    // Method to update GameBoard
                    game.UpdateGameBoard(buttonName, game.GameBoard, game.CurrentPlayer, buttonClicked);

                    // Method to determine if there is a winner
                    game.determineVictory(game.GameBoard, game.CurrentPlayer);

                    // Switch turns
                    game.CurrentPlayer = PLAYER_TWO;
                }
                else if (game.CurrentPlayer == PLAYER_TWO)
                {
                    // Method to update GameBoard
                    game.UpdateGameBoard(buttonName, game.GameBoard, game.CurrentPlayer, buttonClicked);

                    // Method to determine if there is a winner
                    game.determineVictory(game.GameBoard, game.CurrentPlayer);

                    // Switch turns
                    game.CurrentPlayer = PLAYER_ONE;
                }

                // Game is over, disables all inputs
                if (game.GameFinished)
                {
                    // Disables all buttons so no more plays can be made
                    foreach (var button in ButtonList())
                    {
                        button.Enabled = false;
                    }

                    ResetGame();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        // btnReset_Click
        // On click of the btnReset button, the method ResetGame() is called to re-start
        // the game
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }


        //====================
        // Utility Methods
        //====================
        // ButtonList()
        // Description: Creates a List with all the buttons in the form that represent
        // a playable tile
        // Parameters: None
        // Returns: List<Button>
        public List<Button> ButtonList()
        {
            List<Button> buttons = new List<Button>
            {
                btnA1, btnA2, btnA3,
                btnB1, btnB2, btnB3,
                btnC1, btnC2, btnC3
            };
            return buttons;
        }

        // ResetGame()
        // Description: Sets game back to its original state
        // Parameters: None
        // Returns: void
        public void ResetGame()
        {
            foreach (var button in ButtonList())
            {
                button.BackgroundImage = null;
                button.Enabled = true;
                game.CurrentPlayer = PLAYER_ONE;
                game.GameFinished = false;
                // Resets GameBoard
                game.GameBoard[button.Name] = 0;
            }
        }

    }
}