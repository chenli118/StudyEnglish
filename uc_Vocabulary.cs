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
        public string TableName { get; set; } = "Top5000Vocabulary";

        public event EventHandler<EventArgs> WordStatusChanged;
        public uc_Vocabulary()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            if (Word != null) { lblWord.Text = Word; }
            if (WordRank != null) { lblRank.Text = WordRank; }
            if (WordDic != null) { lblDIC.Text = WordDic; }
            if (WordHot != null) { lblHot.Text = WordHot; }
            if (SearchKey != null) { txtSearch.Text = SearchKey; }
            if (WordMemo != null) { txtMemo.Text = WordMemo; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WordContent != null) { txtWordContent.Text = WordContent; }
        }
        public void ClearText()
        {
            { txtWordContent.Text = string.Empty; }
            { txtMemo.Text = string.Empty; }
        }
        private void btnMemo_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqliteConnection("Data Source=data.sqlite"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = $" update {TableName} set Memo=@Memo where Word='{Word}' ";
                    command.Parameters.AddWithValue("@Memo", txtMemo.Text.Trim());
                    int exec = command.ExecuteNonQuery();
                    if (exec > 0)
                    {
                        var vb = this.Tag as Vocabulary;
                        vb.Memo = txtMemo.Text.Trim();
                        MessageBox.Show("备注添加成功！", "添加备注", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
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

                // 第一次查询: 使用 Word LIKE
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT rank,Word,WordContent,Leve, IFNULL(Priority,5) as Priority,Repetition,LastTimestamp,Status,Memo FROM {TableName} WHERE Word LIKE @skey";
                command.Parameters.AddWithValue("@skey", "%" + skey + "%");

                bool hasResults = false;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)  // 判断是否有结果
                    {
                        hasResults = true;
                        while (reader.Read())
                        {
                            txtWordContent.Clear();
                            txtWordContent.Text += reader.GetString(1) + " : " + reader.GetString(2);
                            txtWordContent.Text += System.Environment.NewLine;
                        }
                    }
                    reader.Close();
                }

                // 如果没有结果，则执行第二次查询: 使用 WordContent LIKE
                if (!hasResults)
                {
                    command.CommandText = $"SELECT rank,Word,WordContent,Leve, IFNULL(Priority,5) as Priority,Repetition,LastTimestamp,Status,Memo FROM {TableName} WHERE WordContent LIKE @skey";

                    using (var reader = command.ExecuteReader())
                    {
                        txtWordContent.Clear();  // 清空旧内容
                        while (reader.Read())
                        {
                            txtWordContent.Text += reader.GetString(1) + " : " + reader.GetString(2);
                            txtWordContent.Text += System.Environment.NewLine;
                        }
                        reader.Close();
                    }
                }
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddWrdBook_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqliteConnection("Data Source=data.sqlite"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = $" insert into  VocabularyBook(Word,CreatOn,LastStudyTime,StudyTimes) values " +
                                          $" (@Word,'{DateTime.Now}','{DateTime.Now}',0)";
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
    }
}
