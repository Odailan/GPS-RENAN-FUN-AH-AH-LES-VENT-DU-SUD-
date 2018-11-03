using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string TrameBrut;
        bool Valide;



        public Form1()
        {
            InitializeComponent();
            SPenvoie.Open();
            SPreception.Open();
            CbxTrameOkay.Visible = false;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            TrameBrut = SPreception.ReadExisting();
            /*TbxTrame.Text = TrameBrut;*/
            Valide = Traitement(TrameBrut) ;
            if (Valide == true)
            {
                CbxTrameOkay.Visible = true;
                CbxTrameOkay.Checked = true;

            }
            else
            {
                CbxTrameOkay.Visible = true;
                CbxTrameOkay.Checked = false;

            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            SPenvoie.Write(tbxTest2.Text);
            /*tbxTest2.Text = ("non"); 
            
            string txt = tbxTest2.Text;
            tbxTest2.Text = txt.Substring(2, 4);
            bool Valid = Traitement(tbxTest2.Text);
            if (Valid == true)
            {
                CbxTrameOkay.Checked = true;
            }
            else
            {
                CbxTrameOkay.Checked = false;
            }*/
                
        }

        public bool Traitement(string tramein)
        {
            if (tramein.Substring(0, 3) == "$GP")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private void BtnMesure_Click(object sender, EventArgs e)
        {
            SPreception.Open();



        }
    }
}
