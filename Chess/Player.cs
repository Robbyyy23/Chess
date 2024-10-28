namespace Chess
{
    public enum Player
    {
        None,
        White,
        Black
    }
    public class PlayerExtensions
    {
        private Player player;
        public PlayerExtensions(Player player) 
        {
            this.player = player;
        }

        public Player Opponent()
        {
            switch (player)
            {
                case Player.White:
                    return Player.Black;
                case Player.Black:
                    return Player.White;
                default:
                    return Player.None;
            }
        }
        public Player GetOpponent()
        {
            return (player == Player.White) ? Player.Black : Player.White;
        }
    }
}
