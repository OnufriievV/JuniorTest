using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestJuniorWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogSelectFile.ShowDialog() == DialogResult.OK) ;
            {
                string fileName = openFileDialogSelectFile.FileName;
                Mapping mapping = new Mapping(fileName);
                mapping.ShowDialog();
                              
            }
        }
    }
}
