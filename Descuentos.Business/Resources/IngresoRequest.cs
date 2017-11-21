using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Descuentos.Business
{
    public class IngresoRequest
    {
        private int horasLaborales;
        public IngresoRequest()
        {
            horasLaborales = HelperService.GetAppSetting(Constants.KeyHorasLaborales).AsInt();
        }
        public IngresoRequest(int horas, decimal bruto) : this(horas, bruto, 0, 0)
        {
        }

        public IngresoRequest(int horas, decimal bruto, int extras): this(horas, bruto, extras, 0)
        {
        }

        public IngresoRequest(int horas, decimal bruto, int extras, decimal otros)
        {
            this.horasLaborales = horas;
            this.SueldoBruto = bruto;
            this.HorasExtras = extras;
            this.OtrosIngresos = otros;
        }

        public decimal SueldoBruto { get; set; } //40,000.00        
        public decimal SueldoHoras { get; }
        public int HorasExtras { get; set; }//5,000.00
        public decimal MontoHorasExtras
        {
            get
            {
                if (HorasExtras < 1)
                    return 0;

                return (SueldoBruto / horasLaborales) * HorasExtras;
            }
        }
        public decimal OtrosIngresos { get; set; }//2,000.00
        public decimal TotalBruto
        {
            get
            {
                return SueldoBruto + MontoHorasExtras + OtrosIngresos;
            }
        }//47,000.00
    }
}
