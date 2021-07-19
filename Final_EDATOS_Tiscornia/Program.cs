using System;
using System.Collections.Generic;
using System.IO;

namespace Final_EDATOS_Tiscornia
{
    class Program
    {
        static void Main(string[] args)
        {
            byte opcion;
            int contador = 0;
            Queue<int> coladepedidos = new Queue<int>();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Bienvenido al centro de Pedidos");
            Console.ReadLine();
            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine("Para crear una cola marque 1");
                Console.WriteLine("Para borrar una cola marque 2");
                Console.WriteLine("Para crear un pedido marque 3");
                Console.WriteLine("Para borrar un pedido marque 4");
                Console.WriteLine("Para listar todos los pedidos marque 5");
                Console.WriteLine("Para listar el primer pedido marque 6");
                Console.WriteLine("Para listar el último pedido marque 7");
                Console.WriteLine("Para ver la cantidad de pedidos marque 8");
                Console.WriteLine("Para buscar un pedido marque 9");
                Console.WriteLine("Para guardar la cola como archivo .txt marque 10");
                Console.WriteLine("Para salir marque otro número");
                opcion = Convert.ToByte(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Crearemos una cola de pedidos: ");
                        coladepedidos = new Queue<int>();
                        Console.WriteLine("Se creo la cola de pedidos");
                        Console.ReadLine(); break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Borraremos una cola de pedidos: ");
                        coladepedidos.Clear();
                        Console.ReadLine(); break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese el número de pedido: ");
                        int pedido = Convert.ToInt32(Console.ReadLine());
                        if (pedido < 999 & pedido > 0)
                        { coladepedidos.Enqueue(pedido); break; }
                        else
                        {
                            Console.WriteLine("El número de pedido debe ser mayor a 0 y menor a 999");
                            Console.ReadLine(); break;
                        }
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Vamos a borrar el primer pedido de la lista: ");
                        coladepedidos.Dequeue();
                        contador = 0;
                        foreach (int orden in coladepedidos)
                        {
                            contador++;
                            Console.WriteLine("{0} - {1} ", contador, orden);
                        }
                        Console.ReadLine(); break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Veamos los pedidos en la cola");
                        contador = 0;
                        foreach (int orden in coladepedidos)
                        {
                            contador++;
                            Console.WriteLine("{0} - {1} ", contador, orden);
                        }

                        Console.ReadLine(); break;
                    case 6:
                        Console.Clear();
                        int primer = coladepedidos.Peek();
                        Console.WriteLine("El primer pedido es {0}.", primer);
                        Console.ReadLine(); break;
                    case 7:
                        Console.Clear();
                        List<int> lista1 = new List<int>();
                        foreach (int ultimo in coladepedidos)
                            lista1.Add(ultimo);
                        lista1.Reverse();
                        int ultimopedido = lista1[0];
                        Console.WriteLine("El último pedido es {0} ", ultimopedido);
                        Console.ReadLine(); break;
                    case 8:
                        Console.Clear();
                        int cantidad = coladepedidos.Count;
                        Console.WriteLine("La cola contiene {0} elementos.", cantidad);
                        Console.ReadLine(); break;
                    case 9:
                        Console.Clear();
                        bool resultado;
                        Console.WriteLine("Ingrese el pedido que busca: ");
                        int pedidobuscado = Convert.ToInt32(Console.ReadLine());

                        resultado = coladepedidos.Contains(pedidobuscado);
                        if (resultado)
                        {
                            Console.WriteLine("El pedido {0} se encuentra en la cola", pedidobuscado);
                        }
                        else
                        {
                            Console.WriteLine("El pedido {0} no se encuentra en la cola", pedidobuscado);
                        }
                        Console.ReadLine(); break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Ingresa el nombre con el que querés guardar la lista: ");

                        string archivo = Console.ReadLine() + ".txt";
                        TextWriter writer = File.CreateText(archivo);
                        foreach (int p in coladepedidos)
                        {
                            writer.WriteLine(p);
                        }
                        writer.Close();

                        Console.WriteLine("El archivo {0} ya está guardado", archivo);
                        Console.ReadLine(); break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Gracias, vuelva pronto!");
                        Console.ReadLine(); break;
                }
            } while (opcion > 0 & opcion < 11);
        }
    }
}
