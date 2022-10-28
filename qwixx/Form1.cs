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
            KleurDobbelSteen = Brushes.Red;
        }

        //🔒
        Button[] arrayrijRood = new Button[13];
        Button[] arrayrijGeel = new Button[13];
        Button[] arrayrijGroen = new Button[13];
        Button[] arrayrijBlauw = new Button[13];

        Button[] arrayrijRood2 = new Button[13];
        Button[] arrayrijGeel2 = new Button[13];
        Button[] arrayrijGroen2 = new Button[13];
        Button[] arrayrijBlauw2 = new Button[13];

        Brush KleurDobbelSteen;

        Random r = new Random();

        int intHoeVer, MislukteWorp = 0, MislukteWorp2 = 0;

        bool turn = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            Qwixxkaart(arrayrijRood, 50, 50, Color.Red, 2, 2);
            Qwixxkaart(arrayrijGeel, 50, 100, Color.Yellow, 2, 2);
            Qwixxkaart(arrayrijGroen, 50, 150, Color.Green, 12, 12);
            Qwixxkaart(arrayrijBlauw, 50, 200, Color.Blue, 12, 12);

            Qwixxkaart(arrayrijRood2, 850, 50, Color.Red, 2, 2);
            Qwixxkaart(arrayrijGeel2, 850, 100, Color.Yellow, 2, 2);
            Qwixxkaart(arrayrijGroen2, 850, 150, Color.Green, 12, 12);
            Qwixxkaart(arrayrijBlauw2, 850, 200, Color.Blue, 12, 12);
        }

        public void Qwixxkaart(Button[] arraybutton, int xPos, int ypos, Color color, int a, int b)
        {
            //labels maken
            for (int i = 1; i < arraybutton.Length; i++)
            {
                arraybutton[i] = new Button();
                arraybutton[i].BackColor = color;
                arraybutton[i].TextAlign = ContentAlignment.MiddleCenter;
                arraybutton[i].Text = a.ToString();
                arraybutton[i].Tag = i;
                arraybutton[i].Font = new Font("Serif", 12, FontStyle.Bold);
                arraybutton[i].Size = new Size(50, 50);
                arraybutton[i].Location = new Point(xPos + (i % 14) * 50, ypos + (i / 14) * 60);
                this.Controls.Add(arraybutton[i]);
                if (b == 2)
                {
                    a++;

                    if (a == 14)
                    {
                        arraybutton[i].Text = "🔓";
                        arraybutton[i].Font = new Font("Serif", 16, FontStyle.Bold);
                        arraybutton[i].Enabled = false;
                    }
                }
                else
                {
                    a--;
                    if (a == 0)
                    {
                        arraybutton[i].Text = "🔓";
                        arraybutton[i].Font = new Font("Serif", 16, FontStyle.Bold);
                        arraybutton[i].Enabled = false;
                    }

                }
                arraybutton[i].Click += buttonclick;
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

                if (arrayButton[12].BackColor == kleur2)
                {
                    arrayButton[12].Text = "🔒";
                }
            }
        }

        public void buttonclick(object sender, EventArgs e)
        {
            Button vakje = (Button)sender;

            intHoeVer = int.Parse(vakje.Tag.ToString());

            if (vakje.Location.X < 1000)
            {

                VeranderKleur(arrayrijRood, Color.Red, vakje, Color.LightPink);
                VeranderKleur(arrayrijGeel, Color.Yellow, vakje, Color.LightYellow);
                VeranderKleur(arrayrijGroen, Color.Green, vakje, Color.LightGreen);
                VeranderKleur(arrayrijBlauw, Color.Blue, vakje, Color.LightBlue);
            }
            else
            {
                VeranderKleur(arrayrijRood2, Color.Red, vakje, Color.LightPink);
                VeranderKleur(arrayrijRood2, Color.Red, vakje, Color.LightPink);
                VeranderKleur(arrayrijGeel2, Color.Yellow, vakje, Color.LightYellow);
                VeranderKleur(arrayrijGroen2, Color.Green, vakje, Color.LightGreen);
                VeranderKleur(arrayrijBlauw2, Color.Blue, vakje, Color.LightBlue);
            }


            PuntenTellen(arrayrijRood, Color.LightPink, txtRood, Color.Red);
            PuntenTellen(arrayrijGeel, Color.LightYellow, txtGeel, Color.Yellow);
            PuntenTellen(arrayrijGroen, Color.LightGreen, txtGroen, Color.Green);
            PuntenTellen(arrayrijBlauw, Color.LightBlue, txtBlauw, Color.Blue);

            PuntenTellen(arrayrijRood2, Color.LightPink, txtRood2, Color.Red);
            PuntenTellen(arrayrijGeel2, Color.LightYellow, txtGeel2, Color.Yellow);
            PuntenTellen(arrayrijGroen2, Color.LightGreen, txtGroen2, Color.Green);
            PuntenTellen(arrayrijBlauw2, Color.LightBlue, txtBlauw2, Color.Blue);

            if (vakje.Tag.ToString() == "12")
            {
                LockDown(arrayrijRood, arrayrijRood2, Color.LightPink);
                LockDown(arrayrijGeel, arrayrijGeel2, Color.LightYellow);
                LockDown(arrayrijGroen, arrayrijGroen2, Color.LightGreen);
                LockDown(arrayrijBlauw, arrayrijBlauw2, Color.LightBlue);
            }

        }
        public void LockDown(Button[] arraybutton, Button[] arraybutton2, Color kleur)
        {
            if (arraybutton[12].BackColor == kleur || arraybutton2[12].BackColor == kleur)
            {
                for (int i = 1; i < arraybutton.Length; i++)
                {
                    arraybutton[i].Enabled = false;
                    arraybutton2[i].Enabled = false;

                    if (arraybutton[i].BackColor != kleur)
                    {
                        arraybutton[i].BackColor = TransparencyKey;
                    }
                    if (arraybutton2[i].BackColor != kleur)
                    {
                        arraybutton2[i].BackColor = TransparencyKey;
                    }
                }
            }
        }
        public void PuntenTellen(Button[] arrayButton, Color kleur, TextBox text, Color kleur2)
        {
            int teller = 0;
            for (int i = 1; i < arrayButton.Length; i++)
            {
                if (arrayButton[i].BackColor == kleur)
                {
                    teller++;
                }
            }
            if (arrayButton[12].BackColor == kleur2)
            {
                if (teller >= 5)
                {
                    arrayButton[12].Enabled = true;
                }
            }
            switch (teller)
            {
                case 1:
                    text.Text = "1";
                    break;
                case 2:
                    text.Text = "3";
                    break;
                case 3:
                    text.Text = "6";
                    break;
                case 4:
                    text.Text = "10";
                    break;
                case 5:
                    text.Text = "15";
                    break;
                case 6:
                    text.Text = "21";
                    break;
                case 7:
                    text.Text = "28";
                    break;
                case 8:
                    text.Text = "36";
                    break;
                case 9:
                    text.Text = "45";
                    break;
                case 10:
                    text.Text = "55";
                    break;
                case 11:
                    text.Text = "66";
                    break;
                case 12:
                    text.Text = "78";
                    break;

            }

            PuntenTellenTotaal();
        }
        public void PuntenTellenTotaal()
        {
            int Rood, Geel, Groen, Blauw, Min, Totaal, Rood2, Geel2, Groen2, Blauw2, Min2, Totaal2;
            Rood = int.Parse(txtRood.Text);
            Geel = int.Parse(txtGeel.Text);
            Groen = int.Parse(txtGroen.Text);
            Blauw = int.Parse(txtBlauw.Text);
            Min = int.Parse(txtKanNiet1.Text);
            Totaal = Rood + Geel + Groen + Blauw + Min;
            txtResultaat1.Text = Totaal.ToString();

            Rood2 = int.Parse(txtRood2.Text);
            Geel2 = int.Parse(txtGeel2.Text);
            Groen2 = int.Parse(txtGroen2.Text);
            Blauw2 = int.Parse(txtBlauw2.Text);
            Min2 = int.Parse(txtKanNiet2.Text);
            Totaal2 = Rood2 + Geel2 + Groen2 + Blauw2 + Min2;
            txtResultaat2.Text = Totaal2.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picCanvas.Invalidate();

            if (turn == true)
            {
                txtbeurt.Text = "Player 1";
            }
            if (turn == false)
            {
                txtbeurt.Text = "Player 2";
            }
            turn = !turn;
        }

        void makenDobbelsteen(Brush kleur, int x, int y, PaintEventArgs e, int aantalOgen)
        {
            Graphics canvas = e.Graphics;
            // teken dobbelsteen(vierkant)
            canvas.FillRectangle(kleur, x, y, 75, 75);
            switch (aantalOgen)
            {
                case 1:
                    canvas.FillEllipse(Brushes.Black, x + 30, y + 30, 15, 15);
                    break;
                case 2:
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 50, y + 50, 15, 15);
                    break;
                case 3:
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 30, y + 30, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 50, y + 50, 15, 15);
                    break;
                case 4:
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 55, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 55, 15, 15);
                    break;
                case 5:
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 55, 15, 15);

                    canvas.FillEllipse(Brushes.Black, x + 55, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 55, 15, 15);

                    canvas.FillEllipse(Brushes.Black, x + 30, y + 30, 15, 15);
                    break;
                case 6:
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 30, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 10, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 55, y + 55, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 55, 15, 15);
                    canvas.FillEllipse(Brushes.Black, x + 10, y + 30, 15, 15);
                    break;
            }
        }

        private void UpdatePictureBoxGraphic(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            makenDobbelsteen(Brushes.Red, 10, 10, e, r.Next(1, 7));
            makenDobbelsteen(Brushes.Yellow, 120, 10, e, r.Next(1, 7));
            makenDobbelsteen(Brushes.Blue, 250, 10, e, r.Next(1, 7));
            makenDobbelsteen(Brushes.Green, 370, 10, e, r.Next(1, 7));
            makenDobbelsteen(Brushes.White, 490, 10, e, r.Next(1, 7));
            makenDobbelsteen(Brushes.White, 610, 10, e, r.Next(1, 7));
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Het doel van het spel is eenvoudig:\nelke speler probeert op zijn scoreblad zoveel mogelijk getallen in de vier kleuren aan te kruisen. Hoe meer kruisjes in een kleur, des te meer punten men krijgt. Wie aan het einde de meeste punten heeft verzameld, wint het spel.\n\nGetallen aankruisen\nTijdens het spel moeten de getallen in elk van de vier kleuren altijd van links naar rechts aangekruist worden. Spelers hoeven niet helemaal links te beginnen – het is toegestaan één of meer getallen over te slaan. Overgeslagen getallen mogen achteraf echter niet alsnog worden aangekruist\n\nTip: Spelers kunnen overgeslagen getallen met een klein lijntje doorstrepen om te voorkomen dat die getallen per ongeluk worden aangekruist.\n\nSpelverloop\nElke speler krijgt een scoreblad en pakt een pen of potlood(niet inbegrepen). Bepaal(bijv.door een dobbelsteenworp) wie de eerste actieve speler is. De actieve speler gooit met de zes dobbelstenen. Daarna worden de volgende twee acties achtereenvolgens uitgevoerd, eerst actie 1 en daarna actie 2.\n\n1.) De actieve speler telt de ogen van beide witte dobbelstenen bij elkaar op en zegt luid en duidelijk het totaal. Elke speler mag nu(maar hoeft niet!) dit getal in een kleur naar keuze aanrkuisen.\n\nVoorbeeld: Max is de actieve speler. De witte dobbelstenen tonen een 4 en een 1. Max zegt luid en duidelijk “Vijf!”. Emma kruist op haar scoreblad de gele 5 aan. Max kruist de rode 5 aan op zijn scoreblad. Laura en Bob willen niets aankruisen.\n\n2.) De actieve speler(maar niet de andere spelers!) mag nu, maar hoeft niet, één witte dobbelsteen met één gekleurde dobbelsteen naar keuze combineren en de som daarvan in de bijbehorende kleur aankruisen.\n\nVoorbeeld: Max combineert de witte 4 met de blauwe 6 en kruist de blauwe 10 aan.\n\nLet op!Als de actieve speler noch tijdens actie 1, noch tijdens actie 2 een getal aankruist, moet hij in een leeg vakje bij “mislukte worpen” een kruisje zetten. De niet-actieve spelers hoeven geen kruisje te zetten voor een mislukte worp, ongeacht ze een getal hebben aangekruist of niet. Nu wordt de volgende speler met de klok mee de nieuwe actieve speler. Hij gooit de zes dobbelstenen. Aansluitend worden de twee acties weer achtereenvolgens uitgevoerd. Zo wordt steeds verder gespeeld.\n\nEen kleur sluiten\nOm het getal helemaal rechts in een kleur aan te mogen kruisen(rode 12, gele 12, groene 2, blauwe 2), moet de speler in diezelfde kleur al minstens vijf kruisjes hebben gezet. Als een speler uiteindelijk het getal helemaal rechts aankruist, dan kruist hij aansluitend het aangrenzende vakje met het slot aan – dit kruisje wordt later bij de eindtelling ook meegerekend! Deze kleur is nu voor alle spelers gesloten en in alle volgende beurten mag in deze kleur niets meer worden aangekruist. De dobbelsteen van die kleur wordt uit het spel genomen en niet meer gebruikt.\n\nVoorbeeld: Laura kruist de groene 2 en meteen daarna het slot aan. De groene dobbelsteen wordt uit het spel genomen.\n\nOpmerking: Wanneer een speler het getal helemaal rechts aankruist, moet hij dit luid en duidelijk kenbaar maken, zodat alle spelers weten dat deze kleur vanaf nu gesloten is.\n\nAls het sluiten van een kleur tijdens actie 1 plaatsvindt, is het mogelijk dat tegelijkertijd ook andere spelers deze kleur sluiten en daarbij het slot aankruisen.Heeft een speler echter minder dan vijf kruisjes in die kleur, dan mag hij het laatste vakje rechts onder geen enkel beding aankruisen, ook niet als de kleur door een andere speler gesloten wordt.\n\nEinde van het spel\nHet spel eindigt meteen als een speler zijn vierde mislukte worp aangekruist heeft. Ook eindigt het speel meteen als, door welke speler dan ook, een tweede kleur wordt gesloten en daarmee de tweede gekleurde dobbelsteen uit het spel wordt genomen.\n\nTip: Het is mogelijk dat (tijdens actie 1) gelijktijdig met de tweede kleur ook een derde kleur gesloten wordt.\n\nVoorbeeld: Groen is al gesloten. Nu gooit Emma met de witte dobbelstenen twee zessen en zegt hardop “Twaalf!”. Max kruist de rode 12 aan en sluit deze kleur. Tegelijkertijd kruist Bob de gele 12 aan en sluit die kleur.\n\nAlles over Qwixx scores: hoe werkt de puntentelling?\nOnderaan het blad is aangegeven hoeveel punten een bepaald aantal kruisjes in één kleur oplevert. Elke mislukte worp levert vijf minpunten op. Nu berekent elke speler de punten voor zijn vier kleuren en de minpunten voor de mislukte worpen en vult deze in de desbetreffende vakjes op zijn scoreblad in. De speler met de hoogste totaalscore is de winnaar.", "Regels");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MislukteWorp -= 5;
            txtKanNiet1.Text = MislukteWorp.ToString();
            PuntenTellenTotaal();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MislukteWorp2 -= 5;
            txtKanNiet2.Text = MislukteWorp.ToString();
            PuntenTellenTotaal();
        }
    }
}