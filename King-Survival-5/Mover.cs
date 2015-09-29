using Contracts;
using System;


namespace KingSurvival
{
    public static class Mover
    {
        public static void MoveFigure(IPosition currentCoordinates, IPosition newCoordinates)
        {
            char currentPos = BaseGame.GetField[currentCoordinates.Row, currentCoordinates.Col];
            BaseGame.GetField[currentCoordinates.Row, currentCoordinates.Col] = ' ';
            BaseGame.GetField[newCoordinates.Row, newCoordinates.Col] = currentPos;
        }
    }
}
