using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class frmBookReport : Form
    {
        public frmBookReport()
        {
            InitializeComponent();
        }
        BookData BookData = new BookData();
        DataTable dtBooks;
        private void frmBookReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtBooks = BookData.GetBooks();
            dtBooks.PrimaryKey = new DataColumn[] { dtBooks.Columns["BookID"] };
            bsBooks.DataSource = dtBooks;
            dgvBooks.DataSource = bsBooks;
            bnBooks.BindingSource = bsBooks;
        }
    }
}
