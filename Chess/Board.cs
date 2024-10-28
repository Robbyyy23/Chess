using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Board
    {
        public readonly Piece[,] pieces=new Piece[8,8];

        private readonly Dictionary<Player,Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            {Player.White,null}, 
            {Player.Black,null}
        };
        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Position pos]
        {
            get { return this[pos.Row,pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }

        public void SetPawnSkipPositon(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }

        public Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for (int c = 0; c < 8; c++)
            {
                this[1, c] = new Pawn(Player.Black);
                this[6, c] = new Pawn(Player.White);

            }

        }
        public bool IsInside(Position poz)
        {
            return poz.Row>=0 && poz.Row<8 && poz.Column>=0 && poz.Column<8;
        }

        public bool IsEmpty(Position poz)
        {
            return this[poz]==null;
        }

        public IEnumerable<Position> PiecePositions()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Position pos = new Position(r, c);
                    if (!IsEmpty(pos)) 
                    { 
                        yield return pos; 
                    }
                }
            }
        }

        public IEnumerable<Position> PiecePositionsFor(Player player)
        {
            return PiecePositions().Where(pos => this[pos].Color==player);
        }

        public bool IsInCheck(Player currentPlayer)
        {
            Player opponentPlayer = (currentPlayer == Player.White) ? Player.Black : Player.White;

            return PiecePositionsFor(opponentPlayer).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.CanCaptureOpponentKing(pos, this);
            });
        }

        public Board Copy()
        {
            Board copy = new Board();

            foreach(Position pos in PiecePositions())
            {
                copy[pos]= this[pos].Copy();
            }
            return copy;
        }

        public Counting CountPieces()
        {
            Counting counting = new Counting();

            foreach(Position pos in PiecePositions())
            {
                Piece piece= this[pos];
                counting.Increment(piece.Color, piece.Type);
            }
            return counting;
        }

        public bool InsufficientMaterial()
        {
            Counting counting= CountPieces();

            return IsKingVKing(counting) || IsKingBishopVKing(counting)|| 
                IsKingKnightVKing(counting) ||IsKingBishopVKingBishop(counting);
        }

        private bool IsKingVKing(Counting counting)
        {
            return counting.TotalCount == 2;
        }

        private bool IsKingBishopVKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.Bishop) == 1 || counting.Black(PieceType.Bishop) == 1);
        }

        private bool IsKingKnightVKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.Knight) == 1 || counting.Black(PieceType.Knight) == 1);
        }
        private bool IsKingBishopVKingBishop(Counting counting)
        {
            if(counting.TotalCount != 4)
            {
                return false;
            }
            if(counting.White(PieceType.Bishop) != 1 || counting.Black(PieceType.Bishop) != 1)
            {
                return false;
            }

            Position wBishopPos=FindPiece(Player.White,PieceType.Bishop);
            Position bBishopPos = FindPiece(Player.Black, PieceType.Bishop);

            return wBishopPos.SquareColor() == bBishopPos.SquareColor();
        }

        private Position FindPiece(Player color, PieceType type)
        {
            return PiecePositionsFor(color).First(pos => this[pos].Type == type);
        }
    }
}
