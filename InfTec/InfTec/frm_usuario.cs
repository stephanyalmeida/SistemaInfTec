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
    public partial class frm_usuario : Form
    {
        public frm_usuario()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("INSERT INTO USUARIO(IDUSER, USUARIO, LOGINS, SENHA, FONE, PERFIL) VALUES (@IDUSER, @USUARIO, @LOGINS, @SENHA, @FONE, @PERFIL)", sql);
            command.Parameters.Add("@IDUSER", SqlDbType.Int).Value = txtiduser.Text;
            command.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@LOGINS", SqlDbType.VarChar).Value = txtlogin.Text;
            command.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = txtsenha.Text;
            command.Parameters.Add("@FONE", SqlDbType.VarChar).Value = txtfone.Text;
            command.Parameters.Add("@PERFIL", SqlDbType.VarChar).Value = comboperfil.Text;

            if (txtiduser.Text != "" & txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != "" & comboperfil.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com sucesso!", "Martech Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtiduser.Text = "";
                    txtnome.Text = "";
                    txtlogin.Text = "";
                    txtsenha.Text = "";
                    comboperfil.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor digite todas as informações nos campos obrigatórios", "Martech Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("SELECT * FROM USUARIO WHERE IDUSER = @IDUSER", sql);
            command.Parameters.Add("@IDUSER", SqlDbType.Int).Value = txtiduser.Text;


            try
            {
                sql.Open();
                SqlDataReader drms = command.ExecuteReader();
                if (drms.HasRows == false)
                {
                    throw new Exception("ID não encontrado!");
                }
                drms.Read();
                txtiduser.Text = Convert.ToString(drms["IDUSER"]);
                txtnome.Text = Convert.ToString(drms["USUARIO"]);
                txtlogin.Text = Convert.ToString(drms["LOGINS"]);
                txtsenha.Text = Convert.ToString(drms["SENHA"]);
                txtfone.Text = Convert.ToString(drms["FONE"]);
                comboperfil.Text = Convert.ToString(drms["PERFIL"]);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtiduser.Text = "";
            txtnome.Text = "";
            txtlogin.Text = "";
            txtsenha.Text = "";
            txtfone.Text = "";
            comboperfil.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("UPDATE USUARIO SET USUARIO=@USUARIO, LOGINS = @LOGINS, SENHA =  @SENHA, FONE = @FONE, PERFIL =  @PERFIL WHERE IDUSER = @IDUSER", sql);
            command.Parameters.Add("@IDUSER", SqlDbType.Int).Value = txtiduser.Text;
            command.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@LOGINS", SqlDbType.VarChar).Value = txtlogin.Text;
            command.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = txtsenha.Text;
            command.Parameters.Add("@FONE", SqlDbType.VarChar).Value = txtfone.Text;
            command.Parameters.Add("@PERFIL", SqlDbType.VarChar).Value = comboperfil.Text;

            if (txtiduser.Text != "" & txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != "" & comboperfil.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!", "Martech - Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtiduser.Text = "";
                    txtnome.Text = "";
                    txtlogin.Text = "";
                    txtsenha.Text = "";
                    comboperfil.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor digite todas as informações nos campos obrigatórios", "Martech Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("DELETE FROM USUARIO WHERE IDUSER = @IDUSER", sql);
            command.Parameters.Add("@IDUSER", SqlDbType.Int).Value = txtiduser.Text;
            command.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@LOGINS", SqlDbType.VarChar).Value = txtlogin.Text;
            command.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = txtsenha.Text;
            command.Parameters.Add("@FONE", SqlDbType.VarChar).Value = txtfone.Text;
            command.Parameters.Add("@PERFIL", SqlDbType.VarChar).Value = comboperfil.Text;

            if (txtiduser.Text != "" & txtnome.Text != "" & txtlogin.Text != "" & txtsenha.Text != "" & comboperfil.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Dados excluídos com sucesso!", "Martech - Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtiduser.Text = "";
                    txtnome.Text = "";
                    txtlogin.Text = "";
                    txtsenha.Text = "";
                    comboperfil.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtiduser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
