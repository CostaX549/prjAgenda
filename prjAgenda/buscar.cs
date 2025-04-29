using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace prjAgenda
{
    public partial class buscar : Form
    {
        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;
        public buscar()
        {
            InitializeComponent();
            mDS = new DataSet();
            mCon = new MySqlConnection("Persist Security Info=false;" + "server=127.0.0.1;database=bd_agenda;uid=root");
            mCon.Open();
            MySqlCommand SQL = new MySqlCommand("select con_nome from tbl_contato", mCon);
            MySqlDataReader MySqlDR = SQL.ExecuteReader();
            while (MySqlDR.Read())
            {
                comboBox1.Items.Add(MySqlDR["con_nome"].ToString());
            }
            MySqlDR.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand("select * from tbl_contato where con_nome=@NomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            MySqlDataReader MySqlDR2 = SQL.ExecuteReader();
            MySqlDR2.Read();
            lblnome.Text = "Nome: " + MySqlDR2["con_nome"].ToString();
            lbltel.Text = "Telefone: " + MySqlDR2["con_tel"].ToString();
            lblemail.Text = "E-mail: " + MySqlDR2["con_email"].ToString(); 
lbldata.Text = "Data de Nascimento: " + MySqlDR2["con_dtnasc"].ToString(); 
groupBox1.Visible = true;
            MySqlDR2.Close();
        }

        private void buscar_Load(object sender, EventArgs e)
        {

        }
    }
}
