using System;
using System.Linq;
using static System.Console;

namespace EJERCICIO_DE_PUEBA_LABORATORIO_2.Objetos
{
    internal class Factura
    {
        public Factura() { }
        public int NumeroFactura { get; set; }
        public double Total { get; set; }
        public bool Pagado { get; set; }

        public void CalcularTotal(double[] preciosServicios)
        {
            try
            {
                Total = preciosServicios.Sum();
                WriteLine($"Total calculado: L{Total}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                WriteLine($"Error al calcular total: {ex.Message}");
            }
        }

        public void MarcarPagado() => Pagado = true;
       
    }
}
