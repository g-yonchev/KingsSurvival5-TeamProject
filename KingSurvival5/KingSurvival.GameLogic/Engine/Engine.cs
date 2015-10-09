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
        private King king = new King("King", new Position(1,1));


        public Engine()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            board = new Board(8, 8);
        }
         
        public void Start()
        {
            while (true)
            {
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
                }

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
            }
        }
    }
}
