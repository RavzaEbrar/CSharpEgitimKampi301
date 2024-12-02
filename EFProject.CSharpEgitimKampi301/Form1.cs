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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        EgitimKampiEFTravelDbEntities2 db=new EgitimKampiEFTravelDbEntities2();
        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("silindi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values=db.TblGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = textBox2.Text;
            guide.GuideSurname = textBox3.Text;
            db.TblGuide.Add(guide); 
            db.SaveChanges();
            MessageBox.Show("eklendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textBox1.Text);
            var updateValue=db.TblGuide.Find(id);
            updateValue.GuideName = textBox2.Text;
            updateValue.GuideSurname = textBox3.Text;
            db.SaveChanges();
            MessageBox.Show("güncellendi","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var values=db.TblGuide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
