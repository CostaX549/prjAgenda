using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace prjAgenda
{
    public partial class Alterar_Contato : Form
    {
        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;
        public Alterar_Contato()
        {
            InitializeComponent();
            carregaCombo();
           
        }

        public void carregaCombo()
        {
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

        public void limpaCombo()
        {
            comboBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand("select * from tbl_contato where con_nome=@NomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            MySqlDataReader MySqlDR2 = SQL.ExecuteReader();
            MySqlDR2.Read();
            txtnome.Text =  MySqlDR2["con_nome"].ToString();
            txtemail.Text =  MySqlDR2["con_email"].ToString();
            txttel.Text = MySqlDR2["con_tel"].ToString();
            txtdata.Text =  MySqlDR2["con_dtnasc"].ToString();
            groupBox1.Visible = true;
            MySqlDR2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand(
    "UPDATE tbl_contato " +
    "SET con_nome = @nome, con_tel = @tel, con_email = @email, con_dtnasc = @data " +
    "WHERE con_nome = @nomePesquisado", mCon); 
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            SQL.Parameters.AddWithValue("@nome", txtnome.Text);
            SQL.Parameters.AddWithValue("@tel", txttel.Text);
            SQL.Parameters.AddWithValue("@email", txtemail.Text);
            SQL.Parameters.AddWithValue("@data", txtdata.Text);
            SQL.ExecuteNonQuery();
            MessageBox.Show("Cadastro Alterado");
            comboBox1.Text = "";
            limpaCombo();
            carregaCombo();
         
        }
      
    }
}
