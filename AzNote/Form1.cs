using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AzNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void saveDlg()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "AzNoteFile.txt";
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    MessageBox.Show("You file is sucssesfully saved!");
            }
        } //Save File

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you wannt to Save current work?","New File...",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (res==DialogResult.Yes)
            {
                saveDlg();
            }
            else
            {
                richTextBox1.Clear();
            }
        }  //NewFile

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openFileDialog1.Title = "Select Text File to Open!";
               // openFileDialog1.Filter = "Text Files Only";
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        } //Open File

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            saveDlg();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Bold);
        }  //Bold font

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Regular);
        }  //Itallic font

        private void bunifuImageButton6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Regular);
        }  //Disable Bold Font

        private void bunifuImageButton7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Italic);
        }  //Disable Itallic Font

        private void bunifuImageButton6_MouseHover(object sender, EventArgs e)
        {
            
        }  //OnMouse Hover

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            DialogResult res = cd.ShowDialog();
            if (res==DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }      
        }  //Font color

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really wannt to Quit?","Quit?",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (res==DialogResult.Yes)
            {
                Application.Exit();
            }

        } //Aplcation Exit

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();

            DialogResult fdf = fd.ShowDialog();
            if (fdf == DialogResult.OK)
            {
                Font f = fd.Font;
                richTextBox1.Text = string.Format("Font:{0}", f.Name);
                richTextBox1.Font = f;
            }
        } //Change Font
    }
}
