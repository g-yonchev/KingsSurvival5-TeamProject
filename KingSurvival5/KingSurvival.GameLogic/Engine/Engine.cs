using KingSurvival.GameLogic.Commons;
using KingSurvival.GameLogic.Contracts;
using KingSurvival.GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.GameLogic.Engine
{
    public class Engine : IEngine
    {
        //private IRenderer renderer;
        private Board board;

        public void Initialize()
        {
            this.board = Board.Instance;
           // this.renderer = new Renderer();
        }

        public void Start()
        {
            while (true)
            {
                if (true /*!GameOver*/)
                {
                    Console.WriteLine("board"); //renderer.RenderBoard();

                    // for exaple this is hardcore variable, represent the pawn is his turn
                    var moveCounter = 3;
                    bool isKingTurn = moveCounter % 2 == 0;
                    if (isKingTurn)
                    {
                        //ProcessKingTurn();
                    }
                    else
                    {
                        //ProcessPawnTurn(); // this method does exactly what is written bewol
                        


                        // TODO: In the future when renderer is implemented, the console will be replaced with the renderer
                        // same for the king
                        Console.WriteLine(MessageConstants.PawnTurnMessage);

                        string input = Console.ReadLine();
                        if (input == string.Empty)
                        {
                            Console.WriteLine(MessageConstants.EmptyStringMessage);
                            continue;
                        }

                        bool isValidDirection = true;
                        if (!isValidDirection)
                        {
                            Console.WriteLine(MessageConstants.InvalidCommandMessage);
                            continue;
                        }

                        // I suppose it works in a way similar to KingDirection()
                        char pawnName = input[0];
                        char directionLeftRight = input[2];
                        int pawnNumber = pawnName - 65;
                        PawnDirection(pawnName, directionLeftRight, pawnNumber);
                    }
                }
                else
                {
                    Console.WriteLine(MessageConstants.FinishGameMessage);
                    return;
                }
            }
        }

        // TODO: Delete later, when all is implemented
        private void PawnDirection(char pawn, char direction, int pawnNumber)
        {
            var oldCoordinates = PawnPositions[pawnNumber];

            var coords = CheckNextPawnPosition();

            if (coords != null)
            {
                PawnPositions[pawnNumber] = coords;
            }
        }

        // TODO: Delete later, when all is implemented
        private IPosition CheckNextPawnPosition()
        {
            return new Position();
        }

        // TODO: Delete later, when all is implemented
        public bool shouldAskForInput { get; set; }

        // TODO: Delete later, when all is implemented
        protected IPosition[] PawnPositions = 
        {
            new Position(2, 4), 
            new Position(2, 8), 
            new Position(2, 12), 
            new Position(2, 16)
        };
    }
}
