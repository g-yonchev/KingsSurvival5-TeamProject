using KingSurvival.GameLogic.Commons;
using KingSurvival.GameLogic.Contracts;
using KingSurvival.GameLogic.Models;
using KingSurvival.GameLogic.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.GameLogic.Engine
{
    public class Engine
    {
<<<<<<< HEAD
        private IBoard board;

        private Dictionary<char, IFigure> figuresInPlay = new Dictionary<char, IFigure>();

        private int moveCounter;

        // TODO Must change!
        public Engine()
        {
            this.board = new Board(GameConstants.BoardRows, GameConstants.BoardCols);

            this.moveCounter = 0;

            var kingFactory = new KingFactory();
            var king = kingFactory.CreateFigure('K', new Position(7, 3));
            this.figuresInPlay.Add(king.Symbol, king);

            var pawnsFactory = new PawnFactory();
            var pawnA = pawnsFactory.CreateFigure('A', new Position(0, 0));
            this.figuresInPlay.Add(pawnA.Symbol, pawnA);

            var pawnB = pawnsFactory.CreateFigure('B', new Position(0, 2));
            this.figuresInPlay.Add(pawnB.Symbol, pawnB);
=======
        //private IRenderer renderer;
        private Board board;
        private King king = new King("King", new Position(1,1));


        public Engine()
        {
            this.Initialize();
>>>>>>> origin/master
        }

        public void Initialize()
        {
            board = new Board(8, 8);
        }
         
        public void Start()
        {
            while (true)
            {
<<<<<<< HEAD
                //PrintBoard();

                bool isKingTurn = this.moveCounter % 2 == 0;
                if (isKingTurn)
                {
                    var kingPossibleMoves = GetKingPossibleMoves();
                    bool kingHasLost = kingPossibleMoves.Count == 0;
                    if (kingHasLost)
                    {
                        // write king lost message on console
                        break;
                    }
                    //ProcessKingTurn();
                }
                else
                {
                    //ProcessPawnTurn();
=======
                var command = Console.ReadLine();

                // K, or A, b, c,....
                var commandName = command.Substring(0,1);

                // Which direction
                var commandDirection = command.Substring(1,2);

                IPosition newPosition = null;

                if (!Validator.IsValidCommand(command))
                {

                    // commandName validate
                    // Which direction validate

                    throw new Exception();
>>>>>>> origin/master
                }

<<<<<<< HEAD
        private void ProcessKingTurn(IList<IPosition> validPositions)
        {
            bool shouldAskForInput = true;
            while (shouldAskForInput)
            {
                // Renderer should do that
                Console.WriteLine("Please enter command for King: UL, UR, DL, DR");

                var input = this.GetInput();
                if (input == string.Empty)
                {
                    // Renderer should do that
                    Console.WriteLine("Illegal move!");
                    continue; 
                }

                try
                {
                    var commandVector = ParseUserCommand(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }


        private IList<IPosition> GetKingPossibleMoves()
        {
            var movementStrategy = this.figuresInPlay['K'].GetMovements();
            var currentPostion = this.figuresInPlay['K'].Position;
            var possibleMoves = new List<IPosition>();

            foreach (var m in movementStrategy)
            {
                bool isOnBoard = this.IsOnBoard(currentPostion.Row + m.ByRow, currentPostion.Col + m.ByCol);
                if (!isOnBoard)
                {
                    continue;
                }

                var possiblePosition = new Position(currentPostion.Row + m.ByRow, currentPostion.Col + m.ByCol);
                bool isUnoccupied = this.board.PositionIsUnoccupied(possiblePosition);
                if (isUnoccupied)
                {
                    possibleMoves.Add(possiblePosition);
                }
=======
                if (!Validator.CanMove())
                {
                    // first the command "UL" will be parse new ++ or -- position... blah blah...

                    newPosition = new Position(2, 2);

                    var isThisPlaceInOutOfTheBorders = board.Field[2, 2];
                    var isThisPlaceInFree = board.Field[2, 2];
                    throw new Exception();
                }
                newPosition = new Position(2, 2);
                king.Move(newPosition);
>>>>>>> origin/master
            }

            return possibleMoves;
        }
<<<<<<< HEAD

        private bool IsOnBoard(int row, int col)
        {
            bool rowIsOnBoard = row >= 0 && row < this.board.TotalRows;
            bool colIsOnBoard = col >= 0 && col < this.board.TotalCols;

            return rowIsOnBoard && colIsOnBoard;
        }

        private string GetInput()
        {
            string result = string.Empty;

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                return result;
            }
            else
            {
                string inputTrimmed = input.Trim();
                result = inputTrimmed.ToUpper();

                return result;
            }
        }

        private MovementVector ParseUserCommand(string userCommand)
        {
            switch (userCommand)
            {
                case "UL":
                    return new MovementVector(-1, -1);
                case "UR":
                    return new MovementVector(-1, 1);
                case "DL":
                    return new MovementVector(1, -1);
                case "DR":
                    return new MovementVector(1, 1);
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
=======
>>>>>>> origin/master
    }
}
