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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities2 db=new EgitimKampiEFTravelDbEntities2();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            locationCount.Text= db.TblLocaiton.Count().ToString();
            sumCapacity.Text = db.TblLocaiton.Sum(x =>x.LocationCapacity).ToString();
            GuideCount.Text=db.TblGuide.Count().ToString();
            AvgCapacity.Text = db.TblLocaiton.Average(x => x.LocationCapacity)?.ToString("0.00");
            AvgLocationPrice.Text = db.TblLocaiton.Average(x => x.LocationPrice)?.ToString("0.00")+"$";
           
            int lastCountryId=db.TblLocaiton.Max(x => x.LocationId);
            LastCountryName.Text=db.TblLocaiton.Where(x =>x.LocationId==lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();

            CapadociaLocationCapacity.Text = db.TblLocaiton.Where(x => x.LocationCity=="Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            TürkiyeCapacityAvg.Text=db.TblLocaiton.Where(x => x.LocationCountry == "Türkiye ").Average(y => y.LocationCapacity).ToString();

            var romeGuideId=db.TblLocaiton.Where(x => x.LocationCity == "roma").Select(y => y.GuideId).FirstOrDefault();
            RomeGuideName.Text=db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacty = db.TblLocaiton.Max(x =>x.LocationCapacity);
            MaxCapacity.Text = db.TblLocaiton.Where(x => x.LocationCapacity==maxCapacty).Select(y=>y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.TblLocaiton.Max(x => x.LocationPrice);
            MaxPrıceLocation.Text = db.TblLocaiton.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideIdByNameAysegulCinar = db.TblGuide.Where(x=>x.GuideName=="Ayşegül"&& x.GuideSurname=="Çınar").Select(y=>y.GuideId).FirstOrDefault();
            AyşegülÇınarLocation.Text = db.TblLocaiton.Where(x=>x.GuideId   ==guideIdByNameAysegulCinar).Count().ToString();
             
        }
            
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AvgLocationPrice_Click(object sender, EventArgs e)
        {

        }
    }
}
