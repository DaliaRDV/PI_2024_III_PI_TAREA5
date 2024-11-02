using EJERCICIO_DE_PUEBA_LABORATORIO_2.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace EJERCICIODEPUEBALABOTARIO2
{
    public class Vehiculo : Object
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Placa { get; set; }
        public double Kilometraje { get; set; }

        public override string ToString()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, Placa: {Placa}, Kilometraje: {Kilometraje}";
        }
    }

    public class Cliente : Object
    {
        public string Nombre { get; set; }
        public string ID { get; set; }
        public string Telefono { get; set; }
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            Vehiculos.Add(vehiculo);
            WriteLine("Vehículo agregado exitosamente.");
        }

        public string GetNombreCompleto() => $"{Nombre} (ID: {ID})";

        public override string ToString() => $"{GetNombreCompleto()} - Tel: {Telefono}, Vehículos: {Vehiculos.Count}";
    }

    public class Mecanico : Object
    {

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

        public class Factura : Object
        {
            public int NumeroFactura { get; set; }
            public double Total { get; set; }
            public bool Pagado { get; set; }
            public string ClienteID { get; set; }

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

            public override string ToString() => $"Factura No: {NumeroFactura}, Total: L{Total}, Pagado: {Pagado}, ClienteID: {ClienteID}";
        }

        class Program
        {
            static List<Cliente> clientes = new List<Cliente>();
            static List<Mecanico> mecanicos = new List<Mecanico>();
            static List<Factura> facturas = new List<Factura>();
            static int numeroFactura = 1;

            static void Main(string[] args)
            {
                bool salir = false;
                while (!salir)
                {
                    WriteLine("\n      Seleccione una opción:            ");
                    WriteLine("1.         Agregar Cliente                ");
                    WriteLine("2.      Agregar Vehículo a Cliente        ");
                    WriteLine("3.      Asignar Trabajo a Mecánico        ");
                    WriteLine("4.          Crear Factura                 ");
                    WriteLine("5. Listar Clientes, Vehículos, y Mecánicos");
                    WriteLine("6.              Salir                     ");

                    string opcion = ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            AgregarCliente();
                            break;
                        case "2":
                            AgregarVehiculoCliente();
                            break;
                        case "3":
                            AgregarMecanico();
                            break;
                        case "4":
                            CrearFactura();
                            break;
                        case "5":
                            ListarInformacion();
                            break;
                        case "6":
                            salir = true;
                            break;
                        default:
                            WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            static void AgregarCliente()
            {
                Write("Nombre del Cliente: ");
                string nombre = ReadLine();

                Write("ID del Cliente: ");
                string id = ReadLine();

                Write("Teléfono del Cliente: ");
                string telefono = ReadLine();

                Cliente cliente = new Cliente { Nombre = nombre, ID = id, Telefono = telefono };
                clientes.Add(cliente);
                WriteLine("Cliente agregado exitosamente.");
            }

            static void AgregarVehiculoCliente()
            {
                Write("Ingrese ID del Cliente: ");
                string idCliente = ReadLine();
                Cliente cliente = clientes.Find(c => c.ID == idCliente);

                if (cliente != null)
                {
                    Vehiculo vehiculo = new Vehiculo();
                    Write("Marca del Vehículo: ");
                    vehiculo.Marca = ReadLine();
                    Write("Modelo del Vehículo: ");
                    vehiculo.Modelo = ReadLine();
                    Write("Año del Vehículo: ");
                    vehiculo.Año = int.Parse(ReadLine());
                    Write("Placa del Vehículo: ");
                    vehiculo.Placa = ReadLine();
                    Write("Kilometraje: ");
                    vehiculo.Kilometraje = double.Parse(ReadLine());

                    cliente.AgregarVehiculo(vehiculo);
                }
                else
                {
                    WriteLine("Cliente no encontrado.");
                }
            }

            static void AgregarMecanico()

            {
                Write("Ingrese Nombre del Mecánico: ");
                string nombre = ReadLine();

                Write("Especialidad del Mecánico: ");
                string especialidad = ReadLine();

                Console.Write("¿Está disponible? (si/no): ");
                bool disponible = ReadLine().Trim().ToLower() == "si";

                Mecanico mecanico = new Mecanico
                {
                    Nombre       = nombre,
                    Especialidad = especialidad,
                    Disponible   = disponible
                };

                mecanicos.Add(mecanico);
                WriteLine("Mecánico agregado exitosamente.");

            }

            static void CrearFactura()
            {
                Write("Ingrese ID del Cliente para facturar: ");
                string idCliente = ReadLine();
                Cliente cliente = clientes.Find(c => c.ID == idCliente);

                if (cliente != null)
                {
                    Factura factura = new Factura
                    {
                        NumeroFactura = numeroFactura++,
                        ClienteID = idCliente
                    };

                    Write("Ingrese los precios de servicios separados por espacio: ");
                    double[] precios = ReadLine().Split(' ').Select(double.Parse).ToArray();

                    factura.CalcularTotal(precios);
                    facturas.Add(factura);
                    WriteLine("Factura creada exitosamente.");
                }
                else
                {
                    WriteLine("Cliente no encontrado.");
                }
            }

            static void ListarInformacion()
            {
                WriteLine("\n--- Clientes ---");
                foreach (var cliente in clientes)
                {
                    WriteLine(cliente);
                    foreach (var vehiculo in cliente.Vehiculos)
                    {
                        WriteLine($"  - {vehiculo}");
                    }
                }

                WriteLine("\n--- Mecánicos ---");
                foreach (var nombre in mecanicos)
                {
                    WriteLine(nombre);
                }

                WriteLine("\n--- Facturas ---");
                foreach (var factura in facturas)
                {
                    WriteLine(factura);
                }
                ReadLine();
            }
        }
    }
}