using System;
using System.Collections.Generic;

namespace AlgoritmosOrdenamiento_Kimberly_Escobar
{
    // ===========================================================
    // Laboratorio 5 - Algoritmos de Ordenamiento en C#
    //
    // El programa registra números enteros y permite ordenarlos
    // usando tres algoritmos distintos (Bubble, Insertion y Merge),
    // ===========================================================
    class Program
    {
        static void Main(string[] args)
        {
            GestorDatos gestor = new GestorDatos();
            bool continuarEnElMenu = true;

            while (continuarEnElMenu)
            {
                ConsolaEstilo.MostrarMenu();
                string? opcionElegida = Console.ReadLine();

                switch (opcionElegida)
                {
                    case "1":
                        RegistrarNumeros(gestor);
                        break;

                    case "2":
                        ConsolaEstilo.MostrarTitulo("LISTA ACTUAL");
                        ConsolaEstilo.MostrarListaOriginal(gestor.ObtenerListaActual());
                        ConsolaEstilo.Pausar();
                        break;

                    case "3":
                        EjecutarOrdenamiento(gestor, "Bubble Sort");
                        break;

                    case "4":
                        EjecutarOrdenamiento(gestor, "Insertion Sort");
                        break;

                    case "5":
                        EjecutarOrdenamiento(gestor, "Merge Sort");
                        break;

                    case "6":
                        continuarEnElMenu = false;
                        Console.WriteLine();
                        ConsolaEstilo.MostrarExito("Gracias por usar el sistema. ¡Hasta luego!");
                        break;

                    default:
                        ConsolaEstilo.MostrarError("Esa opción no existe, intenta de nuevo.");
                        ConsolaEstilo.Pausar();
                        break;
                }
            }
        }

        // Opción 1: pide números uno por uno hasta que el usuario escriba "fin".
        static void RegistrarNumeros(GestorDatos gestor)
        {
            ConsolaEstilo.MostrarTitulo("REGISTRAR NÚMEROS");
            Console.WriteLine("Ingresa números enteros uno por uno (positivos o negativos).");
            Console.WriteLine("Escribe 'fin' cuando ya no quieras agregar más.\n");

            bool siguoIngresando = true;
            while (siguoIngresando)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Número: ");
                Console.ResetColor();

                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada) || entrada.Trim().ToLower() == "fin")
                {
                    siguoIngresando = false;
                }
                else if (int.TryParse(entrada, out int numeroConvertido))
                {
                    gestor.AgregarNumero(numeroConvertido);
                    ConsolaEstilo.MostrarExito($"  ✔ Se agregó {numeroConvertido} a la lista.");
                }
                else
                {
                    ConsolaEstilo.MostrarError("  ✘ Eso no es un número entero válido, intenta otra vez.");
                }
            }

            ConsolaEstilo.Pausar();
        }

        // Opciones 3, 4 y 5: llaman al algoritmo correspondiente y muestran
        // la lista original junto con la lista ya ordenada.
        static void EjecutarOrdenamiento(GestorDatos gestor, string algoritmo)
        {
            List<int> listaActual = gestor.ObtenerListaActual();

            if (listaActual.Count == 0)
            {
                ConsolaEstilo.MostrarTitulo(algoritmo.ToUpper());
                ConsolaEstilo.MostrarError("Todavía no hay números registrados. Ve primero a la opción 1.");
                ConsolaEstilo.Pausar();
                return;
            }

            ConsolaEstilo.MostrarTitulo(algoritmo.ToUpper());
            ConsolaEstilo.MostrarListaOriginal(listaActual);

            List<int> listaResultado;
            switch (algoritmo)
            {
                case "Bubble Sort":
                    listaResultado = gestor.OrdenarBurbuja();
                    break;
                case "Insertion Sort":
                    listaResultado = gestor.OrdenarPorInsercion();
                    break;
                default:
                    listaResultado = gestor.OrdenarPorMezcla();
                    break;
            }

            ConsolaEstilo.MostrarListaOrdenada(listaResultado, algoritmo);
            ConsolaEstilo.Pausar();
        }
    }
}
