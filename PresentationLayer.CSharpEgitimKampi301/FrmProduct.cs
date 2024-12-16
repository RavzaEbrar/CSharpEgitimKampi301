using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.CSharpEgitimKampi301.Abstract;
using BusinessLayer.CSharpEgitimKampi301.Concrete;
using DataAccessLayer.CSharpEgitimKampi301.EntityFramework;

namespace PresentationLayer.CSharpEgitimKampi301
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource= values;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource= values;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //_productService.TDelete()
        }
    }
}
