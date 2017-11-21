using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Descuentos.Business
{
    public partial class NominaService
    {
        int horasLaborales;
        decimal porcientoSFS, porcientoAFP, porcientoISR, porcientoInfote;
       
        public NominaService()
        {
            porcientoAFP = HelperService.GetAppSetting(Constants.KeySenttingAFP).AsDecimal();
            porcientoSFS = HelperService.GetAppSetting(Constants.KeySenttingSFS).AsDecimal();
            
            //determinar el rango del salario
            porcientoISR = HelperService.GetAppSetting(Constants.KeySenttingISRRangoUno).AsDecimal();
            porcientoInfote = HelperService.GetAppSetting(Constants.KeySenttingInfote).AsDecimal();

            horasLaborales = HelperService.GetAppSetting(Constants.KeyHorasLaborales).AsInt();
        }

        public virtual NominaResponse Calcular(decimal sueldo, int extras = 0, decimal otros = 0)
        {
            IngresoRequest ingresos = new IngresoRequest(horasLaborales, sueldo, extras, otros);

            return Calcular(ingresos);
        }

        public virtual NominaResponse Calcular(IngresoRequest ingresos)
        {            
            var descuento = new Descuento(ingresos.TotalBruto, porcientoSFS, porcientoAFP, porcientoISR, porcientoInfote);

            return new NominaResponse
            {
                Ingresos = ingresos,
                Descuento = descuento
            };
        }
        /*
        private Descuento CalcularDescuento(Ingresos ingresos)
        {
            var descuento =

            return descuento;
        }
        //*/
    }
}
