using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_CSharpEgitimKampi301.Concrete;
using BusinessLayer.CSharpEgitimKampi301.Abstract;
using BusinessLayer.CSharpEgitimKampi301.Concrete;
using DataAccessLayer.CSharpEgitimKampi301.EntityFramework;

namespace PresentationLayer.CSharpEgitimKampi301
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal ());
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
            int id =int.Parse(textBox1.Text); 
            var value =_productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("silindi");
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            product.ProductPrice = decimal.Parse(textBox4.Text);
            product.ProductName = textBox2.Text;
            product.ProductDescription = textBox5.Text;
            product.ProductStock = int.Parse(textBox3.Text);
            _productService.TInsert(product);
            MessageBox.Show("eklendi");
        }   
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            comboBox1.DataSource = values;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value=_productService.TGetById(id);
            dataGridView1.DataSource = value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value =_productService.TGetById(id);
            value.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            value.ProductDescription= textBox5.Text; 
            value.ProductPrice=decimal.Parse(textBox4.Text); 
            value.ProductStock=int.Parse(textBox3.Text); 
            value.ProductName=textBox2.Text;
            _productService.TUpdate(value);
            MessageBox.Show("guncellendi");
        }
    }
}
