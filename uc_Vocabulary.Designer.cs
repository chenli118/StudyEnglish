namespace StudyEnglish
{
    partial class uc_Vocabulary
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblDIC = new Label();
            label2 = new Label();
            lblHot = new Label();
            label3 = new Label();
            lblRank = new Label();
            label1 = new Label();
            txtWordContent = new RichTextBox();
            pnlLeft = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            btnMemo = new Button();
            txtMemo = new RichTextBox();
            panel3 = new Panel();
            button1 = new Button();
            lblWord = new Label();
            panel1.SuspendLayout();
            pnlLeft.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDIC);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblHot);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblRank);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 428);
            panel1.Name = "panel1";
            panel1.Size = new Size(812, 62);
            panel1.TabIndex = 0;
            // 
            // lblDIC
            // 
            lblDIC.AutoSize = true;
            lblDIC.Location = new Point(328, 21);
            lblDIC.Name = "lblDIC";
            lblDIC.Size = new Size(0, 20);
            lblDIC.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 21);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 4;
            label2.Text = "字典：";
            // 
            // lblHot
            // 
            lblHot.AutoSize = true;
            lblHot.Location = new Point(202, 21);
            lblHot.Name = "lblHot";
            lblHot.Size = new Size(0, 20);
            lblHot.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(153, 21);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "热度：";
            // 
            // lblRank
            // 
            lblRank.AutoSize = true;
            lblRank.Location = new Point(73, 21);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(0, 20);
            lblRank.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 21);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "排名：";
            // 
            // txtWordContent
            // 
            txtWordContent.BackColor = SystemColors.Control;
            txtWordContent.Dock = DockStyle.Fill;
            txtWordContent.Location = new Point(3, 3);
            txtWordContent.Name = "txtWordContent";
            txtWordContent.Size = new Size(706, 370);
            txtWordContent.TabIndex = 1;
            txtWordContent.Text = "";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(tableLayoutPanel1);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(812, 428);
            pnlLeft.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(txtWordContent, 0, 0);
            tableLayoutPanel1.Controls.Add(txtMemo, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.8504639F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1495323F));
            tableLayoutPanel1.Size = new Size(812, 428);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnMemo);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(715, 379);
            panel2.Name = "panel2";
            panel2.Size = new Size(94, 46);
            panel2.TabIndex = 0;
            // 
            // btnMemo
            // 
            btnMemo.Anchor = AnchorStyles.None;
            btnMemo.Location = new Point(1, 14);
            btnMemo.Name = "btnMemo";
            btnMemo.Size = new Size(94, 29);
            btnMemo.TabIndex = 0;
            btnMemo.Text = "添加备注";
            btnMemo.UseVisualStyleBackColor = true;
            btnMemo.Click += btnMemo_Click;
            // 
            // txtMemo
            // 
            txtMemo.Dock = DockStyle.Fill;
            txtMemo.Location = new Point(715, 3);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(94, 370);
            txtMemo.TabIndex = 1;
            txtMemo.Text = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(lblWord);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 379);
            panel3.Name = "panel3";
            panel3.Size = new Size(706, 46);
            panel3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(477, 10);
            button1.Name = "button1";
            button1.Size = new Size(162, 29);
            button1.TabIndex = 1;
            button1.Text = "显示单词中文";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblWord
            // 
            lblWord.AutoSize = true;
            lblWord.Location = new Point(17, 14);
            lblWord.Name = "lblWord";
            lblWord.Size = new Size(0, 20);
            lblWord.TabIndex = 0;
            // 
            // uc_Vocabulary
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlLeft);
            Controls.Add(panel1);
            Name = "uc_Vocabulary";
            Size = new Size(812, 490);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlLeft.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblRank;
        private Label label1;
        private Label label2;
        private Label lblHot;
        private Label label3;
        private Label lblDIC;
        private RichTextBox txtWordContent;
        private Panel pnlLeft;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Button btnMemo;
        private RichTextBox txtMemo;
        private Panel panel3;
        private Button button1;
        private Label lblWord;
    }
}
