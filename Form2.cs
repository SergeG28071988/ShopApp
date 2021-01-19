using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ShopApp
{
    public partial class Form2 : Form
    {
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyCorp.mdb";
        private OleDbConnection myConnection;

        public Form2()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myCorpDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.myCorpDataSet.Продажи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myCorpDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.myCorpDataSet.Клиенты);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.продажиTableAdapter.Fill(this.myCorpDataSet.Продажи);
            this.клиентыTableAdapter.Fill(this.myCorpDataSet.Клиенты);
        }
    }
}
