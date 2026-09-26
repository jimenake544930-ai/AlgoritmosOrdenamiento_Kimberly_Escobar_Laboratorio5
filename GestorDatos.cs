using System.Collections.Generic;

namespace AlgoritmosOrdenamiento_Kimberly_Escobar
{
    class GestorDatos
    {
        private List<int> numerosGuardados;

        public GestorDatos()
        {
            numerosGuardados = new List<int>();
        }

        // Agrega un número nuevo a la colección. Acepta positivos y negativos sin problema.
        public void AgregarNumero(int numero)
        {
            numerosGuardados.Add(numero);
        }

        // Regresamos una copia para que quien la reciba no pueda alterar
        // por accidente los datos originales que tenemos guardados aquí.
        public List<int> ObtenerListaActual()
        {
            return new List<int>(numerosGuardados);
        }

        // ---------------------------------------------------------
        // BUBBLE SORT
        // Compara parejas de elementos vecinos y los va intercambiando
        // cuando están en el orden incorrecto. Se repite pasada tras
        // pasada hasta que ya no hay nada que mover.
        // ---------------------------------------------------------
        public List<int> OrdenarBurbuja()
        {
            List<int> resultado = new List<int>(numerosGuardados); // Aqui pues trabajamos sobre una copia
            int total = resultado.Count;

            for (int vueltaExterna = 0; vueltaExterna < total - 1; vueltaExterna++)
            {
                bool huboIntercambioEstaVuelta = false;

                for (int posicion = 0; posicion < total - vueltaExterna - 1; posicion++)
                {
                    if (resultado[posicion] > resultado[posicion + 1])
                    {
                        int temporal = resultado[posicion];
                        resultado[posicion] = resultado[posicion + 1];
                        resultado[posicion + 1] = temporal;
                        huboIntercambioEstaVuelta = true;
                    }
                }

                // Si en toda una vuelta no movimos nada, ya quedó ordenada
                // y no tiene caso seguir recorriendo la lista de gratis.
                if (!huboIntercambioEstaVuelta)
                {
                    break;
                }
            }

            return resultado;
        }

        // ---------------------------------------------------------
        // INSERTION SORT
        // Va tomando un elemento a la vez y lo va insertando en la
        // posición que le corresponde dentro de la parte que ya está
        // ordenada, corriendo los demás elementos a la derecha.
        // ---------------------------------------------------------
        public List<int> OrdenarPorInsercion()
        {
            List<int> resultado = new List<int>(numerosGuardados);

            for (int indiceActual = 1; indiceActual < resultado.Count; indiceActual++)
            {
                int valorAInsertar = resultado[indiceActual];
                int indiceComparacion = indiceActual - 1;

                while (indiceComparacion >= 0 && resultado[indiceComparacion] > valorAInsertar)
                {
                    resultado[indiceComparacion + 1] = resultado[indiceComparacion];
                    indiceComparacion--;
                }

                resultado[indiceComparacion + 1] = valorAInsertar;
            }

            return resultado;
        }

        // ---------------------------------------------------------
        // MERGE SORT
        // Estrategia de divide y vencerás: partimos la lista en dos
        // mitades, ordenamos cada mitad por separado (de forma recursiva)
        // y al final las vamos combinando (mezclando) ya ordenadas.
        // ---------------------------------------------------------
        public List<int> OrdenarPorMezcla()
        {
            List<int> copiaInicial = new List<int>(numerosGuardados);
            return DividirYOrdenar(copiaInicial);
        }

        private List<int> DividirYOrdenar(List<int> lista)
        {
            // Un elemento (o ninguno) ya se considera ordenado por sí solo.
            if (lista.Count <= 1)
            {
                return lista;
            }

            int puntoMedio = lista.Count / 2;
            List<int> mitadIzquierda = lista.GetRange(0, puntoMedio);
            List<int> mitadDerecha = lista.GetRange(puntoMedio, lista.Count - puntoMedio);

            mitadIzquierda = DividirYOrdenar(mitadIzquierda);
            mitadDerecha = DividirYOrdenar(mitadDerecha);

            return MezclarDosListas(mitadIzquierda, mitadDerecha);
        }

        private List<int> MezclarDosListas(List<int> izquierda, List<int> derecha)
        {
            List<int> mezclaFinal = new List<int>();
            int i = 0;
            int j = 0;

            // Vamos comparando el frente de cada mitad y metiendo al
            // resultado el que sea más pequeño primero.
            while (i < izquierda.Count && j < derecha.Count)
            {
                if (izquierda[i] <= derecha[j])
                {
                    mezclaFinal.Add(izquierda[i]);
                    i++;
                }
                else
                {
                    mezclaFinal.Add(derecha[j]);
                    j++;
                }
            }

            // Si a alguna mitad le quedaron elementos sueltos, se agregan al final
            while (i < izquierda.Count)
            {
                mezclaFinal.Add(izquierda[i]);
                i++;
            }

            while (j < derecha.Count)
            {
                mezclaFinal.Add(derecha[j]);
                j++;
            }

            return mezclaFinal;
        }
    }
}
