using System;
using EJERCICIODEPUEBALABOTARIO2;
using System.Collections.Generic;
using static System.Console;

namespace EJERCICIO_DE_PUEBA_LABORATORIO_2.Objetos
{
    internal class Mecanico
    {
      public Mecanico() { }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; } = true;
        static List<Mecanico> mecanicos = new List<Mecanico>();

        static void AgregarMecanico()
        {
            Write("Nombre del Mecánico: ");
            string nombre = ReadLine();

            Write("Especialidad del Mecánico: ");
            string especialidad = ReadLine();

            Write("¿Está disponible? (si/no): ");
            string disponibleStr = ReadLine();
            bool disponible = disponibleStr.ToLower() == "si";

            Mecanico mecanico = new Mecanico
            {
                Nombre = nombre,
                Especialidad = especialidad,
                Disponible = disponible
            };

            mecanicos.Add(mecanico);
            WriteLine("Mecánico agregado exitosamente.");
        }
    }
}
