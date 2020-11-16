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
    public partial class frmMaintainBooks : Form
    {
        public frmMaintainBooks()
        {
            InitializeComponent();
        }

        BookData BookData = new BookData();
        DataTable dtBooks;

        private void btnNew_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtBookID.Text);
            string Name = txtBookName.Text;
            float Price = float.Parse(txtBookPrice.Text);
            Book book = new Book { BookID = ID, BookName = Name, BookPrice = Price };
            //dtBooks.Rows.Add(book.BookID, book.BookName, book.BookPrice);
            BookData.AddBooks(book);
            LoadData();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmBookReport frmBookReport = new frmBookReport();
            frmBookReport.Show();
        }

        private void frmMaintainBooks_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dtBooks = BookData.GetBooks();
            dtBooks.PrimaryKey = new DataColumn[] { dtBooks.Columns["BookID"] };
            bsBooks.DataSource = dtBooks;
            
            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            txtBookPrice.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", bsBooks, "BookID");
            txtBookName.DataBindings.Add("Text", bsBooks, "BookName");
            txtBookPrice.DataBindings.Add("Text", bsBooks, "BookPrice");

            dgvBooks.DataSource = bsBooks;
            bsBooks.Sort = "BookPrice DESC";
            bnBooks.BindingSource = bsBooks;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int ID = dtBooks.Rows.Count + 1;
            txtBookID.Text = ID.ToString();
            txtBookName.Clear();
            txtBookPrice.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtBookID.Text);
            string Name = txtBookName.Text;
            float Price = float.Parse(txtBookPrice.Text);
            Book book = new Book { BookID = ID, BookName = Name, BookPrice = Price };
            BookData.UpdateBooks(book);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtBookID.Text);
            string Name = txtBookName.Text;
            float Price = float.Parse(txtBookPrice.Text);
            Book book = new Book { BookID = ID, BookName = Name, BookPrice = Price };
            BookData.DeleteBook(book);
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtBooks.DefaultView;
            string filter = "BookName like '%" + txtSearch.Text + "%'";
            dv.RowFilter = filter;
            lbTotalPrice.Text = "Total Price: " + dtBooks.Compute("SUM(BookPrice)", filter);
        }
    }
}
