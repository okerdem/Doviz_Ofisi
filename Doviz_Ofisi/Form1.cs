using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sToday = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var vXMLFile = new XmlDocument();
            vXMLFile.Load(sToday);

            string sDolarAl = vXMLFile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string sDolarSat = vXMLFile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string sEuroAl = vXMLFile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string sEuroSat = vXMLFile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            labelEA.Text = sEuroAl;
            labelES.Text = sEuroSat;
            labelDS.Text = sDolarSat;
            labelDA.Text = sDolarAl;
        }

        private void buttonDA_Click(object sender, EventArgs e)
        {
            textBoxKur.Text = labelDA.Text;
        }

        private void buttonDS_Click(object sender, EventArgs e)
        {
            textBoxKur.Text = labelDS.Text;
        }

        private void buttonEA_Click(object sender, EventArgs e)
        {
            textBoxKur.Text = labelEA.Text;
        }

        private void buttonES_Click(object sender, EventArgs e)
        {
            textBoxKur.Text = labelES.Text;
        }

        private void textBoxMiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                labelTutar.Text = (Convert.ToDouble(textBoxMiktar.Text) * Convert.ToDouble(textBoxKur.Text)).ToString();
            }
            catch (Exception)
            {
                labelTutar.Text = "0";
            }
        }

        private void textBoxKur_TextChanged(object sender, EventArgs e)
        {
            textBoxKur.Text = textBoxKur.Text.Replace(".", ",");
        }
    }
}
