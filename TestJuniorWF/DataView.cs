using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace TestJuniorWF
{
    public partial class DataView : Form
    {
        MyItem header;
        public DataView(MyItem _header)
        {
            InitializeComponent();
            header = _header;
            
            
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            string connectionString =  @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products.mdf") + ";Integrated Security=True";
            SqlConnection myConn = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("select * from products", myConn);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = myCommand;
            DataTable myDataTable = new DataTable();
            myDataAdapter.Fill(myDataTable);
            BindingSource myBS = new BindingSource();
            myBS.DataSource = myDataTable;
            dataGridView1.DataSource = myBS;
            myDataAdapter.Update(myDataTable);
            myConn.Close();

            string[] _header = header.ToStringArray();
            for (int i = 0; i < _header.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = _header[i];
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
