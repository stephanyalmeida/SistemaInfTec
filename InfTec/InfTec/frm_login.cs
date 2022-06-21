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

namespace InfTec
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("SELECT * FROM USUARIO WHERE LOGINS = @LOGINS AND SENHA = @SENHA", sql);
            command.Parameters.Add("@LOGINS", SqlDbType.VarChar).Value = txtfrmlogin.Text;
            command.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = txtfrmsenha.Text;

            try
            {
                sql.Open();
                SqlDataReader drms = command.ExecuteReader();
                if (drms.HasRows == false) { 
                    throw new Exception("Usuário ou senha incorreto!");
                 }
                drms.Read();
                MessageBox.Show("Login efetuado com sucesso, seja bem vindo","Sistema - Martech",MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_principal frmprin = new frm_principal();
                frmprin.Show();
                this.Visible = false;
            }
            

            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);  
            
            }
            finally
            {
                sql.Close();
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
