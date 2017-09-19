using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FACTA.Domain
{
   public class FACTARecord
    {
        public string NombreFiler { get; set; }
        public string NumeroCalleFiler { get; set; }             
        public string ProvinciaFiler { get; set; }
        public string PaisFiler { get; set; }
        public string GiinFiler { get; set; }
        public string NombreCliente { get; set; }
        public string CalleNumero { get; set; }
        public string Provincia { get; set; }
        public string Tin { get; set; }
        public string Cuenta { get; set; }
        public string Moneda { get; set; }
        public string Balance { get; set; }
        public string Intereses { get; set; }
    }
}
