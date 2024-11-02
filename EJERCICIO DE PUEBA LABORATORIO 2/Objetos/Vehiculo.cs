using System;
using static System.Console;

namespace EJERCICIO_DE_PUEBA_LABORATORIO_2.Objetos
{
    internal class Vehiculo
    {
        public Vehiculo() { }
        public string Marca       { get; set; }
        public string Modelo      { get; set; }
        public int    Año         { get; set; }
        public string Placa       { get; set; }
        public double Kilometraje { get; set; }
        public string Dueño       { get; set; }

        public bool EsVehiculoAntiguo()
        {
            int añoActual = DateTime.Now.Year;
            return (añoActual - Año > 10);
        }

        public void ActualizarKilometraje(double nuevoKilometraje)
        {
            try
            {
                if (nuevoKilometraje >= Kilometraje)
                {
                    Kilometraje = nuevoKilometraje;
                }
                else
                {
                    throw new ArgumentOutOfRangeException
                        ("El kilometraje no puede ser menor al actual.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                WriteLine($"Error: {ex.Message}");
                ReadLine();
            }
        }
    }
}