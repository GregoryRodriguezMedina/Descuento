using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Descuentos.Business
{
    public class NominaResponse
    {
        public IngresoRequest Ingresos { get; set; }
        public Descuento Descuento { get; set; }
        public decimal SueldoNeto
        {
            get
            {
                return Ingresos.SueldoBruto - Descuento.TotalDeducciones;
            }
        }
    }
}