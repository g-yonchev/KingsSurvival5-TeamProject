using KingSurvival.GameLogic.Contracts;
using KingSurvival.GameLogic.Models;

namespace KingSurvival.GameLogic.Commons
{
    public class GameConstants
    {
        public const string RegexKingPattern = @"(K(U|D)(L|R)";
        public const string RegexPawnPattern = @"^(A|B|C|D)D(L|R)$";

        public const int MaxNumberOfRows = 8;
        public const int MaxNumberOfCols = 17;
        public const int MinNumberOfRows = 0;
        public const int MinNumberOfCols = 0;

        public const int BoardRows = 8;
        public const int BoardCols = 8;
        public const string Cell = " ";

        public const int FirstPawnInitialRow = 0;
        public const int FirstPawnInitialCol = 0;

        public const int SecondPawnInitialRow = 0;
        public const int SecondPawnInitialCol = 2;

        public const int ThirdPawnInitialRow = 0;
        public const int ThirdPawnInitialCol = 4;

        public const int FourthPawnInitialRow = 0;
        public const int FourthPawnInitialCol = 6;

        public const int KingInitialRow = 7;
        public const int KingInitialCol = 3;

        public static readonly bool[,] PawnExistingMoves =
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        public static IPosition[] boardEdges =
       {
            new Position(2, 4), new Position(2, 18), new Position(9, 4), new Position(9, 18)
        };

        public static IPosition[] PawnPositions =
        {
            new Position(2, 4), new Position(2, 8), new Position(2, 12), new Position(2, 16)
        };



    }
}