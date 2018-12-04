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
    public partial class DangKy : Form
    {
        String MaSoThue;
        String DienThoai;
        String Email;
        public DangKy()
        {
            InitializeComponent();
        }
        public void getInfor()
        {
            MaSoThue = textBox1.Text.ToString();
            DienThoai = textBox2.Text.ToString();
            Email = textBox3.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getInfor();
            MessageBox.Show("Phần mềm chữ ký số đang chạy , lấy thông tin Chữ ký số");
            ChiTietToKhaiDangKy ct = new ChiTietToKhaiDangKy(MaSoThue,DienThoai,Email);
            this.Hide();
            ct.ShowDialog();

        }
    }
}
