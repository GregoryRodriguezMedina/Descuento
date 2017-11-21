using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Descuentos.Business
{
    public class Descuento
    {
        private decimal sueldoBruto;
       // decimal porcientoSFS, porcientoAFP, porcientoISR;
       private const int PORCENTAJE = 100;

        public Descuento(decimal bruto, decimal porcientoSFS, decimal porcientoAFP, decimal porcientoISR, decimal procientoInforte)
        {
            this.sueldoBruto = bruto;
            this.SFS = bruto * porcientoSFS / PORCENTAJE;
            this.AFP = bruto * porcientoAFP / PORCENTAJE;
            this.ISR = bruto * porcientoISR / PORCENTAJE;
            this.Infote = bruto * procientoInforte / PORCENTAJE;
        }

        /// <summary>
        /// Seguro Familiar de Salud (SFS)
        /// </summary>
        public decimal SFS { get;private set;}//1,276.80
        /// <summary>
        /// Aporte para Fondo de Pensiones (AFP)
        /// </summary>
        public decimal AFP { get; private set; }//1,205.80
        /// <summary>
        /// //Impuesto sobre la renta (ISR)
        /// </summary>
        public decimal ISR { get; private set; }//1,678.63 
                                                //   public decimal Factura { get; set; }//3,000.00

        public decimal Infote { get; private set; }//1,678.63 
        public decimal TotalDeducciones
        {
            get
            {
                return SFS + AFP + ISR;
            }
        }//7,161.23
    }
}
