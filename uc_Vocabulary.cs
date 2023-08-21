using Microsoft.Data.Sqlite;
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
        public string SearchKey { get; set; }

        public event EventHandler<EventArgs> WordStatusChanged;
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
            if (SearchKey != null) { txtSearch.Text = SearchKey; }

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqliteConnection("Data Source=data.sqlite"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = $" insert into  StudyLog(Word,StudyTime,Status) values " +
                                          $" (@Word,'{DateTime.Now}',1)";
                    command.Parameters.AddWithValue("@Word", Word);
                    int exec = command.ExecuteNonQuery();
                    if (exec > 0)
                    {
                        if (WordStatusChanged != null)
                            WordStatusChanged(this, new EventArgs());
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string skey = txtSearch.Text;
            if (string.IsNullOrEmpty(skey.Trim())) return;
            using (var connection = new SqliteConnection("Data Source=data.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $" SELECT rank,Word,WordContent,Leve, IFNULL(Priority,5) as Priority,Repetition,LastTimestamp,Status,Memo from Top5000Vocabulary where Word  like @skey ";
                command.Parameters.AddWithValue("@skey", "%"+skey+"%");
                using (var reader = command.ExecuteReader())
                {
                    txtWordContent.Clear();
                    while (reader.Read())
                    {
                        txtWordContent.Text +=   reader.GetString(1) + " : " + reader.GetString(2);
                        txtWordContent.Text += System.Environment.NewLine;
                    }
                    reader.Close();
                }
            }

        }
    }
}
