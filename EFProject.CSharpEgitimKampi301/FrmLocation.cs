using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject.CSharpEgitimKampi301
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        egitimkampiefTravelEntities db =new egitimkampiefTravelEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var values =db.TblLocaiton.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname, x.GuideId
               
            }).ToList();

            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "GuideId";
            comboBox1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblLocaiton location=new TblLocaiton();
            location.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            location.LocationCity=textBox2.Text;
            location.LocationCountry=textBox3.Text;
            location.LocationPrice = decimal.Parse(textBox4.Text);
            location.DayNight = textBox6.Text;
            location.GuideId=int.Parse(comboBox1.SelectedValue.ToString());
            db.TblLocaiton.Add(location);
            db.SaveChanges();
            MessageBox.Show("Eklendi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var deletedValue = db.TblLocaiton.Find(id);
            db.TblLocaiton.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var updateValue = db.TblLocaiton.Find(id);
            updateValue.DayNight=textBox3.Text;
            updateValue.LocationPrice=decimal.Parse(textBox4.Text);
            updateValue.LocationCapacity=byte.Parse(numericUpDown1.Value.ToString());
            updateValue.LocationCity=textBox2.Text;
            updateValue.LocationCountry=textBox3.Text;
            updateValue.GuideId=int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("güncellendi");

        }
    }
}
