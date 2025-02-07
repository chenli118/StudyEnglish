
using Microsoft.Data.Sqlite;
using System.Data;
using System.Text.RegularExpressions;

namespace StudyEnglish
{
    public partial class Form1 : Form
    {
        private Panel[] wizardPages;
        private int currentPageIndex = 0;
        List<Vocabulary> vocabularyList;
        static string TableName = "Top5000Vocabulary";
        public Form1()
        {
            InitializeComponent();
            InitializeWizardPages();
            ShowWizardPage(currentPageIndex);
        }
        private void InitializeWizardPages()
        {
            uc_Vocabulary uc_Vocabulary1 = new uc_Vocabulary();
            uc_Vocabulary1.Dock = DockStyle.Fill;
            uc_Vocabulary1.Location = new Point(0, 0);
            uc_Vocabulary1.Name = "uc_Vocabulary1";
            uc_Vocabulary1.WordStatusChanged += Uc_Vocabulary_WordStatusChanged;
            panel1.Controls.Add(uc_Vocabulary1);

            uc_Vocabulary uc_Vocabulary2 = new uc_Vocabulary();
            uc_Vocabulary2.Dock = DockStyle.Fill;
            uc_Vocabulary2.Location = new Point(0, 0);
            uc_Vocabulary2.Name = "uc_Vocabulary2";
            uc_Vocabulary2.WordStatusChanged += Uc_Vocabulary_WordStatusChanged;
            panel2.Controls.Add(uc_Vocabulary2);

            uc_Vocabulary uc_Vocabulary3 = new uc_Vocabulary();
            uc_Vocabulary3.Dock = DockStyle.Fill;
            uc_Vocabulary3.Location = new Point(0, 0);
            uc_Vocabulary3.Name = "uc_Vocabulary3";
            uc_Vocabulary3.WordStatusChanged += Uc_Vocabulary_WordStatusChanged;
            panel3.Controls.Add(uc_Vocabulary3);

            uc_Vocabulary uc_Vocabulary4 = new uc_Vocabulary();
            uc_Vocabulary4.Dock = DockStyle.Fill;
            uc_Vocabulary4.Location = new Point(0, 0);
            uc_Vocabulary4.Name = "uc_Vocabulary4";
            uc_Vocabulary4.WordStatusChanged += Uc_Vocabulary_WordStatusChanged;
            panel4.Controls.Add(uc_Vocabulary4);

            uc_Vocabulary uc_Vocabulary5 = new uc_Vocabulary();
            uc_Vocabulary5.Dock = DockStyle.Fill;
            uc_Vocabulary5.Location = new Point(0, 0);
            uc_Vocabulary5.Name = "uc_Vocabulary5";
            uc_Vocabulary5.WordStatusChanged += Uc_Vocabulary_WordStatusChanged;
            panel5.Controls.Add(uc_Vocabulary5);

            wizardPages = new Panel[]
            {
                panel1,
                panel2,
                panel3,
                panel4,
                panel5

            };
            try
            {
                vocabularyList = LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Uc_Vocabulary_WordStatusChanged(object? sender, EventArgs e)
        {
            LoadData();
            if (currentPageIndex == wizardPages.Length - 1) ShowWizardPage(0);
            else
                ShowWizardPage(currentPageIndex + 1);
        }

        private List<Vocabulary> LoadData()
        {
            using (var connection = new SqliteConnection("Data Source=data.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $" SELECT rank,Word,WordContent,Leve, IFNULL(Priority,5) as Priority,Repetition,LastTimestamp,Status,Memo from {TableName} where Word not in(SELECT Word from StudyLog) ORDER by rank LIMIT 0,5 ";

                using (var reader = command.ExecuteReader())
                {
                    vocabularyList = new List<Vocabulary>();
                    while (reader.Read())
                    {
                        var vb = new Vocabulary();
                        vb.Rank = reader.GetInt32(0);
                        vb.Word = reader.GetString(1);
                        vb.WordContent = reader.GetString(2);
                        vb.Leve = reader.GetString(3);
                        vb.Priority = reader.GetValue(4) == DBNull.Value ? 5 : reader.GetInt32(4);
                        vb.Repetition = reader.GetValue(5) == DBNull.Value ? null : reader.GetString(5);
                        vb.LastTimestamp = reader.GetValue(6) == DBNull.Value ? null : reader.GetString(6);
                        vb.Status = reader.GetValue(7) == DBNull.Value ? null : reader.GetString(7);
                        vb.Memo = reader.GetValue(8) == DBNull.Value ? null : reader.GetString(8);
                        vocabularyList.Add(vb);
                    }
                    reader.Close();
                }
            }
            return vocabularyList;
        }

        private void ShowWizardPage(int index)
        {
            if (vocabularyList != null && vocabularyList.Count > index)
            {
                var vb = vocabularyList[index];
                for (int i = 0; i < wizardPages.Length; i++)
                {
                    uc_Vocabulary uc = wizardPages[i].Controls[0] as uc_Vocabulary;
                    if (index != i)
                    {
                        wizardPages[i].Visible = false;
                        uc.ClearText();
                    }
                    else
                    {
                        wizardPages[index].Visible = true;
                        uc.Tag = vb;
                        uc.TableName = TableName;
                        uc.Word = vb.Word;
                        uc.WordContent = vb.WordContent;
                        uc.WordDic = vb.Leve;
                        uc.WordHot = vb.Priority.ToString();
                        uc.WordMemo = vb.Memo;
                        uc.WordRank = vb.Rank.ToString();
                        uc.SearchKey = vb.Word.Trim().Split(' ')[0];
                        uc.LoadData();
                    }
                }

            }
            currentPageIndex = index;
            UpdateNavigationButtons();
        }
        private void UpdateNavigationButtons()
        {
            buttonNext.Enabled = currentPageIndex < wizardPages.Length - 1;
            buttonPrevious.Enabled = currentPageIndex > 0;
            //buttonFinish.Enabled = currentPageIndex == wizardPages.Length - 1;
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < wizardPages.Length - 1)
            {
                ShowWizardPage(currentPageIndex + 1);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 0)
            {
                ShowWizardPage(currentPageIndex - 1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableName = this.comboBox1.SelectedItem.ToString();
            ShowWizardPage(comboBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Downloads\新世纪英汉大词典\新世纪英汉大词典.txt";
            string prefix = "<link href=\"ncecd.css\" rel=\"stylesheet\"/><span class=\"header\">";
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith(prefix)) continue;
                    string wordP = @"<span class=""header"">$P<\/span>";
                    string pattern = @"<span class=""header"">([^<]+)<\/span>";
                    Match match = Regex.Match(line, pattern);
                    if (match.Success)
                    {
                        string word = match.Groups[1].Value;
                        if (Regex.IsMatch(word, @"\d")) continue;

                        string pre = prefix + word + "</span>";
                        string strippedHtml = Regex.Replace(line.Substring(pre.Length), "<.*?>", "").Replace("&lt;", " ").Replace("&gt;", " ").Replace("/", " ");
                        Console.WriteLine(strippedHtml);
                        try
                        {
                            using (var connection = new SqliteConnection("Data Source=data.sqlite"))
                            {
                                connection.Open();

                                var command = connection.CreateCommand();
                                command.CommandText = $" insert into  NewCentury202010(Word,WordContent,Leve,Priority) values " +
                                                      $" (@Word,@WordContent,'AZ',3)";
                                command.Parameters.AddWithValue("@Word", word);
                                command.Parameters.AddWithValue("@WordContent", strippedHtml);
                                int exec = command.ExecuteNonQuery();
                                if (exec > 0) { System.Diagnostics.Debug.WriteLine($"======{word} inserted======="); }
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }

                }
                sr.Close();
            }
        }
    }
}