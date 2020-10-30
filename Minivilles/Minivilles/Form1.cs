using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minivilles
{
    public partial class Form1 : Form
    {
        public Dictionary<COULEUR, Dictionary<CARD_ID,CardBox>> batimentsJ1 = new Dictionary<COULEUR, Dictionary<CARD_ID,CardBox>>();
        public Dictionary<COULEUR, Dictionary<CARD_ID, CardBox>> batimentsJ2 = new Dictionary<COULEUR, Dictionary<CARD_ID, CardBox>>();
        public Dictionary<COULEUR, Dictionary<CARD_ID, CardBox>> pile = new Dictionary<COULEUR, Dictionary<CARD_ID, CardBox>>();

        private Game g;

        private bool buyActive = false;
        public Form1()
        {
            InitializeComponent();
            g = new Game();
            foreach(COULEUR c in Enum.GetValues(typeof(COULEUR)))
            {
                batimentsJ1[c] = new Dictionary<CARD_ID, CardBox>();
                batimentsJ2[c] = new Dictionary<CARD_ID, CardBox>();
                pile[c] = new Dictionary<CARD_ID, CardBox>();
            }

            foreach (KeyValuePair<CARD_ID, int> c in g.CartesDisponibles._cartes)
            {
                Card card = new Card(Globals.CardInfo[c.Key]);
                card.cb.amount = c.Value;
                card.cb.Click += new EventHandler((Object sender, EventArgs args) => {
                    //Achète une carte 

                    Globals.gameTimer.Start();
                    Globals.card_chosen = card.ID;
                });
                pile[card.couleur][card.ID] = card.cb;
                switch (card.couleur)
                {
                    case COULEUR.BLEU:
                        flowLayoutPanelPile.Controls.Add(card.cb);
                        break;
                    case COULEUR.ROUGE:
                        flowLayoutPanelPile.Controls.Add(card.cb);
                        break;
                    case COULEUR.VERT:
                        flowLayoutPanelPile.Controls.Add(card.cb);
                        break;
                }
            }
            //On initialise les mains des joueurs
            foreach (KeyValuePair<CARD_ID, int> c in g.Joueurs[0].cartesEnJeu._cartes)
            {
                Card card = new Card(Globals.CardInfo[c.Key]);
                card.cb.amount = c.Value;
                batimentsJ1[card.couleur][card.ID] = card.cb;
                switch (card.couleur)
                {
                    case COULEUR.BLEU:
                        flowLayoutPanelP1B.Controls.Add(card.cb);
                        break;
                    case COULEUR.ROUGE:
                        flowLayoutPanelP1R.Controls.Add(card.cb);
                        break;
                    case COULEUR.VERT:
                        flowLayoutPanelP1G.Controls.Add(card.cb);
                        break;
                }
            }
            //On initialise les mains des joueurs
            foreach (KeyValuePair<CARD_ID, int> c in g.Joueurs[1].cartesEnJeu._cartes)
            {
                Card card = new Card(Globals.CardInfo[c.Key]);
                card.cb.amount = c.Value;
                batimentsJ2[card.couleur][card.ID] = card.cb;
                switch (card.couleur)
                {
                    case COULEUR.BLEU:
                        flowLayoutPanelP2B.Controls.Add(card.cb);
                        break;
                    case COULEUR.ROUGE:
                        flowLayoutPanelP2R.Controls.Add(card.cb);
                        break;
                    case COULEUR.VERT:
                        flowLayoutPanelP2G.Controls.Add(card.cb);
                        break;
                }
            }
            Globals.gameTimer.Interval = 400;
            Globals.gameTimer.Tick += new EventHandler((Object sender, EventArgs e) =>{
                g.update();
                updateAffichage(this, null);
                Refresh();
            });

            Globals.gameTimer.Start();
            Paint += (updateAffichage);
            ThreadStart threadDelegate = new ThreadStart(g.JouerPartie);
            Thread t = new Thread(threadDelegate);
            t.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void updateAffichage(Object sender, PaintEventArgs args)
        {
            label2.Text = g.Joueurs[0].argent.ToString() ;
            label4.Text = g.Joueurs[1].argent.ToString();
            foreach (KeyValuePair<CARD_ID, int> c in g.Joueurs[0].cartesEnJeu._cartes)
            {
                Card card = Globals.CardInfo[c.Key];
                batimentsJ1[card.couleur][card.ID].amount = c.Value;
            }

            foreach (KeyValuePair<CARD_ID, int> c in g.Joueurs[1].cartesEnJeu._cartes)
            {
                Card card = Globals.CardInfo[c.Key];
                batimentsJ2[card.couleur][card.ID].amount = c.Value;
            }
            foreach (KeyValuePair<CARD_ID, int> c in g.CartesDisponibles._cartes)
            {
                Card card = Globals.CardInfo[c.Key];
                pile[card.couleur][card.ID].amount = c.Value;
            }
        }
    }

}
