using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class GameOverMenu : Form
    {
        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;

            
                WinnerText.Text = GetWinnerText(result.Winner);
                ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
            
           
        }

        private string GetWinnerText(Player winner)
        {
            string result;
            switch (winner)
            {
                case Player.White:
                    result = "Alb a castigat!";
                    break;
                case Player.Black:
                    result = "Negru a castigat!";
                    break;
                default:
                    result = "Egalitate";
                    break;
            }

            return result;
        }

        private string PlayerString(Player player)
        {
            string play;
            switch (player)
            {
                case Player.White:
                    play = "Alb";
                    break;
                case Player.Black:
                    play = "Negru";
                    break;
                default:
                    play = "";
                    break;
            }

            return play;
        }

        private string GetReasonText(EndReason reason,Player currentPlayer) 
        {
            string result;
            switch (reason)
            {
                case EndReason.Stalemate:
                    result = $"Egaitate - {PlayerString(currentPlayer)} nu se poate misca";
                    break;
                case EndReason.Checkmate:
                    result = $"Sah Mat - {PlayerString(currentPlayer)} nu se poate misca";
                    break;
                case EndReason.FiftyMoveRule:
                    result = $"Egalitate - Regula de 50 de mutari";
                    break;
                case EndReason.InsufficientMaterial:
                    result = $"Egalitate - Piese insuficiente";
                    break;
                case EndReason.RanOutOfTime:
                    result = $"Sah Mat - {PlayerString(currentPlayer)} nu mai are timp";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
