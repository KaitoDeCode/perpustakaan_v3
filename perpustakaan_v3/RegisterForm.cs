using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpustakaan_v3
{
    public partial class RegisterForm : Form
    {
        private utils utl = new utils();
        private DataClasses1DataContext db = new DataClasses1DataContext();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var err = utl.checkEmpty(textBox1.Text, textBox2.Text);
            if (err)
            {
                return;
            }

            try
            {
                var val1 = db.Akuns.FirstOrDefault(item => item.username == textBox1.Text);
                if(val1 != null)
                {
                    utl.msg("err","Username sudah digunakan");
                    return;
                }

                Akun newAkun = new Akun
                {
                    username = textBox1.Text,
                    password = textBox2.Text,
                };

                utl.msg("scs","Berhasil Register");
                db.Akuns.InsertOnSubmit(newAkun);
                db.SubmitChanges();
                LoginForm form = new LoginForm();
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                utl.msg("err", ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
    }
}
