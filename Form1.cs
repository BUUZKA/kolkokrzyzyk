using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolkokrzyzyk
{

    enum Gracz
    {
        Krzyzyk,
        Kolko,
    }
    public partial class Form1 : Form
    {
        Gracz gracz;
        public Form1()
        {
            InitializeComponent();
            gracz = Gracz.Krzyzyk;
            currentPlayerLabel.Text = "Krzyzyk";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Mark(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            if (gracz == Gracz.Krzyzyk)
            {
                senderButton.Text = "X";
                gracz = Gracz.Kolko;
            }
            else
            {
                senderButton.Text = "O";
                gracz = Gracz.Krzyzyk;
            }
            if (warunekWygranej())
                pokazWygranego();
            changeLabel();


        }
        public void changeLabel()
        {
            if (gracz == Gracz.Krzyzyk)
            {
                currentPlayerLabel.Text = "Krzyżyk";
            }
            else
            {
                currentPlayerLabel.Text = "Kółko";
            }
        }
        public bool warunekWygranej()
        {
            if (String.Compare(tl.Text, cl.Text) == 0 && String.Compare(cl.Text, bl.Text) == 0)
            {
                return true;
            }
            return false;
        }
        public void pokazWygranego()
        {
            Form2 victoryScreen = new Form2(this);
            victoryScreen.wygrany = tl.Text;
            victoryScreen.Show();
        }
        public void clearBoard()
        {
            TableLayoutControlCollection buttons = tableLayoutPanel1.Controls;

            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] is Button)
                    buttons[i].Text = "";
            }

        }
    }
}
