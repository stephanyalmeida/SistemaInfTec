using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfTec
{
    public partial class frm_principal : Form
    {
        public frm_principal()
        {
            InitializeComponent();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_usuario usu = new frm_usuario();
            usu.Show();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_login log = new frm_login();
            log.Show();
            this.Close();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cli = new frmCliente();
            cli.Show();
        }
    }
}
