namespace Piskvorky
{
    partial class Nastaveni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AI2ComboBox = new System.Windows.Forms.ComboBox();
            this.AI1ComboBox = new System.Windows.Forms.ComboBox();
            this.AI2Label = new System.Windows.Forms.Label();
            this.AI1Label = new System.Windows.Forms.Label();
            this.rezimComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PoleComboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AI2ComboBox
            // 
            this.AI2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AI2ComboBox.FormattingEnabled = true;
            this.AI2ComboBox.Items.AddRange(new object[] {
            "Jednoduchá",
            "Normální"});
            this.AI2ComboBox.Location = new System.Drawing.Point(165, 196);
            this.AI2ComboBox.Name = "AI2ComboBox";
            this.AI2ComboBox.Size = new System.Drawing.Size(107, 21);
            this.AI2ComboBox.TabIndex = 16;
            this.AI2ComboBox.Visible = false;
            // 
            // AI1ComboBox
            // 
            this.AI1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AI1ComboBox.FormattingEnabled = true;
            this.AI1ComboBox.Items.AddRange(new object[] {
            "Jednoduchá",
            "Normální"});
            this.AI1ComboBox.Location = new System.Drawing.Point(165, 141);
            this.AI1ComboBox.Name = "AI1ComboBox";
            this.AI1ComboBox.Size = new System.Drawing.Size(107, 21);
            this.AI1ComboBox.TabIndex = 15;
            this.AI1ComboBox.Visible = false;
            this.AI1ComboBox.SelectedIndexChanged += new System.EventHandler(this.AI1ComboBox_SelectedIndexChanged);
            // 
            // AI2Label
            // 
            this.AI2Label.AutoSize = true;
            this.AI2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AI2Label.Location = new System.Drawing.Point(12, 197);
            this.AI2Label.Name = "AI2Label";
            this.AI2Label.Size = new System.Drawing.Size(120, 20);
            this.AI2Label.TabIndex = 14;
            this.AI2Label.Text = "Inteligence AI 2";
            this.AI2Label.Visible = false;
            // 
            // AI1Label
            // 
            this.AI1Label.AutoSize = true;
            this.AI1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AI1Label.Location = new System.Drawing.Point(12, 142);
            this.AI1Label.Name = "AI1Label";
            this.AI1Label.Size = new System.Drawing.Size(120, 20);
            this.AI1Label.TabIndex = 13;
            this.AI1Label.Text = "Inteligence AI 1";
            this.AI1Label.Visible = false;
            // 
            // rezimComboBox
            // 
            this.rezimComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rezimComboBox.FormattingEnabled = true;
            this.rezimComboBox.Items.AddRange(new object[] {
            "Hráč proti hráči",
            "Hráč proti počítači",
            "Počítač proti počítači"});
            this.rezimComboBox.Location = new System.Drawing.Point(165, 88);
            this.rezimComboBox.Name = "rezimComboBox";
            this.rezimComboBox.Size = new System.Drawing.Size(107, 21);
            this.rezimComboBox.TabIndex = 12;
            this.rezimComboBox.SelectedIndexChanged += new System.EventHandler(this.rezimComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Velikost Pole";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Režim hry";
            // 
            // PoleComboBox1
            // 
            this.PoleComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PoleComboBox1.FormattingEnabled = true;
            this.PoleComboBox1.Items.AddRange(new object[] {
            "10x10",
            "20x20"});
            this.PoleComboBox1.Location = new System.Drawing.Point(165, 39);
            this.PoleComboBox1.Name = "PoleComboBox1";
            this.PoleComboBox1.Size = new System.Drawing.Size(107, 21);
            this.PoleComboBox1.TabIndex = 9;
            this.PoleComboBox1.SelectedIndexChanged += new System.EventHandler(this.PoleComboBox1_SelectedIndexChanged);
            // 
            // Nastaveni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AI2ComboBox);
            this.Controls.Add(this.AI1ComboBox);
            this.Controls.Add(this.AI2Label);
            this.Controls.Add(this.AI1Label);
            this.Controls.Add(this.rezimComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PoleComboBox1);
            this.Name = "Nastaveni";
            this.Text = "Nastavení";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AI2ComboBox;
        private System.Windows.Forms.ComboBox AI1ComboBox;
        private System.Windows.Forms.Label AI2Label;
        private System.Windows.Forms.Label AI1Label;
        private System.Windows.Forms.ComboBox rezimComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PoleComboBox1;
    }
}