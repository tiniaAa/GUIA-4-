namespace Reales_1._000._000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Crear numero aleatorios de 32 y 64 
            Random rnd = new Random(12345);
            int cantidad = 1000000;
            float[] numeros32 = GenerarReales32(cantidad, rnd);
            decimal[] numeros128 = GenerarReales128(cantidad, rnd);

            #endregion

            #region creación de copia del arreglo para cada método de ordenamiento
            float[] copiaBurbuja = (float[])numeros32.Clone();
            decimal[] copiaBurbujaDecimal = (decimal[])numeros128.Clone();

            float[] copiaMerge = (float[])numeros32.Clone();
            decimal[] copiaMergeDecimal = (decimal[])numeros128.Clone();

            float[] copiaQuick = (float[])numeros32.Clone();
            decimal[] copiaQuickDecimal = (decimal[])numeros128.Clone();

            float[] copiaQuickIT = (float[])numeros32.Clone();
            decimal[] copiaQuickITDecimal = (decimal[])numeros128.Clone();

            float[] copiaSeleccion = (float[])numeros32.Clone();
            decimal[] copiaSeleccionDecimal = (decimal[])numeros128.Clone();
            #endregion

            #region llamada a metodos de ordenamiento

            Burbuja(copiaBurbuja);
            Burbuja(copiaBurbujaDecimal);

            MergeSort(copiaMerge);
            MergeSort(copiaMergeDecimal);

            QuickSort(copiaQuick);
            QuickSort(copiaQuickDecimal);

            QuickSortIterativo(copiaQuickIT);
            QuickSortIterativo(copiaQuickITDecimal);

            Selección(copiaSeleccion);
            Selección(copiaSeleccionDecimal);
            #endregion


        }
        #region METODOS DE ORDENAMIENTO 
        #region BURBUJA
        static void Burbuja(float[] copiaBurbuja)
        {
            DateTime burInicio = DateTime.Now;

            for (int piv1 = 0; piv1 < copiaBurbuja.Length - 1; piv1++)
            {
                for (int piv2 = piv1 + 1; piv2 < copiaBurbuja.Length; piv2++)
                {
                    if (copiaBurbuja[piv1] > copiaBurbuja[piv2])
                    {
                        float aux = copiaBurbuja[piv2];
                        copiaBurbuja[piv2] = copiaBurbuja[piv1];
                        copiaBurbuja[piv1] = aux;
                    }
                }
            }

            DateTime burFin = DateTime.Now;
            TimeSpan Res = burFin - burInicio;
            Console.Write("Tiempo de BURBUJA-FLOAT (32 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static void Burbuja(decimal[] copiaBurbuja)
        {
            DateTime burInicio = DateTime.Now;

            for (int piv1 = 0; piv1 < copiaBurbuja.Length - 1; piv1++)
            {
                for (int piv2 = piv1 + 1; piv2 < copiaBurbuja.Length; piv2++)
                {
                    if (copiaBurbuja[piv1] > copiaBurbuja[piv2])
                    {
                        decimal aux = copiaBurbuja[piv2];
                        copiaBurbuja[piv2] = copiaBurbuja[piv1];
                        copiaBurbuja[piv1] = aux;
                    }
                }
            }

            DateTime burFin = DateTime.Now;
            TimeSpan Res = burFin - burInicio;
            Console.Write("Tiempo de BURBUJA-DECIMAL (128 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }


        #endregion

        #region MERGE
        static void MergeSort(float[] copiaMerge)
        {
            DateTime MerInicio = DateTime.Now;
            if (copiaMerge.Length <= 1) return;
            MergeSortRecursivo(copiaMerge, 0, copiaMerge.Length - 1);
            DateTime MerFin = DateTime.Now;
            TimeSpan Res = MerFin - MerInicio;
            Console.Write("Tiempo de MERGE-FLOAT (32 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static void MergeSortRecursivo(float[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;
                MergeSortRecursivo(arreglo, izquierda, medio);
                MergeSortRecursivo(arreglo, medio + 1, derecha);
                Merge(arreglo, izquierda, medio, derecha);
            }
        }

        static void Merge(float[] arreglo, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            float[] izq = new float[n1];
            float[] der = new float[n2];

            Array.Copy(arreglo, izquierda, izq, 0, n1);
            Array.Copy(arreglo, medio + 1, der, 0, n2);

            int i = 0, j = 0, k = izquierda;

            while (i < n1 && j < n2)
            {
                if (izq[i] <= der[j])
                {
                    arreglo[k++] = izq[i++];
                }
                else
                {
                    arreglo[k++] = der[j++];
                }
            }

            while (i < n1)
            {
                arreglo[k++] = izq[i++];
            }

            while (j < n2)
            {
                arreglo[k++] = der[j++];
            }
        }

        static void MergeSort(decimal[] copiaMerge)
        {
            DateTime MerInicio = DateTime.Now;
            if (copiaMerge.Length <= 1) return;
            MergeSortRecursivo(copiaMerge, 0, copiaMerge.Length - 1);
            DateTime MerFin = DateTime.Now;
            TimeSpan Res = MerFin - MerInicio;
            Console.Write("Tiempo de MERGE-DECIMAL (128 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static void MergeSortRecursivo(decimal[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;
                MergeSortRecursivo(arreglo, izquierda, medio);
                MergeSortRecursivo(arreglo, medio + 1, derecha);
                Merge(arreglo, izquierda, medio, derecha);
            }
        }

        static void Merge(decimal[] arreglo, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            decimal[] izq = new decimal[n1];
            decimal[] der = new decimal[n2];

            Array.Copy(arreglo, izquierda, izq, 0, n1);
            Array.Copy(arreglo, medio + 1, der, 0, n2);

            int i = 0, j = 0, k = izquierda;

            while (i < n1 && j < n2)
            {
                if (izq[i] <= der[j])
                {
                    arreglo[k++] = izq[i++];
                }
                else
                {
                    arreglo[k++] = der[j++];
                }
            }

            while (i < n1)
            {
                arreglo[k++] = izq[i++];
            }

            while (j < n2)
            {
                arreglo[k++] = der[j++];
            }
        }

        #endregion

        #region QUICKSORT RECURSIVO
        static void QuickSort(float[] copiaQuick)
        {
            DateTime QuickInicio = DateTime.Now;
            QuickSort(copiaQuick, 0, copiaQuick.Length - 1);
            DateTime QuickFin = DateTime.Now;
            TimeSpan Res = QuickFin - QuickInicio;
            Console.Write("Tiempo de QUICKSORT-FLOAT (32 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static void QuickSort(float[] arreglo, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int p = Particion(arreglo, bajo, alto);
                QuickSort(arreglo, bajo, p - 1);
                QuickSort(arreglo, p + 1, alto);
            }
        }

        static int Particion(float[] arreglo, int bajo, int alto)
        {
            float pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    float temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            float temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[alto];
            arreglo[alto] = temp2;

            return i + 1;
        }

        static void QuickSort(decimal[] copiaQuick)
        {
            DateTime QuickInicio = DateTime.Now;
            QuickSort(copiaQuick, 0, copiaQuick.Length - 1);
            DateTime QuickFin = DateTime.Now;
            TimeSpan Res = QuickFin - QuickInicio;
            Console.Write("Tiempo de QUICKSORT-DECIMAL (128 bits): ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static void QuickSort(decimal[] arreglo, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int p = Particion(arreglo, bajo, alto);
                QuickSort(arreglo, bajo, p - 1);
                QuickSort(arreglo, p + 1, alto);
            }
        }

        static int Particion(decimal[] arreglo, int bajo, int alto)
        {
            decimal pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    decimal temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            decimal temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[alto];
            arreglo[alto] = temp2;

            return i + 1;
        }

        #endregion

        #region QUICKSORT ITERATIVO 
        static void QuickSortIterativo(float[] copiaQuickIT)
        {
            DateTime QuickInicio = DateTime.Now;
            int bajo = 0;
            int alto = copiaQuickIT.Length - 1;

            int[] pila = new int[alto - bajo + 1];
            int tope = -1;

            pila[++tope] = bajo;
            pila[++tope] = alto;

            while (tope >= 0)
            {
                alto = pila[tope--];
                bajo = pila[tope--];

                int p = Particion1(copiaQuickIT, bajo, alto);

                if (p - 1 > bajo)
                {
                    pila[++tope] = bajo;
                    pila[++tope] = p - 1;
                }

                if (p + 1 < alto)
                {
                    pila[++tope] = p + 1;
                    pila[++tope] = alto;
                }
            }

            DateTime QuickFin = DateTime.Now;
            TimeSpan Res = QuickFin - QuickInicio;
            Console.Write("Tiempo de QUICKSORT(iterativo)-FLOAT: ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static int Particion1(float[] arreglo, int bajo, int alto)
        {
            float pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    float temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            float temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[alto];
            arreglo[alto] = temp2;

            return i + 1;

        }

        static void QuickSortIterativo(decimal[] copiaQuickIT)
        {
            DateTime QuickInicio = DateTime.Now;
            int bajo = 0;
            int alto = copiaQuickIT.Length - 1;

            int[] pila = new int[alto - bajo + 1];
            int tope = -1;

            pila[++tope] = bajo;
            pila[++tope] = alto;

            while (tope >= 0)
            {
                alto = pila[tope--];
                bajo = pila[tope--];

                int p = Particion2(copiaQuickIT, bajo, alto);

                if (p - 1 > bajo)
                {
                    pila[++tope] = bajo;
                    pila[++tope] = p - 1;
                }

                if (p + 1 < alto)
                {
                    pila[++tope] = p + 1;
                    pila[++tope] = alto;
                }
            }

            DateTime QuickFin = DateTime.Now;
            TimeSpan Res = QuickFin - QuickInicio;
            Console.Write("Tiempo de QUICKSORT(iterativo)-DECIMAL: ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        static int Particion2(decimal[] arreglo, int bajo, int alto)
        {
            decimal pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    decimal temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            decimal temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[alto];
            arreglo[alto] = temp2;

            return i + 1;
        }



        #endregion

        #region SELECCION 
        static void Selección(float[] arreglo)
        {
            DateTime selInicio = DateTime.Now;
            int n = arreglo.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arreglo[j] < arreglo[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    float temp = arreglo[i];
                    arreglo[i] = arreglo[minIndex];
                    arreglo[minIndex] = temp;
                }
            }

            DateTime selFin = DateTime.Now;
            TimeSpan Res = selFin - selInicio;
            Console.Write("Tiempo de SELECCION-FLOAT: ");
            Console.WriteLine(Res.TotalMilliseconds);


        }

        static void Selección(decimal[] arreglo)
        {
            DateTime selInicio = DateTime.Now;
            int n = arreglo.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arreglo[j] < arreglo[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    decimal temp = arreglo[i];
                    arreglo[i] = arreglo[minIndex];
                    arreglo[minIndex] = temp;
                }
            }

            DateTime selFin = DateTime.Now;
            TimeSpan Res = selFin - selInicio;
            Console.Write("Tiempo de SELECCION-DECIMAL: ");
            Console.WriteLine(Res.TotalMilliseconds);

        }

        #endregion 
        #region generar aleatorios
        public static float[] GenerarReales32(int cantidad, Random rnd)
        {
            float[] arreglo = new float[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = (float)(rnd.NextDouble() * 1000);
            }

            return arreglo;
        }

        public static decimal[] GenerarReales128(int cantidad, Random rnd)
        {
            decimal[] arreglo = new decimal[cantidad];

            for (int i = 0; i < cantidad; i++)
            {

                arreglo[i] = (decimal)(rnd.NextDouble() * 1000);
            }

            return arreglo;
        }
        #endregion
        #endregion
    }
}
