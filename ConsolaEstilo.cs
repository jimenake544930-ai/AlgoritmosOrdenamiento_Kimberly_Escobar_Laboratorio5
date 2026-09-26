using System;
using System.Collections.Generic;

namespace AlgoritmosOrdenamiento_Kimberly_Escobar
{
    // Clase de diseño. Aquí vive todo lo relacionado a colores y textos
    // que se muestran en pantalla, para no andar repitiendo el mismo
    // Console.ForegroundColor en cada parte del programa.
    static class ConsolaEstilo
    {
        public static void MostrarMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("=========================================================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("   SISTEMA DE ALGORITMOS DE ORDENAMIENTO DataSolutions");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("=========================================================");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  [1] Registrar Números");
            Console.WriteLine("  [2] Mostrar Lista Actual");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  [3] Bubble Sort");
            Console.WriteLine("  [4] Insertion Sort");
            Console.WriteLine("  [5] Merge Sort");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  [6] Salir");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Selecciona una opción: ");
            Console.ResetColor();
        }

        public static void MostrarTitulo(string texto)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"--- {texto} ---");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        public static void MostrarListaOriginal(List<int> lista)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Lista original:  ");
            Console.ResetColor();
            MostrarNumeros(lista, ConsoleColor.White);
        }

        public static void MostrarListaOrdenada(List<int> lista, string nombreAlgoritmo)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"Lista ordenada ({nombreAlgoritmo}):  ");
            Console.ResetColor();
            MostrarNumeros(lista, ConsoleColor.Green);
        }

        private static void MostrarNumeros(List<int> lista, ConsoleColor color)
        {
            if (lista.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("(vacía, todavía no hay números registrados)");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = color;
            Console.WriteLine("[ " + string.Join(", ", lista) + " ]");
            Console.ResetColor();
        }

        public static void Pausar()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Presiona una tecla para volver al menú...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
