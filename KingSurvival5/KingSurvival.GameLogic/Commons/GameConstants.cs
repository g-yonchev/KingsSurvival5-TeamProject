namespace KingSurvival.GameLogic.Commons
{
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;

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

        public static readonly IPosition[] BoardEdges =
        {
            new Position(2, 4), new Position(2, 18), new Position(9, 4), new Position(9, 18)
        };

        public static readonly char[,] Field =
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        public static readonly string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };
        public static readonly bool[] KingExistingMoves = { true, true, true, true };
        public static readonly string[] PawnAPossibleDirections = { "ADL", "ADR" };
        public static readonly string[] PawnBPossibleDirections = { "BDL", "BDR" };
        public static readonly string[] PawnCPossibleDirections = { "CDL", "CDR" };
        public readonly string[] PawnDPossibleDirections = { "DDL", "DDR" };
    }
}