using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Rook : Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        public readonly Direction[] dirs = new Direction[]
        {
           new Direction(-1, 0),  // Nord Direction.Nord,
           new Direction(1, 0), // Sud Direction.Sud,
           new Direction(0, 1),   // Est Direction.Est,
           new Direction(0, -1),   // West Direction.West,
        };
        public Rook(Player color)
        {
            Color = color;
        }
        
        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
