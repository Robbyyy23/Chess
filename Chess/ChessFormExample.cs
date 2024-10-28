// fChessB.cs

using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class fChessBEx : Form
    {
        private const int DIMENSIUNE = 60;
        private const int nrPatratele = 8;
        private PictureBox[,] mPiesePictureBox;
        private int elapsedTimeInSeconds = 0;
        string pathToPieces = "C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\";
        string[,] startingPosition = new string[,] {
                { "BR", "BN", "BB", "BQ", "BK", "BB", "BN", "BR" },
                { "BP", "BP", "BP", "BP", "BP", "BP", "BP", "BP" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "", "", "", "", "", "", "", "" },
                { "WP", "WP", "WP", "WP", "WP", "WP", "WP", "WP" },
                { "WR", "WN", "WB", "WQ", "WK", "WB", "WN", "WR" }
             };

        fMain fMain;
        public fChessBEx(fMain f)
        {
            InitializeComponent();
            fMain = f;

        }



        private void InitializeBoard()
        {
            mPiesePictureBox = new PictureBox[nrPatratele, nrPatratele];
            for (int c = 0; c < nrPatratele; c++)
            {
                for (int l = 0; l < nrPatratele; l++)
                {
                    PictureBox pbPieces = new PictureBox();
                    mPiesePictureBox[c, l] = pbPieces;

                    pbPieces.Size = new Size(DIMENSIUNE, DIMENSIUNE);
                    pbPieces.Location = new Point(c * DIMENSIUNE, l * DIMENSIUNE);
                    pbPieces.SizeMode = PictureBoxSizeMode.Zoom;
                    pbPieces.BackColor = Color.Transparent;
                    pbChessEx.Controls.Add(pbPieces);
                }
            }

            AddPieces();
        }



        private void AddPieces()
        {
            for (int c = 0; c < nrPatratele; c++)
            {
                for (int l = 0; l < nrPatratele; l++)
                {
                    
                    string pieceCode = startingPosition[l, c];
                    if (!string.IsNullOrEmpty(pieceCode))
                    {
                        string imagePath = $"{pathToPieces}{pieceCode}.png";
                        AddPiece(imagePath, c, l);
                    }
                }
            }
        }

        private void AddPiece(string imagePath, int column, int row)
        {
            ChessPiece piece = new ChessPiece(imagePath, column, row);
            DrawPiece(piece, column, row);
        }

        private void DrawPiece(ChessPiece piece, int column, int row)
        {
            PictureBox pictureBox = mPiesePictureBox[column, row];
            pictureBox.Image = Image.FromFile(piece.ImagePath);
            pictureBox.BringToFront();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            InitializeBoard();

            MainTimer.Start();
            MainTimer.Tick += MainTimer_Tick;

            textPWEx.Text = "Player 1";
            textPBEx.Text = "Player 2";
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;

            int minutes = elapsedTimeInSeconds / 60;
            int seconds = elapsedTimeInSeconds % 60;

            timePBEx.Text = $"{minutes:D2}:{seconds:D2}";
            timePWEx.Text = $"{minutes:D2}:{seconds:D2}";
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            fMain.Show();
        }
    }
}
