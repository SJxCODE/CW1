using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM
{
    public partial class OTP : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sanket Joshi\Desktop\FBA\Fingerprint Based ATM\Project\ATM\Database1.mdf;Integrated Security=True");
        string op = "", Name1 = "", Bal = "", BankAC = "", BankName = "", Pin = "",Phone= "";
        public OTP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Name,Bal,Pin,BankAC,BankName,Phone from Reg where BankName = '"+comboBox1.Text+"' AND Phone = '"+textBox2.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                panel1.Visible = false;
                button1.Visible = true;
                comboBox1.Enabled = true;
                textBox2.Enabled = true;
                con.Close();
                textBox1.Focus();
                MessageBox.Show("No Data Present", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Name1 = ds.Tables[0].Rows[0][0].ToString();
                    Bal = ds.Tables[0].Rows[0][1].ToString();
                    Pin = ds.Tables[0].Rows[0][2].ToString();
                    BankAC = ds.Tables[0].Rows[0][3].ToString();
                    BankName = ds.Tables[0].Rows[0][4].ToString();
                    Phone = ds.Tables[0].Rows[0][5].ToString();

                    Random r = new Random();
                    op = r.Next(1000, 9999).ToString();
                    MessageBox.Show(op);
                    bool a = sendsms.SendSMS("+91" + Phone, "Your OTP is : " + op);
                    if (a)
                    {
                        panel1.Visible = true;
                        button1.Visible = false;
                        textBox2.Enabled = false;
                        MessageBox.Show("Message Sent Successfully", "Successfull !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please Check your Internet Connection", "Error in Sending Message !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    panel1.Visible = true;
                    button1.Visible = false;
                    comboBox1.Enabled = false;
                    textBox2.Enabled = false;
                }
                catch (Exception ep)
                {
                    panel2.Visible = false;
                    panel1.Visible = false;
                    button1.Visible = true;
                    textBox2.Enabled = true;
                    comboBox1.Enabled = false;
                    MessageBox.Show(ep.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo(op) == 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                textBox3.Focus();
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("OTP not Matched","Error !!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.CompareTo(Pin) == 0)
            {
                panel2.Visible = false;
                panel3.Visible = true;
                panel4.Visible = false;
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("OTP not Matched", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Withdraw w = new Withdraw(Name1,Bal,BankAC,BankName,Pin);
            w.MdiParent = this.MdiParent;
            this.Close();
            w.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mini m = new mini(Name1, Bal, BankAC, BankName, Pin);
            m.MdiParent = this.MdiParent;
            this.Close();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deposit d = new deposit(Name1, Bal, BankAC, BankName, Pin);
            d.MdiParent = this.MdiParent;
            this.Close();
            d.Show();
        }
    }
}
