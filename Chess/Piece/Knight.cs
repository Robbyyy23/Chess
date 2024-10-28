using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }
        public Knight(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public IEnumerable<Position> PotentialToPosition(Position from)
        {
            Direction direction = new Direction(0,0);

            foreach (Direction vDir in new Direction[] { direction.Nord, direction.Sud })
            {
                foreach (Direction hDir in new Direction[] { direction.Est, direction.West })
                {
                    yield return from.Add(vDir.Multiply(2)).Add(hDir);
                    yield return from.Add(hDir.Multiply(2)).Add(vDir);
                }
            }
        }

        public IEnumerable<Position> MovePositions(Position from,Board board)
        {
            return PotentialToPosition(from).Where(pos => board.IsInside(pos)
                && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from,board).Select(to=> new NormalMove(from,to));
        }
    }
}
