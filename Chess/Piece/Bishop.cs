using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.Bishop;
        public override Player Color { get; }

        public readonly Direction[] dirs = new Direction[]
        {
           new Direction(-1, 1),  // NordEst  Direction.NordEst,
           new Direction(-1, -1), // NordWest Direction.NordWest,
           new Direction(1, 1),   // SudEst Direction.SudEst,
           new Direction(1, -1)   // SudWest Direction.SudWest
        };
        public Bishop(Player color) 
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from ,Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to=>new NormalMove(from,to));
        }
    }
}
