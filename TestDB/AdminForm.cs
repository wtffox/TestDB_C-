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
    public partial class AdminForm : Form
    {
        UsersModel f;
        public AdminForm()
        {
            InitializeComponent();
            f = new UsersModel();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "homeAudioLibraryDataSet.Musicians". При необходимости она может быть перемещена или удалена.
            this.musiciansTableAdapter.Fill(this.homeAudioLibraryDataSet.Musicians);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "homeAudioLibraryDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.homeAudioLibraryDataSet.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UsersModel db = new UsersModel())
            {
                Users Obj = new Users();
                Obj.name = nameTextBox.Text;

                db.Users.Add(Obj);
                db.SaveChanges();
                dataGridView1.DataSource = db.Users.ToList();
                dataGridView1.Refresh();
                nameTextBox.Clear();
            }
        }

        private void musicianEnterButton_Click(object sender, EventArgs e)
        {
            using (UsersModel db = new UsersModel())
            {
                Musicians Obj = new Musicians();
                Obj.name = musicianTextBox.Text;

                db.Musicians.Add(Obj);
                db.SaveChanges();
                dataGridView2.DataSource = db.Musicians.ToList();
                dataGridView2.Refresh();
                musicianTextBox.Clear();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (UsersModel db = new UsersModel())
            {
                
                Users Obj = new Users();
                Obj.id = Convert.ToInt32(deleteNameTextBox.Text);
                Users u = db.Users.Find(Obj.id);
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                }
                dataGridView1.DataSource = db.Users.ToList();
                dataGridView1.Refresh();
                nameTextBox.Clear();

            }
        }

        private void deleteMusicianButton_Click(object sender, EventArgs e)
        {
            using (UsersModel db = new UsersModel())
            {

                Musicians Obj = new Musicians();
                Obj.id = Convert.ToInt32(deleteMusicianTextBox.Text);
                Musicians m = db.Musicians.Find(Obj.id);
                if (m != null)
                {
                    db.Musicians.Remove(m);
                    db.SaveChanges();
                }
                dataGridView2.DataSource = db.Musicians.ToList();
                dataGridView2.Refresh();
                musicianTextBox.Clear();

            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
             Environment.Exit(0);
        }
    }
}
