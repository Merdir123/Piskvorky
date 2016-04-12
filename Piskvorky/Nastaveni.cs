using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky
{
    /// <summary>
    /// Zde se nastavuje okno Nastavení a jeho reakce na změnu indexů.
    /// </summary>
    public partial class Nastaveni : Form
    {
        PoleForm poleForm = new PoleForm();
        public Nastaveni()
        {
            InitializeComponent();
            PoleComboBox1.SelectedIndex = 0;    //nastaví první položku z možností
            rezimComboBox.SelectedIndex = 0;
            AI1ComboBox.SelectedIndex = 0;
            AI2ComboBox.SelectedIndex = 0;
            rychlostComboBox.SelectedIndex = 1;
        }
        private void rezimComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rezimComboBox.SelectedIndex)
            {
                //určuje jaké položky v menu budou viditelné
                case 1:                                       
                    AI1Label.Visible = true;
                    AI2Label.Visible = false;
                    AI1ComboBox.Visible = true;
                    AI2ComboBox.Visible = false;
                    PoleForm.rezimHry = 1;
                    break;
                case 2:
                    AI1Label.Visible = true;
                    AI2Label.Visible = true;
                    AI1ComboBox.Visible = true;
                    AI2ComboBox.Visible = true;
                    rychlostComboBox.Visible = true;
                    rychlostLabel.Visible = true;
                    PoleForm.rezimHry = 2;
                    break;
                default:
                    AI1Label.Visible = false;
                    AI2Label.Visible = false;
                    AI1ComboBox.Visible = false;
                    AI2ComboBox.Visible = false;
                    PoleForm.rezimHry = 0;
                    break;
            }
        }

        private void PoleComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PoleComboBox1.SelectedIndex == 0) //velikost pole
            {
                PoleForm.velikostPole = 10;
                PoleForm.pomer = 1;
            }
            if (PoleComboBox1.SelectedIndex == 1)
            { 
                PoleForm.velikostPole = 20;
                PoleForm.pomer = 2;
            }
        }

        private void AI1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AI1ComboBox.SelectedIndex == 0)  //inteligence počítače 1
            {
                PoleForm.inteligence1 = 0;
            }
            if (AI1ComboBox.SelectedIndex == 1)
            {
                PoleForm.inteligence1 = 1;
            }
        }

        private void AI2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AI2ComboBox.SelectedIndex == 0) //inteligence druhého počítače
            {
                PoleForm.inteligence2 = 0;
            }
            if (AI2ComboBox.SelectedIndex == 1)
            {
                PoleForm.inteligence2 = 1;
            }
        }

        private void potvrditButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rychlostComboBox_SelectedIndexChanged(object sender, EventArgs e) //nastavení rychlosti hry
        {
            if (rychlostComboBox.SelectedIndex == 0)
            {
                PoleForm.rychlost = 10;
            }
            if (rychlostComboBox.SelectedIndex == 1)
            {
                PoleForm.rychlost = 1000;
            }
            if (rychlostComboBox.SelectedIndex == 2)
            {
                PoleForm.rychlost = 2000;
            }
        }
    }
}
