using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blacklist.bd;
using System.Data.SqlClient;

namespace blacklist.form
{
    public partial class add : Form
    {
        private static SqlConnection con;
        public add()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = Connection.openConnection();

            String query = "INSERT INTO deudor(nombre,telefono,dirección) VALUES " +
               "(@nombre, @telefono, @dirección)";

            SqlCommand comando = new SqlCommand(query, con);
            comando.Parameters.AddWithValue("@nombre", txtName.Text);
            comando.Parameters.AddWithValue("@telefono", txtPhone.Text);
            comando.Parameters.AddWithValue("@dirección", txtAddress.Text);

            int retorno = comando.ExecuteNonQuery();

            if(retorno > 0)
            {
                MessageBox.Show("Se a registrado correctamente.");
            }
            else
            {
                MessageBox.Show("Ah ocurrido un error.");
            }
        }
    }
}
