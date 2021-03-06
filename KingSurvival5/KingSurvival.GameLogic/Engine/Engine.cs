﻿namespace KingSurvival.GameLogic.Engine
{
    using System;
    using System.Collections.Generic;
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;
    using KingSurvival.GameLogic.Models.Factories;

    public class Engine
    {
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
        }

        public void Start()
        {
            while (true)
            {
                // PrintBoard();
                bool isKingTurn = this.moveCounter % 2 == 0;
                if (isKingTurn)
                {
                    var kingPossibleMoves = this.GetKingPossibleMoves();
                    bool kingHasLost = kingPossibleMoves.Count == 0;
                    if (kingHasLost)
                    {
                        // write king lost message on console
                        break;
                    }
                    //// ProcessKingTurn();
                }
                else
                {
                    // ProcessPawnsTurn();
                }
            }
        }

        public void ProcessKingTurn(IList<IPosition> validPositions)
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
                    var commandVector = this.ParseUserCommand(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public IList<IPosition> GetKingPossibleMoves()
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
            }

            return possibleMoves;
        }

        public bool IsOnBoard(int row, int col)
        {
            bool rowIsOnBoard = row >= 0 && row < this.board.TotalRows;
            bool colIsOnBoard = col >= 0 && col < this.board.TotalCols;

            return rowIsOnBoard && colIsOnBoard;
        }

        public string GetInput()
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

        public MovementVector ParseUserCommand(string userCommand)
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
    }
}