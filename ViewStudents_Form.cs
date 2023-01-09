using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_Syatem
{
    public partial class ViewStudents_Form : Form
    {
        int id;
        Int64 rowid;
        public ViewStudents_Form()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnroll.Clear();
            panel2.Visible = false;
        }

        private void ViewStudents_Form_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            DataSet ds = Connection.GetData("Select * from mst_student");
            dgvViewStudents.DataSource = ds.Tables[0];
        }

        private void dgvViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvViewStudents.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(dgvViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString());
                {
                    //MessageBox.Show(DataGridViewBook.Rows[e.RowIndex].Cells.[0].Value.ToString());
                }
                panel2.Visible = true;
                DataSet ds = Connection.GetData("Select * from mst_student where id= " + id + "");

                rowid = (Int64.Parse(ds.Tables[0].Rows[0][0].ToString()));
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtEnrollment.Text = ds.Tables[0].Rows[0][2].ToString();
                txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Updated. Confirm", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                String sname = txtName.Text;
                String enroll = txtEnrollment.Text;
                String dep = txtDepartment.Text;
                String sem = txtSemester.Text;
                String contact = txtContact.Text;
                String email = txtEmail.Text;


                String error = Connection.SetData("Update mst_student set sname = '" + sname + "', enroll = '" + enroll + "', " +
                    " dep ='" + dep + "' , sem = '" + sem + "' , contact = '" + contact + "',  email =  '" + email + "' where id= " + rowid + " ");
                if (error == "")
                {
                    MessageBox.Show("Data Saved.", " Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error in Saving : " + error);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted. Confirm", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                String error = Connection.SetData("Delete from mst_student where id= '" + rowid + "' ");
                if (error == "")
                {
                    MessageBox.Show("Employee Record Deleted..");

                }
                else
                {
                    MessageBox.Show("Error is Delete Message.." + error);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtEnroll_TextChanged(object sender, EventArgs e)
        {

            if (txtEnroll.Text != "")
            {
                DataSet ds = Connection.GetData("Select * from mst_student where enroll LIKE'" + txtEnroll.Text + "%'");
                dgvViewStudents.DataSource = ds.Tables[0];
            }
            else
            {
                DataSet ds = Connection.GetData("Select * from mst_student");
                dgvViewStudents.DataSource = ds.Tables[0];

            }
        }
    }
}
