namespace KingSurvival.GameLogic.Commons
{
    public class GameConstants
    {
        public const string RegexKingPattern = @"(K(U|D)(L|R)";
        public const string RegexPawnPattern = @"^(A|B|C|D)D(L|R)$";

        public const int MaxNumberOfRows = 8;
        public const int MaxNumberOfCols = 8;
        public const int MinNumberOfRows = 0;
        public const int MinNumberOfCols = 0;

        public const int BoardHeight = 8;
        public const int BoardWidth = 17;

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



    }
}
