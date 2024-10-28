using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class PromotionMenu : Form
    {
        public event Action<PieceType> PieceSelected;
        public PromotionMenu(Player player)
        {
            InitializeComponent();

            Images images = new Images();
            pbQueen.BackgroundImage = images.GetImage(player, PieceType.Queen);
            pbBishop.BackgroundImage = images.GetImage(player, PieceType.Bishop);
            pbRook.BackgroundImage = images.GetImage(player, PieceType.Rook);
            pbKnight.BackgroundImage = images.GetImage(player, PieceType.Knight);

        }

        private void pbQueen_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Queen);
            Close();
        }

        private void pbBishop_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Bishop);
            Close();
        }

        private void pbRook_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Rook);
            Close();
        }

        private void pbKnight_Click(object sender, EventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Knight);
            Close();
        }
    }
}
