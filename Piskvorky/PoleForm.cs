using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;




namespace Piskvorky
{
    /// <summary>
    /// Toto je třída ve které se nachází kostra celého programu. Pracuje s hlavním oknem a hracím polem.
    /// </summary>
    public partial class PoleForm : Form
    {

        /// <summary>
        /// Určuje kdo je na tahu.
        /// </summary>
        public bool tah = true;
        /// <summary>
        /// Proměnná určující velikost hracího plánu.
        /// </summary>                 
        public static int velikostPole = 10;
        /// <summary>
        /// Hrací pole typu Button
        /// </summary>
        public Button[,] pole;
        /// <summary>
        /// Hrací pole typu String.
        /// </summary>
        public String[,] znaky;
        /// <summary>
        /// Používá se při dělění velikosti pole podle zvoleného nastavení.
        /// </summary>
        public static int pomer = 1;
        /// <summary>
        /// Zvolený režim hry.
        /// </summary>
        public static int rezimHry = 0;
        /// <summary>
        /// Inteligence prvního počítače.
        /// </summary>
        public static int inteligence1 = 0;
        /// <summary>
        /// Inteligence druhého počítače.
        /// </summary>
        public static int inteligence2 = 0;
        AI AI = new AI();
        int x = 0;
        int y = 0;
        bool mys = true;
        /// <summary>
        /// Rychlost hry dvou počítačů.
        /// </summary>
        public static int rychlost = 1000;

        /// <summary>
        /// Konstruktor, který je nutný ke správnému fungování programu.
        /// </summary>
        public PoleForm()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// Metoda ve které se vyhodnocuje kliknutí na určité políčko.
        /// </summary>
        protected void kliknuti(object sender, EventArgs e)
        {
            Button button = sender as Button;   
            if (mys == true)
            {


                if (tah == true & button.Text == "")    //v případě že je na tahu člověk
                {
                    button.Text = "X";
                    button.ForeColor = Color.Blue;
                    tahTextBox1.Text = "Na tahu je hráč O";
                    Naplneni();
                    Kontrola();

                    if (rezimHry == 1)      //režim hry je hráč proti počítači a na tahu je počítač
                    {
                        tah = false;
                        if (inteligence1 == 0)      //řeší se obtížnost počítače
                        {
                            AI.Lehky(znaky, ref x, ref y);
                            pole[x, y].PerformClick();
                        }
                        else
                        {
                            AI.Stredni(znaky, "O", "X", ref x, ref y);
                            pole[x, y].PerformClick();
                        }

                        tah = true;
                        
                    }
                    else tah = false;
                    Naplneni();
                    Kontrola();
                    
                }
                if (tah == false & button.Text == "")   //na tahu je druhý lidský hráč
                {
                    button.Text = "O";
                    button.ForeColor = Color.Red;
                    tah = true;
                    tahTextBox1.Text = "Na tahu je hráč X";
                    Naplneni();
                    Kontrola();
                }
            }
        }

        /// <summary>
        /// Metoda na vytvoření hracího plánu.
        /// </summary>
        public void VytvorPole()                    
        {       
            pole = new Button[velikostPole, velikostPole];
            znaky = new String[velikostPole, velikostPole];
            tahTextBox1.Text = "Na tahu je hráč X"; //zpráva oznamující, kdo je na tahu
            for (int i = 0; i < velikostPole; i++)
            {
                for (int j = 0; j < velikostPole; j++)
                {
                    
                    pole[i, j] = new Button();
                    pole[i, j].Location = new Point(63 + i * 45 / pomer, 90 + j * 45 / pomer);
                    pole[i, j].Height = 45 / pomer;
                    pole[i, j].Width = 45 / pomer;
                    pole[i, j].Visible = true;                    
                    pole[i, j].Click += new EventHandler(kliknuti);
                    this.Controls.Add(pole[i, j]);

                }
            }

        }
        
        private void nastaveniToolStripMenuItem_Click(object sender, EventArgs e) //menu v horní liště
        {
            Nastaveni nastaveni = new Nastaveni();
            nastaveni.ShowDialog();
        }

        private void konecToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Metoda zahajující hru.
        /// </summary>
        private void nováHraToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            
            VytvorPole();
            Naplneni();   
            nastaveniToolStripMenuItem.Enabled = false;
            nováHraToolStripMenuItem.Enabled = false;
            
            if (rezimHry == 2)      // v případě, že hrají dva počítače proti sobě
            {
                t1.Interval = rychlost;
                t2.Interval = rychlost;
                mys = false;        //zabraňuje klikání myší během hry dvou počítačů
                t1.Enabled = true;
                
                t1.Start();
                tahTextBox1.Visible = false;
                

            }

        }
        /// <summary>
        /// Metoda která podle hracího plánu naplní stejně velké stringové pole pro lehčí vypočítávání souřadnic ve třídě AI.
        /// </summary>
        private void Naplneni()     
        {
            for (int i = 0; i < velikostPole; i++)
            {
                for (int j = 0; j < velikostPole; j++)
                {
                    znaky[i, j] = pole[i, j].Text;
                }
            }
        }

