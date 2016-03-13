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
            if (PoleComboBox1.SelectedIndex == 0)
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
            if (AI1ComboBox.SelectedIndex == 0)
            {
                PoleForm.inteligence = 0;
            }
            if (AI1ComboBox.SelectedIndex == 1)
            {
                PoleForm.inteligence = 1;
            }
        }
    }
}
