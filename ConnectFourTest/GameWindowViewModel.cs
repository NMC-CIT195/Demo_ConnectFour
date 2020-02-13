using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourTest
{
    public class GameWindowViewModel : ObservableObject
    {
        private enum GameState
        {
            PLAYER_RED,
            PLAYER_BLUE
        }

        private const string PLAYER_RED_CHIP_COLOR = "Red";
        private const string PLAER_BLUE_CHIP_COLOR = "Blue";
        private const string EMPTY_BOARD_LOCATION_COLOR = "Gray";

        private string _currentPlayer;
        private GameState _currentGameState;
        private string[][] _currentBoard;

        public string[][] CurrentBoard
        {
            get { return _currentBoard; }
            set
            {
                _currentBoard = value;
                OnPropertyChanged(nameof(CurrentBoard));
            }
        }

        public string CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public GameWindowViewModel()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _currentGameState = GameState.PLAYER_RED;
            CurrentPlayer = GameState.PLAYER_RED.ToString();

            CurrentBoard = new string[2][];
            CurrentBoard[0] = new string[2];
            CurrentBoard[1] = new string[2];
            InitializeGameboard();
        }

        /// <summary>
        /// fill the game board array with gray pieces
        /// </summary>
        public void InitializeGameboard()
        {
            //
            // Set all PlayerPiece array values to "None"
            //
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    CurrentBoard[row][column] = EMPTY_BOARD_LOCATION_COLOR;
                }
            }
        }

        internal void PlayerMove(int row, int column)
        {
            if (CurrentBoard[row][column] == "Gray")
            {
                if (_currentGameState == GameState.PLAYER_RED)
                {
                    CurrentBoard[row][column] = PLAYER_RED_CHIP_COLOR;
                    OnPropertyChanged(nameof(CurrentBoard));
                    _currentGameState = GameState.PLAYER_BLUE;
                    CurrentPlayer = GameState.PLAYER_BLUE.ToString();
                }
                else
                {
                    CurrentBoard[row][column] = PLAER_BLUE_CHIP_COLOR;
                    OnPropertyChanged(nameof(CurrentBoard));
                    _currentGameState = GameState.PLAYER_RED;
                    CurrentPlayer = GameState.PLAYER_RED.ToString();
                }

            }
        }
    }
}
