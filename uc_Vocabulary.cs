using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglish
{
    public partial class uc_Vocabulary : UserControl
    {
        public string Word { get; set; }
        public string WordContent { get; set; }
        public string WordMemo { get; set; }
        public string WordRank { get; set; }
        public string WordHot { get; set; }
        public string WordDic { get; set; }
        public uc_Vocabulary()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            if (Word != null) { this.Tag = Word; lblWord.Text = Word; }
            if (WordRank != null) { lblRank.Text = WordRank; }
            if (WordDic != null) { lblDIC.Text = WordDic; }
            if (WordHot != null) { lblHot.Text = WordHot; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WordContent != null) { txtWordContent.Text = WordContent; }
            if (WordMemo != null) { txtMemo.Text = WordMemo; }
        }
        public void ClearText()
        {
            { txtWordContent.Text = string.Empty; }
            { txtMemo.Text = string.Empty; }
        }
        private void btnMemo_Click(object sender, EventArgs e)
        {

        }
    }
}
