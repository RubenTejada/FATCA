﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FATCABPD.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BPD.FATCA.Procesor.FileGeneration.FATCAXMLGenerator p = new BPD.FATCA.Procesor.FileGeneration.FATCAXMLGenerator();
            p.GenerateFile(null);
        }
    }
}
