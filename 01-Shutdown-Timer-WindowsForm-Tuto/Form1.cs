using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _01_Shutdown_Timer_WindowsForm_Tuto
{
    public partial class Form1 : Form
    {
        TimeSpan timeLeft;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            CheckTextBoxValues();

            bool isStartable = true;

            try
            {
                timeLeft = new TimeSpan(Convert.ToInt32(txtHours.Text), Convert.ToInt32(txtMinutes.Text), Convert.ToInt32(txtSeconds.Text));
            }
            catch (FormatException ex)
            {
                isStartable = false;
                MessageBox.Show(ex.Message);
            }

            if (isStartable == true)
            {
                timer.Start();
                // Zeit richtig formatieren, von Seter to Timer
                lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");
                
            }
        }

        private void CheckTextBoxValues()
            //Wenn nix im Seter ist, dann = 0
        {
            if (txtHours.Text.Count() == 0)
                txtHours.Text = "0";

            if (txtMinutes.Text.Count() == 0)
                txtMinutes.Text = "0";

            if (txtSeconds.Text.Count() == 0)
                txtSeconds.Text = "0";

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            lblTimer.Text = timeLeft.ToString(@"hh\:mm\:ss");
            if (timeLeft.TotalSeconds <= 0)
            {
                timer.Stop();
                PerformAction();
            }
        }
        private void PerformAction()
        {
            if (rbShutDown.Checked == true)
                Process.Start("shutdown", "/s");
            else if (rbRestart.Checked == true)
                Process.Start("shutdown", "/r");
            else if (rbSavePower.Checked == true)
                Process.Start("rundll32.exe", "powrprof.dll,SetSuspendState");
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblTimer.Text = ("00:00:00");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void txtHours_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}