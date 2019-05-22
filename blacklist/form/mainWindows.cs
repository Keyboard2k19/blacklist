using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blacklist.bd;
using blacklist.form;

namespace blacklist.form
{
    public partial class mainWindows : Form
    {
        private static SqlConnection con;

        public mainWindows()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add add1 = new add();
            add1.Show();
        }

        private void mainWindows_Load(object sender, EventArgs e)
        {
            con = Connection.openConnection();
            SqlCommand comando = new SqlCommand("SELECT * FROM deudor", con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comando;
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            SqlCommand comando2 = new SqlCommand("SELECT * FROM compra", con);

            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = comando2;
            DataTable dt2 = new DataTable();

            adapter2.Fill(dt2);

            dataGridView2.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = Connection.openConnection();
            SqlCommand comando = new SqlCommand("SELECT * FROM deudor", con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comando;
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            wCompra p = new wCompra();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = Connection.openConnection();
            SqlCommand comando = new SqlCommand("SELECT * FROM compra", con);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comando;
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView2.DataSource = dt;

        }
    }
}
