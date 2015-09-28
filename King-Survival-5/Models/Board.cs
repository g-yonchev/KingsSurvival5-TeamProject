namespace Models
{
    public class Board
    {
        private static volatile Board instance;
        
        private static readonly object syncLock = new object();
        
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
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Board(8, 8);
                        }
                    }
                }
                return instance;
            }
        }
    }
}
