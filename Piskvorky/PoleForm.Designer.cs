namespace Piskvorky
{
    partial class PoleForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.hraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nováHraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nastaveniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahTextBox1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(207, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "PIŠKVORKY";
            // 
            // hraToolStripMenuItem
            // 
            this.hraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nováHraToolStripMenuItem,
            this.konecToolStripMenuItem1});
            this.hraToolStripMenuItem.Name = "hraToolStripMenuItem";
            this.hraToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.hraToolStripMenuItem.Text = "Hra";
            // 
            // nováHraToolStripMenuItem
            // 
            this.nováHraToolStripMenuItem.Name = "nováHraToolStripMenuItem";
            this.nováHraToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nováHraToolStripMenuItem.Text = "Nová Hra";
            this.nováHraToolStripMenuItem.Click += new System.EventHandler(this.nováHraToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem1
            // 
            this.konecToolStripMenuItem1.Name = "konecToolStripMenuItem1";
            this.konecToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.konecToolStripMenuItem1.Text = "Konec";
            this.konecToolStripMenuItem1.Click += new System.EventHandler(this.konecToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hraToolStripMenuItem,
            this.nastaveniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nastaveniToolStripMenuItem
            // 
            this.nastaveniToolStripMenuItem.Name = "nastaveniToolStripMenuItem";
            this.nastaveniToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.nastaveniToolStripMenuItem.Text = "Nastavení";
            this.nastaveniToolStripMenuItem.Click += new System.EventHandler(this.nastaveniToolStripMenuItem_Click);
            // 
            // tahTextBox1
            // 
            this.tahTextBox1.AutoSize = true;
            this.tahTextBox1.Location = new System.Drawing.Point(434, 41);
            this.tahTextBox1.Name = "tahTextBox1";
            this.tahTextBox1.Size = new System.Drawing.Size(0, 13);
            this.tahTextBox1.TabIndex = 13;
            // 
            // PoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.tahTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PoleForm";
            this.Text = "Piškvorky";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem hraToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nováHraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nastaveniToolStripMenuItem;
        private System.Windows.Forms.Label tahTextBox1;
    }
}

