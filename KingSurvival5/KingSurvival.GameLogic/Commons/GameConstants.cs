namespace KingSurvival.GameLogic.Commons
{
    using KingSurvival.GameLogic.Contracts;
    using KingSurvival.GameLogic.Models;

    /// <summary>
    /// A class containing the global constants for the game.
    /// </summary>
    public class GameConstants
    {
        /// <summary>
        /// Possible commands for the king.
        /// </summary>
        public const string RegexKingPattern = @"(K(U|D)(L|R)";

        /// <summary>
        /// Possible commands for the pawns.
        /// </summary>
        public const string RegexPawnPattern = @"^(A|B|C|D)D(L|R)$";

        /// <summary>
        /// Maximum number of rows for the game.
        /// </summary>
        public const int MaxNumberOfRows = 8;

        /// <summary>
        /// Maximum number of columns for the game.
        /// </summary>
        public const int MaxNumberOfCols = 17;

        /// <summary>
        /// Minimum number of rows for the game.
        /// </summary>
        public const int MinNumberOfRows = 0;

        /// <summary>
        /// Minimum number of rows for the game.
        /// </summary>
        public const int MinNumberOfCols = 0;

        /// <summary>
        /// Initial row for the board.
        /// </summary>
        public const int BoardRows = 8;

        /// <summary>
        /// Initial columns for the board.
        /// </summary>
        public const int BoardCols = 8;

        /// <summary>
        /// The cell symbol.
        /// </summary>
        public const string Cell = " ";

        /// <summary>
        /// Initial position X for pawn A.
        /// </summary>
        public const int FirstPawnInitialRow = 0;

        /// <summary>
        /// Initial position Y for pawn A.
        /// </summary>
        public const int FirstPawnInitialCol = 0;

        /// <summary>
        /// Initial position X for pawn B.
        /// </summary>
        public const int SecondPawnInitialRow = 0;

        /// <summary>
        /// Initial position Y for pawn B.
        /// </summary>
        public const int SecondPawnInitialCol = 2;

        /// <summary>
        /// Initial position X for pawn C.
        /// </summary>
        public const int ThirdPawnInitialRow = 0;
        
        /// <summary>
        /// Initial position Y for pawn C.
        /// </summary>
        public const int ThirdPawnInitialCol = 4;

        /// <summary>
        /// Initial position X for pawn D.
        /// </summary>
        public const int FourthPawnInitialRow = 0;
        
        /// <summary>
        /// Initial position Y for pawn D.
        /// </summary>
        public const int FourthPawnInitialCol = 6;

        /// <summary>
        /// Initial position X for the king.
        /// </summary>
        public const int KingInitialRow = 7;
        
        /// <summary>
        /// Initial position Y for the king.
        /// </summary>
        public const int KingInitialCol = 3;

        public static readonly bool[,] PawnExistingMoves =
       {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        public static readonly IPosition[] BoardEdges =
        {
            new Position(2, 4), new Position(2, 18), new Position(9, 4), new Position(9, 18)
        };

        /// <summary>
        /// Field on the board.
        /// </summary>
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

        /// <summary>
        /// Possible commands for the king.
        /// </summary>
        public static readonly string[] KingPossibleDirections = { "KUL", "KUR", "KDL", "KDR" };
        public static readonly bool[] KingExistingMoves = { true, true, true, true };

        /// <summary>
        /// Possible commands for the Pawn A.
        /// </summary>
        public static readonly string[] PawnAPossibleDirections = { "ADL", "ADR" };

        /// <summary>
        /// Possible commands for the Pawn B.
        /// </summary>
        public static readonly string[] PawnBPossibleDirections = { "BDL", "BDR" };

        /// <summary>
        /// Possible commands for the Pawn C.
        /// </summary>
        public static readonly string[] PawnCPossibleDirections = { "CDL", "CDR" };

        /// <summary>
        /// Possible commands for the Pawn D.
        /// </summary>
        public readonly string[] PawnDPossibleDirections = { "DDL", "DDR" };
    }
}