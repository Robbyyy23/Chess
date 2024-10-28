using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class fChessB : Form
    {
        private readonly fMain fMain;
        private const int DIMENSIUNE = 60;
        private readonly PictureBox[,] pieceImages = new PictureBox[8, 8];
        private readonly Images images = new Images();
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
        private bool gameStarted = false;
        private Panel menuContainer;
        private GameState gameState;
        private Position selectedPos = null;
        private ChessCursors chessCursors;
        private const int TimerInterval = 1000;
        private Timer timerWhite;
        private Timer timerBlack;
        private int whiteCountdownSeconds;
        private int blackCountdownSeconds;
        private int tempCountdownSeconds;



        public fChessB(fMain f, int initialSeconds)
        {
            InitializeComponent();
            fMain = f;
            InitializeBoard();
            InitializeMenuControl();
            gameState = new GameState(Player.White, new Board().Initial());
            DrawBoard(gameState.Board);
            chessCursors = new ChessCursors();
            SetCursor(gameState.CurrentPlayer);
            tempCountdownSeconds = initialSeconds;
            whiteCountdownSeconds = initialSeconds;
            blackCountdownSeconds = initialSeconds;

            InitializeTimers();
            DisablePieces();
        }



        private void InitializeBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    PictureBox pbimg = new PictureBox();
                    pieceImages[r, c] = pbimg;
                    pbimg.Size = new Size(DIMENSIUNE, DIMENSIUNE);
                    pbimg.Location = new Point(c * DIMENSIUNE, r * DIMENSIUNE);
                    pbimg.SizeMode = PictureBoxSizeMode.Zoom;
                    pbimg.BackColor = Color.Transparent;
                    pbimg.MouseDown += PictureBox_MouseDown;

                    pbChessB.Controls.Add(pbimg);


                }
            }

        }

        private void InitializeTimers()
        {
            timerWhite = new Timer();
            timerWhite.Interval = TimerInterval;
            timerWhite.Tick += WhiteTimer_Tick;

            timerBlack = new Timer();
            timerBlack.Interval = TimerInterval;
            timerBlack.Tick += BlackTimer_Tick;
            UpdateTimerLabels();
        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = gameState.Board[r, c];
                    pieceImages[r, c].Image = images.GetImage(piece);
                }
            }

        }

        private void PictureBox_MouseDown(object sender, EventArgs e)
        {
            if (IsMenuOnScreen())
            {
                return;
            }
            PictureBox clickedPictureBox = (PictureBox)sender;
            int row = clickedPictureBox.Location.Y / DIMENSIUNE;
            int col = clickedPictureBox.Location.X / DIMENSIUNE;
            Position clickedPosition = new Position(row, col);

            if (selectedPos == null)
            {
                HideHighlights();
                OnFromPositionSelected(clickedPosition);
            }
            else
            {
                OnToPositionSelected(clickedPosition);
            }


            DrawBoard(gameState.Board);
        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();
            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }

        }

        private void OnFromPositionSelected(Position pos)
        {
            Piece clickedPiece = gameState.Board[pos];
            IEnumerable<Move> moves = gameState.LegalMovesForPiece(pos);

            if (moves.Any())
            {
                selectedPos = pos;
                CacheMoves(moves);

                ShowHighlights();
            }
        }

        private void OnToPositionSelected(Position pos)
        {
            selectedPos = null;
            HideHighlights();


            if (moveCache.TryGetValue(pos, out Move move))
            {
                if (move.Type == MoveType.PawnPromotion)
                {
                    HandlePromotion(move.FromPos, move.ToPos);
                }
                else
                {
                    HandleMove(move);
                }

            }
        }
        private void HandleMove(Move move)
        {
            gameState.MakeMove(move);
            DrawBoard(gameState.Board);
            SetCursor(gameState.CurrentPlayer);

            if (gameState.IsGameOver())
            {
                ShowGameOver();
            }

            if (gameState.CurrentPlayer == Player.White)
            {
                timerWhite.Start();
                timerBlack.Stop();
            }
            else
            {
                timerBlack.Start();
                timerWhite.Stop();
            }


        }

        private void HandlePromotion(Position from, Position to)
        {
            pieceImages[to.Row, to.Column].BackgroundImage = images.GetImage(gameState.CurrentPlayer, PieceType.Pawn);
            pieceImages[to.Row, to.Column].BackgroundImage = null;
            PromotionMenu promMenu = new PromotionMenu(gameState.CurrentPlayer);


            promMenu.PieceSelected += type =>
            {
                menuContainer.Controls.Clear();
                Move promMove = new PawnPromotion(from, to, type);

                HandleMove(promMove);
            };
            promMenu.ShowDialog();
        }

        private void ShowHighlights()
        {
            foreach (Position to in moveCache.Keys)
            {
                pieceImages[to.Row, to.Column].BackColor = Color.Green;
                pieceImages[to.Row, to.Column].BorderStyle = BorderStyle.FixedSingle;
                pieceImages[to.Row, to.Column].ForeColor = Color.Black;
            }
        }

        private void HideHighlights()
        {
            foreach (Position to in moveCache.Keys)
            {
                pieceImages[to.Row, to.Column].BackColor = Color.Transparent;
                pieceImages[to.Row, to.Column].BorderStyle = BorderStyle.None;

            }
        }

        private void SetCursor(Player player)
        {
            if (player == Player.White)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = chessCursors.BlackCursor;
            }
        }
        private void InitializeMenuControl()
        {
            menuContainer = new Panel();
            menuContainer.Name = "MenuContainer";
            Controls.Add(menuContainer);
        }

        private bool IsMenuOnScreen()
        {
            return menuContainer.Controls.Count > 0;
        }

        private void ShowGameOver()
        {
            GameOverMenu gameOverMenu = new GameOverMenu(gameState);
            gameOverMenu.OptionSelected += option =>
            {
                if (option == Option.Restart)
                {
                    menuContainer.Controls.Clear();
                    gameOverMenu.Close();
                    RestartGame();
                    gameStarted = false;
                    StopTimers();
                    DisablePieces();
                }
                else
                {
                    Application.Exit();
                }
            };
            gameOverMenu.ShowDialog();
        }


        private void RestartGame()
        {
            HideHighlights();
            moveCache.Clear();
            gameState = new GameState(Player.White, new Board().Initial());
            ResetTimers();
            DrawBoard(gameState.Board);
            SetCursor(gameState.CurrentPlayer);
        }

        private void ResetTimers()
        {
            whiteCountdownSeconds = tempCountdownSeconds;
            blackCountdownSeconds = tempCountdownSeconds;


            UpdateTimerLabels();

            if (gameState.CurrentPlayer == Player.White)
            {
                if (timerWhite != null)
                {
                    timerWhite.Start();
                }
            }
            else
            {
                if (timerBlack != null)
                {
                    timerBlack.Start();
                }
            }
        }
        private void WhiteTimer_Tick(object sender, EventArgs e)
        {
            if (gameState.CurrentPlayer == Player.White)
            {
                whiteCountdownSeconds--;
                gameState.UpdateWhiteCountdownSeconds(whiteCountdownSeconds);
                UpdateTimerLabels();
            }
            if (whiteCountdownSeconds <= 0 )
            {
                StopTimers();
                gameState.SetResult(new Result(Player.Black, EndReason.RanOutOfTime));
                gameState.TimerExpiredPlayer = Player.White;
                ShowGameOver();
            }
        }

        private void BlackTimer_Tick(object sender, EventArgs e)
        {
            if (gameState.CurrentPlayer == Player.Black)
            {
                blackCountdownSeconds--;
               gameState.UpdateBlackCountdownSeconds(blackCountdownSeconds);
                UpdateTimerLabels();
            }
            if (blackCountdownSeconds <= 0)
            {
                StopTimers();
                gameState.SetResult( new Result(Player.White, EndReason.RanOutOfTime));
                gameState.TimerExpiredPlayer = Player.Black;
                ShowGameOver();
            }
        }

        private void StopTimers()
        {
            timerWhite.Stop();
            timerBlack.Stop();
        }
        private void UpdateTimerLabels()
        {
            lWhiteTimer.Text = $"White: {FormatTime(whiteCountdownSeconds)}";
            lBlackTimer.Text = $"Black: {FormatTime(blackCountdownSeconds)}";
        }

        private string FormatTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
        private void DisablePieces()
        {
            foreach (PictureBox pb in pieceImages)
            {
                pb.Enabled = false;
            }
        }

        private void EnablePieces()
        {
            foreach (PictureBox pb in pieceImages)
            {
                pb.Enabled = true;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
            gameStarted = false;
            StopTimers();
            DisablePieces();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                gameStarted = false;
                StopTimers();
                HideHighlights();
                DisablePieces();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                gameStarted = true;

                if (gameState.CurrentPlayer == Player.White)
                {
                    if (timerWhite != null)
                    {
                        timerWhite.Start();
                    }
                }
                else
                {
                    if (timerBlack != null)
                    {
                        timerBlack.Start();
                    }
                }

                EnablePieces();
            }
        }
    }
}