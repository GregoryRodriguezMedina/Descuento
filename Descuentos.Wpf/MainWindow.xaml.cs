using Descuentos.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Descuentos.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Business.IngresoRequest MapIngreso()
        {
            return new IngresoRequest
            {
                SueldoBruto = this.txtSalario.Text.AsDecimal(),
                HorasExtras = this.txtHorasExtras.Text.AsInt(),
                OtrosIngresos = this.txtOtrosIngresos.Text.AsDecimal()
            };
        }

        private bool ValidIngreso(IngresoRequest ingreso)
        {

            bool valid = true;
            if (ingreso.SueldoBruto < 1)
                valid = false;

            return valid;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var ingreso = MapIngreso();

            if (ValidIngreso(ingreso))
            {
                Business.NominaService ns = new Business.NominaService();
                var result = ns.Calcular(ingreso);
                MapForm(result);
            }
            else MessageBox.Show("Debe especificar el salario.", "Información", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void MapForm(NominaResponse response)
        {
            this.txtAfp.Text = response.Descuento.AFP.ToString("N2");
            this.txtIsr.Text = response.Descuento.ISR.ToString("N2");
            this.txtSfs.Text = response.Descuento.SFS.ToString("N2");
            this.txtSueldoNeto.Text = response.SueldoNeto.ToString("N2");
            this.txtDescuentos.Text = response.Descuento.TotalDeducciones.ToString("N2");
            this.txtInfote.Text = response.Descuento.Infote.ToString("N2");
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtSalario.Clear();
            this.txtHorasExtras.Clear();
            this.txtOtrosIngresos.Clear();
            this.txtAfp.Clear();
            this.txtIsr.Clear();
            this.txtSfs.Clear();
            this.txtSueldoNeto.Clear();
            this.txtDescuentos.Clear();
            this.txtInfote.Clear();
        }
    }
}