using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;
        public Pawn(Player color) 
        { 
            Color = color;
            Direction direction = new Direction(0, 0);

            if (color == Player.White)
            {
                forward = direction.Nord;
            }
            else if (color == Player.Black)
            {
                forward = direction.Sud;
            }
        }

        public override Piece Copy()
        {
            Pawn copy=new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private bool CanMoveTo(Position pos,Board board) 
        {
            return board.IsInside(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos,Board board)
        {
            if(!board.IsInside(pos) || board.IsEmpty(pos)) 
            {
                return false;
            }
            return board[pos].Color != Color;
        }

        private IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
            yield return new PawnPromotion(from, to, PieceType.Queen);

        }

        private IEnumerable<Move> ForwardMoves(Position from,Board board)
        {
            Position oneMovePos = from.Add( forward);
            if (CanMoveTo(oneMovePos, board))
            {
                if (oneMovePos.Row == 0 || oneMovePos.Row == 7)
                {
                    foreach (Move promMove in PromotionMoves(from, oneMovePos))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new NormalMove(from, oneMovePos);
                }

                Position twoMovesPos = oneMovePos.Add( forward);

                if(!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new DoublePawn(from,twoMovesPos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            Direction direction = new Direction(0, 0); // Create an instance based on your needs

            PlayerExtensions playerExtensions = new PlayerExtensions(board[from].Color);
            foreach (Direction dir in new Direction[] { direction.West, direction.Est })
            {
                Position to = from.Add(forward).Add(dir);

                if (to == board.GetPawnSkipPosition(playerExtensions.GetOpponent()))
                {
                    yield return new EnPassant(from, to);
                }
                else if (CanCaptureAt(to, board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move promMove in PromotionMoves(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from,board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
