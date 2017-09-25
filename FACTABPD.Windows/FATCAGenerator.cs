using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BPD.FATCA.Interfaces;

namespace FATCABPD.Windows
{
    public partial class FATCAGenerator : Form
    {
        private readonly IFATCAProcesor procesor;
        private readonly IAppConfiguration configuration;
        private readonly IApplicationLog applicationLog;
        private BindingSource LogSource;       

        public FATCAGenerator(IFATCAProcesor procesor, IAppConfiguration configuration,IApplicationLog applicationLog)
        {
            InitializeComponent();
            this.procesor = procesor;
            this.configuration = configuration;
            this.applicationLog = applicationLog;
            LogSource = new BindingSource();
        }

   

        private void Form_Load(object sender, EventArgs e)
        {
            lblInputInfo.Text = String.Format(lblInputInfo.Text, configuration.SourceFilesDirectory);
            lblOutputInfo.Text = String.Format(lblOutputInfo.Text, configuration.DestinationFilesDirectory);
            LogSource.DataSource= applicationLog.ProcessLogs();
            listapplicationLog.DataSource = LogSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            procesor.ProcessFATCA();
            LogSource.ResetBindings(false);
        }
    }
}
