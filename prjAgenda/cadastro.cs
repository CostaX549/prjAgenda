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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace prjAgenda
{
    public partial class cadastro : Form
    {

        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;
        public cadastro()
        {
            InitializeComponent();
            mDS = new DataSet();
            mCon = new MySqlConnection("Persist Security Info=false;server=127.0.0.1;database=bd_agenda;uid=root");

            mCon.Open();
            exibe();

        }
        public void exibe()
        {
            if(mCon.State == ConnectionState.Open)
            {
                mDS.Clear();
                mApater = new MySqlDataAdapter("SELECT * FROM tbl_contato", mCon);
                mApater.Fill(mDS, "dados");
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = mDS;
                dataGridView1.DataMember = "dados";
            }
        }
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
     
            MySqlCommand SQL = new MySqlCommand(
                "INSERT INTO tbl_contato (con_nome, con_tel, con_email, con_dtnasc) " +
                "VALUES (@nome, @tel, @email, @data)", mCon);

            SQL.Parameters.AddWithValue("@nome", txt_nome.Text);
            SQL.Parameters.AddWithValue("@tel", txt_tel.Text);
            SQL.Parameters.AddWithValue("@email", txt_email.Text);
            SQL.Parameters.AddWithValue("@data", txt_data.Text); 

        
            SQL.ExecuteNonQuery();

          
            MessageBox.Show("Cadastro Realizado");
            exibe();
        }
    }
}
