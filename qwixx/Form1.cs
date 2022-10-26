using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qwixx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        Button[] arrayRijRood = new Button[12
];
        Button[] arrayRijGeel = new Button[12];
        Button[] arrayRijGroen = new Button[12];
        Button[] arrayRijBlauw = new Button[12];
        Button[] arrayRijRood2 = new Button[12];
        Button[] arrayRijGeel2 = new Button[12];
        Button[] arrayRijGroen2 = new Button[12];
        Button[] arrayRijBlauw2 = new Button[12];
        int intHoeVer;
        bool turn = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            kaartOpScherm(arrayRijRood, 50, 40, Color.Red, 2, 2);
            kaartOpScherm(arrayRijGeel, 50, 90, Color.Yellow, 2, 2);
            kaartOpScherm(arrayRijGroen, 50, 140, Color.Green, 12, 12);
            kaartOpScherm(arrayRijBlauw, 50, 190, Color.Blue, 12, 12);
            kaartOpScherm(arrayRijRood2, 850, 40, Color.Red, 2, 2);
            kaartOpScherm(arrayRijGeel2, 850, 90, Color.Yellow, 2, 2);
            kaartOpScherm(arrayRijGroen2, 850, 140, Color.Green, 12, 12);
            kaartOpScherm(arrayRijBlauw2, 850, 190, Color.Blue, 12, 12);
            disableButtons(arrayRijRood2, Color.Red);
            disableButtons(arrayRijGeel2, Color.Yellow);
            disableButtons(arrayRijGroen2, Color.Green);
            disableButtons(arrayRijBlauw2, Color.Blue);
            enableButtons(arrayRijRood, Color.Red);
            enableButtons(arrayRijGeel, Color.Yellow);
            enableButtons(arrayRijGroen, Color.Green);
            enableButtons(arrayRijBlauw, Color.Blue);
        }

        public void kaartOpScherm(Button[] arraybutton, int xPos, int ypos, Color color, int a, int b)
        {
            for (int i = 1; i < arraybutton.Length; i++)
            {
                arraybutton[i] = new Button();
                arraybutton[i].BackColor = color;
                arraybutton[i].TextAlign = ContentAlignment.MiddleCenter;
                arraybutton[i].Text = a.ToString();
                arraybutton[i].Tag = i;
                arraybutton[i].Font = new Font("Serif", 18, FontStyle.Bold);
                arraybutton[i].Size = new Size(50, 50);
                arraybutton[i].Location = new Point(xPos + i * 50, ypos);
                this.Controls.Add(arraybutton[i]);
                if (b == 2)
                {
                    a++;
                }
                else
                {
                    a--;
                }
                arraybutton[i].Click += ButtonOnClick;
            }


        }

        public void ButtonOnClick(object sender, EventArgs e)
        {
            Button vakje = (Button)sender;
            Button vakje2 = (Button)sender;
            int tellerRood = 0;
            int tellerGeel = 0;
            int tellerGroen = 0;
            int tellerBlauw = 0;
            int tellerRood2 = 0;
            int tellerGeel2 = 0;
            int tellerGroen2 = 0;
            int tellerBlauw2 = 0;
            int getalenVak1, getalenVak2;
            int getalRood = 0;
            int getalGeel = 0;
            int getalGroen = 0;
            int getalBlauw = 0;
            int getalRood2 = 0;
            int getalGeel2 = 0;
            int getalGroen2 = 0;
            int getalBlauw2 = 0;
            intHoeVer = int.Parse(vakje.Tag.ToString());
            if (turn == true)
            {
                VeranderKleur(arrayRijRood, Color.Red, vakje, Color.LightPink);
                VeranderKleur(arrayRijGeel, Color.Yellow, vakje, Color.LightYellow);
                VeranderKleur(arrayRijGroen, Color.Green, vakje, Color.LightGreen);
                VeranderKleur(arrayRijBlauw, Color.Blue, vakje, Color.LightBlue);
            }
            else
            {
                VeranderKleur(arrayRijRood2, Color.Red, vakje2, Color.LightPink);
                VeranderKleur(arrayRijGeel2, Color.Yellow, vakje2, Color.LightYellow);
                VeranderKleur(arrayRijGroen2, Color.Green, vakje2, Color.LightGreen);
                VeranderKleur(arrayRijBlauw2, Color.Blue, vakje2, Color.LightBlue);
            }
            VakjeTellen(tellerRood, arrayRijRood, Color.LightPink, txtRood);
            VakjeTellen(tellerGeel, arrayRijGeel, Color.LightYellow, txtGeel);
            VakjeTellen(tellerGroen, arrayRijGroen, Color.LightGreen, txtGroen);
            VakjeTellen(tellerBlauw, arrayRijBlauw, Color.LightBlue, txtBlauw);

            VakjeTellen(tellerRood2, arrayRijRood2, Color.LightPink, txtRood2);
            VakjeTellen(tellerGeel2, arrayRijGeel2, Color.LightYellow, txtGeel2);
            VakjeTellen(tellerGroen2, arrayRijGroen2, Color.LightGreen, txtGroen2);
            VakjeTellen(tellerBlauw2, arrayRijBlauw2, Color.LightBlue, txtBlauw2);

            try { 
                getalRood = int.Parse(txtRood.Text);
            } catch { }
            try
            {
                getalGeel = int.Parse(txtGeel.Text);
            } catch { }
            try
            {
                getalGroen = int.Parse(txtGroen.Text);
            } catch { }
            try
            {
                getalBlauw = int.Parse(txtBlauw.Text);
            } catch { }
            try
            {
                getalRood2 = int.Parse(txtRood2.Text);
            } catch { }
            try
            {
                getalGeel2 = int.Parse(txtGeel2.Text);
            } catch { }
            try
            {
                getalGroen2 = int.Parse(txtGroen2.Text);
            } catch { }
            try
            {
                getalBlauw2 = int.Parse(txtBlauw2.Text);
            } catch { }

            getalenVak1 = getalRood + getalGeel + getalGroen + getalBlauw;
            txtResultaat1.Text = getalenVak1.ToString();
            getalenVak2 = getalRood2 + getalGeel2 + getalGroen2 + getalBlauw2;
            txtResultaat2.Text = getalenVak2.ToString();

        }

        public void VakjeTellen(int teller, Button[] arrayButton, Color kleur, TextBox text)
        {
            for (int i = 1; i < arrayButton.Length; i++)
            {
                if (arrayButton[i].BackColor == kleur)
                {
                    teller++;
                    switch (teller)
                    {
                        case 1:
                            text.Text = 1.ToString();
                            break;
                        case 2:
                            text.Text = 3.ToString();
                            break;
                        case 3:
                            text.Text = 6.ToString();
                            break;
                        case 4:
                            text.Text = 10.ToString();
                            break;
                        case 5:
                            text.Text = 15.ToString();
                            break;
                        case 6:
                            text.Text = 21.ToString();
                            break;
                        case 7:
                            text.Text = 28.ToString();
                            break;
                        case 8:
                            text.Text = 36.ToString();
                            break;
                        case 9:
                            text.Text = 45.ToString();
                            break;
                        case 10:
                            text.Text = 55.ToString();
                            break;
                        case 11:
                            text.Text = 66.ToString();
                            break;
                        case 12:
                            text.Text = 78.ToString();
                            break;
                    }
                }
            }
        }
        public void VeranderKleur(Button[] arrayButton, Color kleur, Button vakje, Color kleur2)
        {


            if (vakje.BackColor == kleur)
            {
                for (int i = 1; i <= intHoeVer; i++)
                {
                    if (arrayButton[i].BackColor == kleur)
                    {
                        arrayButton[i].Enabled = false;
                        arrayButton[i].BackColor = TransparencyKey;
                    }
                }
                vakje.BackColor = kleur2;
            }
        }

        public void disableButtons(Button[] arrayButton, Color kleur)
        {
            for (int i = 1; i < arrayButton.Length; i++)
            {
                if (arrayButton[i].BackColor == kleur)
                {
                    arrayButton[i].Enabled = false;
                }
            }
        }
        public void enableButtons(Button[] arrayButton, Color Kleur)
        {
            for (int i = 1; i < arrayButton.Length; i++)
            {
                if (arrayButton[i].BackColor == Kleur)
                {
                    arrayButton[i].Enabled = true;
                }
            }
        }

        private void btnGooi_Click(object sender, EventArgs e)
        {
            turn = !turn;
            if (turn == true)
            {
                disableButtons(arrayRijRood, Color.Red);
                disableButtons(arrayRijGeel, Color.Yellow);
                disableButtons(arrayRijGroen, Color.Green);
                disableButtons(arrayRijBlauw, Color.Blue);
                enableButtons(arrayRijRood2, Color.Red);
                enableButtons(arrayRijGeel2, Color.Yellow);
                enableButtons(arrayRijGroen2, Color.Green);
                enableButtons(arrayRijBlauw2, Color.Blue);
            }
            else
            {
                disableButtons(arrayRijRood2, Color.Red);
                disableButtons(arrayRijGeel2, Color.Yellow);
                disableButtons(arrayRijGroen2, Color.Green);
                disableButtons(arrayRijBlauw2, Color.Blue);
                enableButtons(arrayRijRood, Color.Red);
                enableButtons(arrayRijGeel, Color.Yellow);
                enableButtons(arrayRijGroen, Color.Green);
                enableButtons(arrayRijBlauw, Color.Blue);
            }
        }
    }
}