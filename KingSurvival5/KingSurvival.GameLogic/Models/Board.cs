namespace KingSurvival.GameLogic.Models
{
    using KingSurvival.GameLogic.Commons;

    /// <summary>
    /// A Singleton class for the board 
    /// </summary>
    public class Board
    {
        private static readonly object SyncLock = new object();
        private static volatile Board instance;

        /// <summary>
        /// A private constructor for the Singleton implementation
        /// </summary>
        private Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Board(GameConstants.MaxNumberOfCols, GameConstants.MaxNumberOfRows);
                        }
                    }
                }

                return instance;
            }
        }
    }
}
