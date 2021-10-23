using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            bool login = LoginTextBox.Text == "1";
            bool password = PassTextBox.Text == "1";
            if (login && password)
            {
                MessageBox.Show("Вы вошли!");
                
                adminForm.Show();
                Hide();
            }
        }
    }
    }

