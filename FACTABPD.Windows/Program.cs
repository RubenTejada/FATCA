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
            container.Register<IAppConfiguration, XMLFATCAConfiguration>();
            container.Register<IApplicationLog, SessionApplicationLog>(Lifestyle.Singleton);
            container.Register<IFATCADataProvider, CSVFATCADataProvider>();
            container.Register<IFATCAParser, SimpleFATCAParser>();
            container.Register<IFATCAMapper, SimpleFATCAMapper>();
            container.Register<IFATCAValidator, SImpleFATCAValidator>();
            container.Register<IFATCAFileGenerator, XMLFATCAGenerator>();
            container.Register<IFATCAProcesor, FATCAProcesor>();
            container.Register<FATCAProcesor>();

            var proceso = container.GetInstance<IFATCAProcesor>();
            var configuracion = container.GetInstance<IAppConfiguration>();
            var applicationLog = container.GetInstance<IApplicationLog>();
           
            Application.Run(new FATCAGenerator(proceso,configuracion, applicationLog));
        }
    }
}
