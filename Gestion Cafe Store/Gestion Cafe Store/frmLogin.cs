using Gestion_Cafe_Store.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cafe_Store
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;

            if (LogIn(userName, passWord))
            {
                frmTableManager _frmTable = new frmTableManager();
                this.Hide();
                _frmTable.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Utilisateur/Mot de passe est incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool LogIn(string username, string password)
        {
            return AccountDAO.Instance.LogIn(username, password);
        }
    }
}
