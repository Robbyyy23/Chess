using System;
using System.Windows.Forms;

namespace Chess
{
    public partial class fMain : Form
    {
        fChessB fChess;
        public fMain()
        {
            InitializeComponent();

            listBoxTimeOptions.Items.Add("Optiunea 1 (10 Minute)");
            listBoxTimeOptions.Items.Add("Optiunea 2 (5 Minute)");
            listBoxTimeOptions.Items.Add("Optiunea 3 (3 Minute)");
            listBoxTimeOptions.Items.Add("Optiunea 4 (10 Secunde)");
            listBoxTimeOptions.SelectedIndex = 0;


            fChess = new fChessB(this, GetInitialSeconds());
        }
        private int GetInitialSeconds()
        {
            string selectedItem = listBoxTimeOptions.SelectedItem as string;

            if (selectedItem != null)
            {
                
                if (selectedItem.Contains("Optiunea 1"))
                {
                    return 600;
                }
                else if (selectedItem.Contains("Optiunea 2"))
                {
                    return 300;
                }
                else if (selectedItem.Contains("Optiunea 3"))
                {
                    return 180;
                }
                else if (selectedItem.Contains("Optiunea 4"))
                {
                    return 10;
                }
            }
            return 100;
        }

        private void FChess_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (fChess != null)
            {
                fChess = new fChessB(this, GetInitialSeconds());
                fChess.FormClosed += FChess_FormClosed;
            }
            fChess.Show();
        }

    }
}
