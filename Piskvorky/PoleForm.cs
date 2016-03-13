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
    public partial class PoleForm : Form
    {
        public bool tah = true;
        public static int velikostPole = 10;
        public Button[,] pole;
        public String[,] znaky;
        public static int pomer = 1;
        public static int rezimHry = 0;
        public static int inteligence = 0;
        AI AI = new AI();
        int x = 0;
        int y = 0;
        

        public PoleForm()
        {
            InitializeComponent();
            
        }

        

        protected void kliknuti(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (tah == true & button.Text == "")
            {
                button.Text = "X";
                tahTextBox1.Text = "Na tahu je hráč O";
                
                if (rezimHry == 1)
                {
                    tah = false;
                    if (inteligence == 0)
                    {
                        AI.Lehky(znaky, ref x, ref y);
                        pole[x, y].PerformClick();
                    }
                    else
                    {
                        AI.Stredni(znaky, 0,  ref x, ref y);
                        pole[x, y].PerformClick();
                    }
                    
                    tah = true;
                    //tahTextBox1.Text = "Na tahu je hráč X";
                }
                else tah = false;
                Naplneni();
                Kontrola();
                //tahTextBox1.Text = "Na tahu je hráč X";
            }
            if (tah == false & button.Text == "")
            {
                button.Text = "O";
                tah = true;
                tahTextBox1.Text = "Na tahu je hráč X";
                Naplneni();
                Kontrola();  
            }
        }
        public void VytvorPole()
        {
            pole = new Button[velikostPole, velikostPole];
            znaky = new String[velikostPole, velikostPole];
            tahTextBox1.Text = "Na tahu je hráč X";
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
            System.Windows.Forms.Application.Exit();
        }

        private void nováHraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            VytvorPole();
            Naplneni();
            nastaveniToolStripMenuItem.Enabled = false;
            nováHraToolStripMenuItem.Enabled = false;
            
            if (rezimHry == 2)
            {
                tahTextBox1.Visible = false;
                while (rezimHry == 2)
                {                   
                    AI.Lehky(znaky, ref x, ref y);
                    pole[x, y].PerformClick();
                    //var t = Task.Delay(1000);
                    //t.Wait();
                    
                    //Thread.Sleep(1000);
                }

            }







            //MessageBox.Show("stisknuto: " + x.ToString() + ", " + y.ToString());

        }
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
        private void Hra()
        {
           
        }
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
        private void Kontrola()
        {
            if (Remiza() == true)
            {
                MessageBox.Show("Remíza!");
                System.Windows.Forms.Application.Exit();
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 0; j < velikostPole; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j] == "X" & znaky[i + 2, j] == "X" & znaky[i + 3, j] == "X" & znaky[i + 4, j] == "X")
                    {
                        MessageBox.Show("Vyhrává hráč X!");
                        System.Windows.Forms.Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j] == "O" & znaky[i + 2, j] == "O" & znaky[i + 3, j] == "O" & znaky[i + 4, j] == "O")
                    {
                        MessageBox.Show("Vyhrává hráč O!");
                        System.Windows.Forms.Application.Exit();
                    }
                    
                }
            }
            for (int i = 0; i < velikostPole; i++)
            {
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i, j + 1] == "X" & znaky[i, j + 2] == "X" & znaky[i, j + 3] == "X" & znaky[i, j + 4] == "X")
                    {
                        MessageBox.Show("Vyhrává hráč X!");
                        System.Windows.Forms.Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i, j + 1] == "O" & znaky[i, j + 2] == "O" & znaky[i, j + 3] == "O" & znaky[i, j + 4] == "O")
                    {
                        MessageBox.Show("Vyhrává hráč O!");
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 0; j < velikostPole - 4; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j + 1] == "X" & znaky[i + 2, j + 2] == "X" & znaky[i + 3, j + 3] == "X" & znaky[i + 4, j + 4] == "X")
                    {
                        MessageBox.Show("Vyhrává hráč X!");
                        System.Windows.Forms.Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j + 1] == "O" & znaky[i + 2, j + 2] == "O" & znaky[i + 3, j + 3] == "O" & znaky[i + 4, j + 4] == "O")
                    {
                        MessageBox.Show("Vyhrává hráč O!");
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            for (int i = 0; i < velikostPole - 4; i++)
            {
                for (int j = 4; j < velikostPole; j++)
                {
                    if (znaky[i, j] == "X" & znaky[i + 1, j - 1] == "X" & znaky[i + 2, j - 2] == "X" & znaky[i + 3, j - 3] == "X" & znaky[i + 4, j - 4] == "X")
                    {
                        MessageBox.Show("Vyhrává hráč X!");
                        System.Windows.Forms.Application.Exit();
                    }
                    if (znaky[i, j] == "O" & znaky[i + 1, j - 1] == "O" & znaky[i + 2, j - 2] == "O" & znaky[i + 3, j - 3] == "O" & znaky[i + 4, j - 4] == "O")
                    {
                        MessageBox.Show("Vyhrává hráč O!");
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            

        }
        
    }

}
