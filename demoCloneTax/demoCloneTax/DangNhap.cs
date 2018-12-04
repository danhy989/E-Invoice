using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoCloneTax
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.ToString();
            String password = textBox2.Text.ToString();
            String query = "select idTaiKhoan from TaiKhoan where TenTaiKhoan='" + username + "' AND MatKhau='" + password + "'";
            String result = DataProvide.Instance.ExecuteReader(query);
            if (result != null)
            {
                MessageBox.Show("Bạn đã đăng nhập thành công");
                Main form = new Main();
                this.Close();
                form.Show();
               

            }
            else
            {
                MessageBox.Show("Bạn đã đăng nhập thất bại");
            }
        }
    }
}
