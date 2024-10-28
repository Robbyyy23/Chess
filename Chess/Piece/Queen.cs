using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        public readonly Direction[] dirs = new Direction[]
        {
           new Direction(-1, 0),  // Nord Direction.Nord,
           new Direction(1, 0), // Sud Direction.Sud,
           new Direction(0, 1),   // Est Direction.Est,
           new Direction(0, -1),   // West Direction.West,
           new Direction(-1, 1),  // NordEst  Direction.NordEst,
           new Direction(-1, -1), // NordWest Direction.NordWest,
           new Direction(1, 1),   // SudEst Direction.SudEst,
           new Direction(1, -1)   // SudWest Direction.SudWest
        };
        public Queen(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
