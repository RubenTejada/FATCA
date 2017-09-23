using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;
using BPD.FATCA.Interfaces;
using BPD.FATCA.Procesor;


namespace FATCABPD.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Registering types.
            Container container = new Container();
            container.Register<IFATCADataProvider, CSVFATCADataProvider>();
            container.Register<IFATCAParser, SimpleFATCAParser>();
            container.Register<IFATCAMapper, SimpleFATCAMapper>();
            container.Register<IFATCAValidator, SImpleFATCAValidator>();
            container.Register<IFATCAFileGenerator, XMLFATCAGenerator>();
            container.Register<FATCAProcesor>();

            var Proceso = container.GetInstance<FATCAProcesor>();

            Proceso.ProcessFATCA();


            Application.Run(new Form1());
        }
    }
}
