using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
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
        public King(Player color)
        {
            Color = color;
        }

        private bool IsUnmovedRook(Position pos, Board board)
        {
            if (board.IsEmpty(pos))
            {
                return false;
            }

            Piece piece = board[pos];
            return piece.Type == PieceType.Rook && !piece.HasMoved;
        }

        private bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos => board.IsEmpty(pos));
        }

        private bool CanCastleKingSide(Position from,Board board)
        {
            if (HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPositions = new Position[] { new Position(from.Row,5),new Position(from.Row,6) };

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        private bool CanCastleQueenSide(Position from, Board board)
        {
            if (HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(from.Row, 0);
            Position[] betweenPositions = new Position[] { new Position(from.Row, 1), new Position(from.Row, 2), new Position(from.Row, 3) };
            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from,Board board)
        {
            foreach(Direction dir in dirs)
            {
                Position to=from.Add(dir);
                if (!board.IsInside(to))
                {
                    continue;
                }
                if(board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from,Board board)
        {
            foreach(Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from,to);
            }
            
            if(CanCastleKingSide(from, board))
            {
                yield return new Castle(MoveType.CastleKs, from);
            }

            if (CanCastleQueenSide(from, board))
            {
                yield return new Castle(MoveType.CastleQs, from);
            }

        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return MovePositions(from, board).Any(to =>
            {
                Piece piece = board[to];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
