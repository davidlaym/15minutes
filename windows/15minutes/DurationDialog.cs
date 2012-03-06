using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _15minutes
{
    public partial class DurationDialog : Form
    {
        public DurationDialog()
        {
            InitializeComponent();

            lblHrs.DataBindings.Add(new Binding("Text", sldHrs, "Value", true, DataSourceUpdateMode.OnPropertyChanged, 0, "00 Hrs"));
            lblMin.DataBindings.Add(new Binding("Text", sldMin, "Value", true, DataSourceUpdateMode.OnPropertyChanged, 0, "00 Mins"));
        }

        public int Value
        {
            get { return (sldHrs.Value*60)+sldMin.Value; }
            set {
                var hrs = (int)Math.Truncate(value / 60d);
                var mins = value - (hrs*60);
                sldHrs.Value = hrs;
                sldMin.Value = mins;
            }
        }

    }
}
