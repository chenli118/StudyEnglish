namespace StudyEnglish
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTop = new Panel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            buttonPrevious = new Button();
            buttonNext = new Button();
            pnlMain = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(comboBox1);
            pnlTop.Controls.Add(buttonPrevious);
            pnlTop.Controls.Add(buttonNext);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1195, 61);
            pnlTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(36, 15);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Items.AddRange(new object[] { "Top5000Vocabulary", "XDFHighSchool", "NewCentury202010", "OxfordV10" });
            comboBox1.Location = new Point(163, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Location = new Point(502, 12);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(94, 49);
            buttonPrevious.TabIndex = 1;
            buttonPrevious.Text = "前一个";
            buttonPrevious.UseVisualStyleBackColor = true;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(307, 12);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(78, 49);
            buttonNext.TabIndex = 0;
            buttonNext.Text = "下一个";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(panel1);
            pnlMain.Controls.Add(panel2);
            pnlMain.Controls.Add(panel3);
            pnlMain.Controls.Add(panel4);
            pnlMain.Controls.Add(panel5);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 61);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1195, 580);
            pnlMain.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1195, 580);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1195, 580);
            panel2.TabIndex = 1;
            panel2.Visible = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1195, 580);
            panel3.TabIndex = 1;
            panel3.Visible = false;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1195, 580);
            panel4.TabIndex = 1;
            panel4.Visible = false;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1195, 580);
            panel5.TabIndex = 1;
            panel5.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 641);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "Form1";
            Text = "个人单词本";
            pnlTop.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlMain;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel1;
        private Button buttonPrevious;
        private Button buttonNext;
        private ComboBox comboBox1;
        private Label label1;
    }
}