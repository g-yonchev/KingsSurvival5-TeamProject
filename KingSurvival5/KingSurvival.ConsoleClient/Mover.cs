namespace KingSurvival.ConsoleClient
{
    using KingSurvival.GameLogic.Contracts;
    using System;

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
