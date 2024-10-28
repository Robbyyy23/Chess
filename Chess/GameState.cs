using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class GameState
    {
        public Board Board { get; }
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;

        public int WhiteCountdownSeconds = 10;
        public int BlackCountdownSeconds = 10;

        private int noCaptureOrPawnMoves = 0;
        public Player TimerExpiredPlayer { get; set; } = Player.None;


        public GameState(Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Move move)
        {
            Board.SetPawnSkipPositon(CurrentPlayer, null);
            bool captureOrPawn = move.Execute(Board);

            if (captureOrPawn)
            {
                noCaptureOrPawnMoves=0;
            }
            else
            {
                noCaptureOrPawnMoves++;
            }

            PlayerExtensions playerExtensions = new PlayerExtensions(CurrentPlayer);
            CurrentPlayer = playerExtensions.Opponent();
            CheckForGameOver();

        }

        public IEnumerable<Move> AllLegalMovesFor(Player player)
        {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });
            return moveCandidates.Where(move => move.IsLegal(Board));
        }
        private void CheckForGameOver()
        {
            CheckForTimeout();
            if (!AllLegalMovesFor(CurrentPlayer).Any())
            {
                if (Board.IsInCheck(CurrentPlayer))
                {
                    PlayerExtensions playerExtensions = new PlayerExtensions(CurrentPlayer);
                    Player opponent = playerExtensions.Opponent();
                    Result = new Result(opponent, EndReason.Checkmate);
                }
                else
                {
                    Result = new Result(Player.None, EndReason.Stalemate);
                }
            }
            else if (Board.InsufficientMaterial())
            {
                Result = new Result(Player.None, EndReason.InsufficientMaterial);
            }
            else if (FiftyMoveRule())
            {
                Result = new Result(Player.None, EndReason.FiftyMoveRule);
            }
        }
        private void CheckForTimeout()
        {
            if (WhiteCountdownSeconds <= 0)
            {
                Result = new Result(Player.Black, EndReason.RanOutOfTime);
                TimerExpiredPlayer = Player.White;
            }
            else if (BlackCountdownSeconds <= 0)
            {
                Result = new Result(Player.White, EndReason.RanOutOfTime);
                TimerExpiredPlayer = Player.Black;
            }
        }

        public void UpdateWhiteCountdownSeconds(int seconds)
        {
            WhiteCountdownSeconds = seconds;
        }

        public void UpdateBlackCountdownSeconds(int seconds)
        {
            BlackCountdownSeconds = seconds;
        }
        public void SetResult(Result result)
        {
            Result = result;
        }

        public bool IsGameOver()
        {
            return Result != null;
        }

        public bool FiftyMoveRule()
        {
            int fullMoves = noCaptureOrPawnMoves / 2;
            return fullMoves == 50;
        }
    }
}