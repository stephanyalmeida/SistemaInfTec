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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("INSERT INTO CLIENTE(IDCLIENTE, NOME, ENDERECO, EMAIL, TELEFONE) VALUES (@IDCLIENTE, @NOME, @ENDERECO, @EMAIL, @TELEFONE)", sql);
            command.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = txtidcliente.Text;
            command.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = txtendereco.Text;
            command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = txtemail.Text;
            command.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = txtfone.Text;
            

            if (txtidcliente.Text != "" & txtnome.Text != "" & txtendereco.Text != "" & txtemail.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com sucesso!", "Martech - Cadastro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidcliente.Text = "";
                    txtnome.Text = "";
                    txtendereco.Text = "";
                    txtemail.Text = "";

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
            SqlCommand command = new SqlCommand("SELECT * FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE", sql);
            command.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = txtidcliente.Text;
            
           
                try
                {
                   sql.Open();
                   SqlDataReader drms = command.ExecuteReader();
                   if (drms.HasRows == false)
                   {
                      throw new Exception("ID não encontrado!");
                   }
                   drms.Read();
                   txtidcliente.Text = Convert.ToString(drms["IDCLIENTE"]);
                   txtnome.Text = Convert.ToString(drms["NOME"]);
                   txtendereco.Text = Convert.ToString(drms["ENDERECO"]);
                   txtemail.Text = Convert.ToString(drms["EMAIL"]);
                   txtfone.Text = Convert.ToString(drms["TELEFONE"]);

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
            txtidcliente.Text = "";
            txtnome.Text = "";
            txtendereco.Text = "";
            txtemail.Text = "";
            txtfone.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=INFTEC;Data Source=DESKTOP-3O6SOMD\\SQLEXPRESS");
            SqlCommand command = new SqlCommand("UPDATE CLIENTE SET NOME=@NOME, ENDERECO = @ENDERECO, EMAIL =  @EMAIL, TELEFONE = @TELEFONE WHERE IDCLIENTE = @IDCLIENTE", sql);
            command.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = txtidcliente.Text;
            command.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = txtendereco.Text;
            command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = txtemail.Text;
            command.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = txtfone.Text;


            if (txtidcliente.Text != "" & txtnome.Text != "" & txtendereco.Text != "" & txtemail.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com sucesso!", "Martech - Cadastro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidcliente.Text = "";
                    txtnome.Text = "";
                    txtendereco.Text = "";
                    txtemail.Text = "";

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
            SqlCommand command = new SqlCommand("DELETE FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE", sql);
            command.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = txtidcliente.Text;
            command.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtnome.Text;
            command.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = txtendereco.Text;
            command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = txtemail.Text;
            command.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = txtfone.Text;


            if (txtidcliente.Text != "" & txtnome.Text != "" & txtendereco.Text != "" & txtemail.Text != "")
            {
                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Dados Excluídos com sucesso!", "Martech - Excluir Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtidcliente.Text = "";
                    txtnome.Text = "";
                    txtendereco.Text = "";
                    txtemail.Text = "";
                    txtfone.Text = "";

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
    }
}
