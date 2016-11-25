using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Date_of_Birth_Selector_Simple
{
    public partial class frmMain : Form
    {
        //get date & time from local machine.
        private static DateTime dt = DateTime.Now;
        //get current year;
        private int currentYear = dt.Year;
        //count run the first form
        private int count = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int startYear = currentYear - 200;
            int endYear = currentYear + 200;

            for (int i = startYear; i <= endYear; i++)
                cbYear.Items.Add("" + i);

            cbYear.SelectedItem = "" + currentYear;
            cbMonth.SelectedIndex = dt.Month-1;
            cbDay.SelectedItem = "" + dt.Day;

        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDay.Items.Clear();
            int month = cbMonth.SelectedIndex+1;
            int year = int.Parse(cbYear.SelectedItem+"");
        
            int days = DateTime.DaysInMonth(year, month);
            for(int i = 1; i <= days; i++)
                cbDay.Items.Add("" + i);
            cbDay.SelectedItem = "" + cbDay.SelectedItem;
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (count > 0)
            {
                cbDay.Items.Clear();
                int month = cbMonth.SelectedIndex + 1;
                int year = int.Parse(cbYear.SelectedItem + "");

                int days = DateTime.DaysInMonth(year, month);
                for (int i = 1; i <= days; i++)
                    cbDay.Items.Add("" + i);
                cbDay.SelectedItem = "" + cbDay.SelectedItem;
            }
            count = 1;
        }
    }
}
