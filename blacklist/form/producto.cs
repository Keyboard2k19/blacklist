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

namespace blacklist.form
{
    public partial class wCompra : Form
    {
        private static SqlConnection con;

        public wCompra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con = Connection.openConnection();

            String query = "INSERT INTO compra(monto,productos,fechaCompra, fk_idDeudor) VALUES " +
               "(@monto, @productos, @fechaCompra, @fk_idDeudor)";

            SqlCommand comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@monto", txtMonto.Text);
            comando.Parameters.AddWithValue("@productos", txtProducto.Text);
            comando.Parameters.AddWithValue("@fechaCompra", txtFecha.Text);
            comando.Parameters.AddWithValue("@fk_idDeudor", listBox1.SelectedItem);

            int retorno = comando.ExecuteNonQuery();

            if (retorno > 0)
            {
                MessageBox.Show("Se a registrado correctamente.");
            }
            else
            {
                MessageBox.Show("Ah ocurrido un error.");
            }


        }

        private void wCompra_Load(object sender, EventArgs e)
        {
            con = Connection.openConnection();
            SqlCommand comando = new SqlCommand("SELECT * FROM deudor", con);

            SqlDataReader dr = comando.ExecuteReader();

            
                while (dr.Read())
                {
                    this.listBox1.Items.Add(dr.GetInt32(0).ToString());
                    //this.listBox1.Items.Add(dr.GetString(1));
                }
            
        }
    }
}