        /// <summary>
        /// Vyhodnocení remízy.
        /// </summary>
        private bool Remiza()       
        {
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 0; j < velikostPole; j++)
                {
                    if (znaky[i, j] != "X" & znaky[i + 1, j] != "X" & znaky[i + 2, j] != "X" & znaky[i + 3, j] != "X" & znaky[i + 4, j] != "X")
                    {
                        return false;
                    }
                    if (znaky[i, j] != "O" & znaky[i + 1, j] != "O" & znaky[i + 2, j] != "O" & znaky[i + 3, j] != "O" & znaky[i + 4, j] != "O")
                    {
                        return false;
                    }

                }
            }
            for (int i = 0; i < velikostPole; i++)
            {
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] != "X" & znaky[i, j + 1] != "X" & znaky[i, j + 2] != "X" & znaky[i, j + 3] != "X" & znaky[i, j + 4] != "X")
                    {
                        return false;
                    }
                    if (znaky[i, j] != "O" & znaky[i, j + 1] != "O" & znaky[i, j + 2] != "O" & znaky[i, j + 3] != "O" & znaky[i, j + 4] != "O")
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] != "X" & znaky[i + 1, j + 1] != "X" & znaky[i + 2, j + 2] != "X" & znaky[i + 3, j + 3] != "X" & znaky[i + 4, j + 4] != "X")
                    {
                        return false;
                    }
                    if (znaky[i, j] != "O" & znaky[i + 1, j + 1] != "O" & znaky[i + 2, j + 2] != "O" & znaky[i + 3, j + 3] != "O" & znaky[i + 4, j + 4] != "O")
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 4; j < velikostPole; j++)
                {
                    if (znaky[i, j] != "X" & znaky[i + 1, j - 1] != "X" & znaky[i + 2, j - 2] != "X" & znaky[i + 3, j - 3] != "X" & znaky[i + 4, j - 4] != "X")
                    {
                        return false;
                    }
                    if (znaky[i, j] != "O" & znaky[i + 1, j - 1] != "O" & znaky[i + 2, j - 2] != "O" & znaky[i + 3, j - 3] != "O" & znaky[i + 4, j - 4] != "O")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Zde se ověřuje, zda došlo k výhře některého hráče. V kladném případě oznámí výhru a ukončí program.
        /// </summary>
        private void Kontrola()
        {
            if (Remiza() == true)       //v případě remízy vypíše, že došlo k remíze a ukončí program
            {                
                t1.Stop();                
                t2.Stop();
                MessageBox.Show("Remíza!");
                Application.Exit();
            }

            //zde se řeší každý směr - v případě výhry jí program oznámí, a ukončí aplikaci

            for (int i = 0; i < velikostPole - 4; i++)
            {
                //pro řádek
                for (int j = 0; j < velikostPole; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j] == "X" & znaky[i + 2, j] == "X" & znaky[i + 3, j] == "X" & znaky[i + 4, j] == "X")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč X!");
                        Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j] == "O" & znaky[i + 2, j] == "O" & znaky[i + 3, j] == "O" & znaky[i + 4, j] == "O")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč O!");
                        Application.Exit();
                    }
                    
                }
            }
            for (int i = 0; i < velikostPole; i++)
            {
                //pro sloupec
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i, j + 1] == "X" & znaky[i, j + 2] == "X" & znaky[i, j + 3] == "X" & znaky[i, j + 4] == "X")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i, j + o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč X!");
                        Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i, j + 1] == "O" & znaky[i, j + 2] == "O" & znaky[i, j + 3] == "O" & znaky[i, j + 4] == "O")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i, j + o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč O!");
                        Application.Exit();
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                //pro diagonálu
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j + 1] == "X" & znaky[i + 2, j + 2] == "X" & znaky[i + 3, j + 3] == "X" & znaky[i + 4, j + 4] == "X")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j + o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč X!");
                        Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j + 1] == "O" & znaky[i + 2, j + 2] == "O" & znaky[i + 3, j + 3] == "O" & znaky[i + 4, j + 4] == "O")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j + o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč O!");
                        Application.Exit();
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                //opačná diagonála
                for (int j = 4; j < velikostPole; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j - 1] == "X" & znaky[i + 2, j - 2] == "X" & znaky[i + 3, j - 3] == "X" & znaky[i + 4, j - 4] == "X")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j - o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč X!");
                        Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j - 1] == "O" & znaky[i + 2, j - 2] == "O" & znaky[i + 3, j - 3] == "O" & znaky[i + 4, j - 4] == "O")
                    {
                        t1.Stop();
                        t2.Stop();
                        for (int o = 0; o < 5; o++)
                        {
                            pole[i + o, j - o].BackColor = Color.Lime;
                        }
                        MessageBox.Show("Vyhrává hráč O!");
                        Application.Exit();
                    }
                }
            }
            

        }

        /// <summary>
        /// Časovače určující ryhlost hry dvou počítačů.
        /// </summary>
        private void t1_Tick(object sender, EventArgs e)
        {
            // časovače pro hru dvou hráčů, aby se počítače střídali po vteřině
            if (inteligence1 == 0)
            {
                AI.Lehky(znaky, ref x, ref y);
            }
            else AI.Stredni(znaky, "X", "O", ref x, ref y);
            mys = true;
            pole[x, y].PerformClick();
            mys = false;
            Naplneni();
            Kontrola();
            t1.Stop();
            t1.Enabled = false;
            t2.Enabled = true;
            t2.Start();
        }

        private void t2_Tick(object sender, EventArgs e)
        {
            
            if (inteligence2 == 0)
            {
                AI.Lehky(znaky, ref x, ref y);
            }
            else AI.Stredni(znaky, "O", "X", ref x, ref y);
            mys = true;
            pole[x, y].PerformClick();
            mys = false;
            Naplneni();
            Kontrola();
            t2.Stop();
            t2.Enabled = false;
            t1.Enabled = true;
            t1.Start();
        }
    }

}
