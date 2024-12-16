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
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService;

        public Form1()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var deletedvalues=_categoryService.TGetById(id);
            _categoryService.TDelete(deletedvalues);
            MessageBox.Show("silindi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource= categoryValues;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName=textBox2.Text;
            category.CategoryStatus=true;
            _categoryService.TInsert(category);
            MessageBox.Show("eklendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textBox1.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Category category =new Category();
            int updateId=int.Parse(textBox1.Text);
            var updatedvalues = _categoryService.TGetById(updateId);
            updatedvalues.CategoryName=textBox2.Text;
            updatedvalues.CategoryStatus=true;
            _categoryService.TUpdate(updatedvalues);
            MessageBox.Show("güncellendi");
        }
    }
}
