
using Microsoft.Data.Sqlite;
using System.Data;

namespace StudyEnglish
{
    public partial class Form1 : Form
    {
        private Panel[] wizardPages;
        private int currentPageIndex = 0;
        DataTable dtVocabulary = null;
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
            panel1.Controls.Add(uc_Vocabulary1);

            uc_Vocabulary uc_Vocabulary2 = new uc_Vocabulary();
            uc_Vocabulary2.Dock = DockStyle.Fill;
            uc_Vocabulary2.Location = new Point(0, 0);
            uc_Vocabulary2.Name = "uc_Vocabulary2";
            panel2.Controls.Add(uc_Vocabulary2);

            uc_Vocabulary uc_Vocabulary3 = new uc_Vocabulary();
            uc_Vocabulary3.Dock = DockStyle.Fill;
            uc_Vocabulary3.Location = new Point(0, 0);
            uc_Vocabulary3.Name = "uc_Vocabulary3";
            panel3.Controls.Add(uc_Vocabulary3);

            uc_Vocabulary uc_Vocabulary4 = new uc_Vocabulary();
            uc_Vocabulary4.Dock = DockStyle.Fill;
            uc_Vocabulary4.Location = new Point(0, 0);
            uc_Vocabulary4.Name = "uc_Vocabulary4";
            panel4.Controls.Add(uc_Vocabulary4);

            uc_Vocabulary uc_Vocabulary5 = new uc_Vocabulary();
            uc_Vocabulary5.Dock = DockStyle.Fill;
            uc_Vocabulary5.Location = new Point(0, 0);
            uc_Vocabulary5.Name = "uc_Vocabulary5";
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
                dtVocabulary = LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private DataTable LoadData()
        {
            DataTable dataTable = new DataTable();
            using (var connection = new SqliteConnection("Data Source=data.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"select 	* from Top5000Vocabulary order by rank LIMIT 0,5     ";
                //command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                    reader.Close();
                }
            }
            return dataTable;
        }

        private void ShowWizardPage(int index)
        {
            if (dtVocabulary != null && dtVocabulary.Rows.Count > currentPageIndex)
            {
                DataRow dr = dtVocabulary.Rows[currentPageIndex];
                for (int i = 0; i < wizardPages.Length; i++)
                { 
                    if (index != i)
                    {
                        uc_Vocabulary uc1 = wizardPages[i].Controls[0] as uc_Vocabulary;
                        wizardPages[i].Visible = false;
                        uc1.ClearText();
                    } 
                }
                wizardPages[index].Visible = true;
                uc_Vocabulary uc = wizardPages[index].Controls[0] as uc_Vocabulary;
                uc.Word = dr["Word"].ToString();
                uc.WordContent = dr["WordContent"].ToString();
                uc.WordDic = dr["Leve"].ToString();
                uc.WordHot = dr["Priority"].ToString();
                uc.WordMemo = dr["Memo"].ToString();
                uc.WordRank = dr["Rank"].ToString();
                uc.LoadData(); 
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
    }
}