using System;
using static System.Console;

namespace EJERCICIO_DE_PUEBA_LABORATORIO_2.Objetos
{
    internal class Cliente
    {
        public Cliente() { }
        public string Nombre { get; set; }
        public string ID { get; set; }
        public string Telefono { get; set; }
        public Vehiculo[] Vehiculos { get; set; } = new Vehiculo[5];

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            for (int i = 0; i < Vehiculos.Length; i++)
            {
                if (Vehiculos[i] == null)
                {
                    Vehiculos[i] = vehiculo;
                    WriteLine("Vehículo agregado con éxito.");
                    return;
                }
            }
            WriteLine("No es posible agregar más vehículos.");
        }

        public string GetNombreCompleto() => $"{Nombre} (ID: {ID})";
       
    }
}
