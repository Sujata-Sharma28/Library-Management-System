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
    public partial class Complete_Book_DetailsForm : Form
    {
        public Complete_Book_DetailsForm()
        {
            InitializeComponent();
        }

        private void Complete_Book_DetailsForm_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from et_issuebook where book_return_date is null");
            dgvIssuedBooks.DataSource = ds.Tables[0];

            DataSet ds1 = Connection.GetData("Select * from et_issuebook where book_return_date is not null");
            dgvReturnedBooks.DataSource = ds1.Tables[0];
        }
    }
}
