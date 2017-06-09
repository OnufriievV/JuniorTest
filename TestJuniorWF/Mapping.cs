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
    public partial class Mapping : Form
    {
        string fileName;
        MyList myList;
        public Mapping(string _fileName)
        {
            InitializeComponent();
            fileName = _fileName;
            string[] str = null;
           
            using (StreamReader rd = new StreamReader(new FileStream(fileName, FileMode.Open)))
                str = rd.ReadToEnd().Split('\n');
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].TrimEnd('\r');
            }
            myList = new MyList(str);
            labelFileName.Text = Path.GetFileName(fileName);

            dataGridViewMapping.RowCount = myList.ColumnsNumber;
            int counter = 0;
            foreach (string s in myList.Header.ToStringArray())
            {
                dataGridViewMapping[0, counter].Value = s;
                counter++;
            }
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.Items.AddRange("NoMapped", "SKU", "Brand", "Price", "Weight", "Feature", "Product parameter", "Ignore");
            dataGridViewMapping.Columns.Insert(1,cmb);
            dataGridViewMapping.Columns[1].HeaderText = "Parameter";

            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
            {
                switch (dataGridViewMapping[0, i].Value.ToString())
                {
                    case "SKU":
                        {
                            dataGridViewMapping[1, i].Value = "SKU";
                            break;
                        }
                    case "Brand":
                        {
                            dataGridViewMapping[1, i].Value = "Brand";
                            break;
                        }
                    case "Price":
                        {
                            dataGridViewMapping[1, i].Value = "Price";
                            break;
                        }
                    case "Weight":
                        {
                            dataGridViewMapping[1, i].Value = "Weight";
                            break;
                        }
                    case "Feature":
                        {
                            dataGridViewMapping[1, i].Value = "Feature";
                            break;
                        }
                    case "Product parameter":
                        {
                            dataGridViewMapping[1, i].Value = "Product parameter";
                            break;
                        }
                    default:
                        {
                            dataGridViewMapping[1, i].Value = "NoMapped";
                            break;
                        }
                }
            }
            
            
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                dataGridViewMapping[2, i].Value = myList.ValueExamples(i);
            string sTemp = myList.IsHeaderValid();
            if (sTemp != "") MessageBox.Show(sTemp, "Warning");
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                dataGridViewMapping[3, i].Value = "";
            #region
            labelWarning.Text = "";
            int count = 0;

            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "NoMapped")
                {
                    labelWarning.Text = "Mark <NoMapped> is not expected";
                    return;
                }

            count = 0;
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "SKU")
                    count++;
            if (count > 1)
            {
                labelWarning.Text = "Only one mark <SKU> is expected";
                return;
            }
            else if (count < 1)
            {
                labelWarning.Text = "There is no mark <SKU> in the table";
                return;
            }

            count = 0;
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Brand")
                    count++;
            if (count > 1)
            {
                labelWarning.Text = "Only one mark <Brand> is expected";
                return;
            }
            else if (count < 1)
            {
                labelWarning.Text = "There is no mark <Brand> in the table";
                return;
            }

            count = 0;
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Price")
                    count++;
            if (count > 1)
            {
                labelWarning.Text = "Only one mark <Price> is expected";
                return;
            }
            else if (count < 1)
            {
                labelWarning.Text = "There is no mark <Price> in the table";
                return;
            }

            count = 0;
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Weight")
                    count++;
            if (count > 1)
            {
                labelWarning.Text = "Only one mark or no mark <Weight> is expected";
                return;
            }
            #endregion
            bool flag = false;
            int positionSKU = 0;
            int positionBrand = 0;
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "SKU")
                {
                    positionSKU = i;
                    string str = myList.IsEmptyItems(i);
                    if (str != "")
                    {
                        dataGridViewMapping[3, i].Value = str;
                        flag = true;
                    }
                }

            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Brand")
                {
                    positionBrand = i;
                    string str = myList.IsEmptyItems(i);
                    if (str != "")
                    {
                        dataGridViewMapping[3, i].Value = str;
                        flag = true;
                    }
                }

            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Price")
                {
                    string str = myList.IsEmptyNonDigitsItems(i);
                    if (str != "")
                    {
                        dataGridViewMapping[3, i].Value = str;
                        flag = true;
                    }
                }


            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
                if (dataGridViewMapping[1, i].Value.ToString() == "Weight")
                {
                    string str = myList.IsNonDigitsItems(i);
                    if (str != "")
                    {
                        dataGridViewMapping[3, i].Value = str;
                        flag = true;
                    }
                }
            if (myList.IsPositionSumUniq(positionSKU, positionBrand) == true)
            {
                labelWarning.Text = "There is at least one sum of <SKU> and <Brand> is not unique";
                flag = true;
            }
            if (flag == true) return;

            List<string> temp = new List<string>();
            for (int i = 0; i < dataGridViewMapping.RowCount; i++)
            {
                temp.Add(dataGridViewMapping[1, i].Value.ToString());
            }
            MyListDB myListDB = new MyListDB(myList, temp);

            string strDB = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products.mdf")+";Integrated Security=True";
            SqlConnection myConn = new SqlConnection(strDB);
            myConn.Open();

            strDB = "IF OBJECT_ID(N'dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;";
            SqlCommand sqlCommand = new SqlCommand(strDB, myConn);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = myListDB.StringCreateTable();
            sqlCommand.ExecuteNonQuery();
            for (int i = 0; i < myListDB.ItemsNumber; i++)
            {
                sqlCommand.CommandText = myListDB.StringFillDB(i);
                sqlCommand.ExecuteNonQuery();
            }
                        

            myConn.Close();
            //labelWarning.Text = "DONE";

            new DataView((myListDB.Header)).ShowDialog();
            
        }
    }
}
