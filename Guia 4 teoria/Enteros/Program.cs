namespace Enteros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Crear numero aleatorios de 32 y 64 
            Random rnd = new Random(12345);
            int cantidad = 100000;
            int[] numeros32 = GenerarEnterosAleatorios(cantidad, rnd);
            long[] numeros64 = GenerarEnteros64(cantidad, rnd);
            #endregion
            #region creacion de copia del arreglo para cada metodo de ordenamiento
            int[] copiaBurbuja = (int[])numeros32.Clone();
            long[] copiaBurbujaLong = (long[])numeros64.Clone();

            int[] copiaMerge = (int[])numeros32.Clone();
            long[] copiaMergeLong = (long[])numeros64.Clone();

            int[] copiaQuick = (int[])numeros32.Clone();
            long[] copiaQuickLong = (long[])numeros64.Clone();
            #endregion

            #region llamada a metodos de ordenamiento

            Burbuja(copiaBurbuja);
            Burbuja(copiaBurbujaLong);

            MergeSort(copiaMerge);
            MergeSort(copiaMergeLong);

            QuickSort(copiaQuick);


            #endregion




        }
        #region metodos de ordenamiento 
        #region burbuja
        static void Burbuja(int[] copiaBurbuja)
        {
            DateTime burInicio = DateTime.Now;
            for (int piv1 = 0; piv1 < copiaBurbuja.Length - 1; piv1++)
            {
                for (int piv2 = piv1 + 1; piv2 < copiaBurbuja.Length; piv2++)
                {
                    if (copiaBurbuja[piv1] > copiaBurbuja[piv2])
                    {
                        int aux = copiaBurbuja[piv2];
                        copiaBurbuja[piv2] = copiaBurbuja[piv1];
                        copiaBurbuja[piv1] = aux;
                    }
                }
            }
            DateTime burFin = DateTime.Now;
            TimeSpan Res = burFin - burInicio;
            Console.Write("Tiempo de BURBUJA-INT32: ");
            Console.WriteLine(Res.TotalMilliseconds);
            Console.ReadKey();
        }
        static void Burbuja(long[] copiaBurbujaLong)
        {
            DateTime burInicio = DateTime.Now;
            for (int piv1 = 0; piv1 < copiaBurbujaLong.Length - 1; piv1++)
            {
                for (int piv2 = piv1 + 1; piv2 < copiaBurbujaLong.Length; piv2++)
                {
                    if (copiaBurbujaLong[piv1] > copiaBurbujaLong[piv2])
                    {
                        long aux = copiaBurbujaLong[piv2];
                        copiaBurbujaLong[piv2] = copiaBurbujaLong[piv1];
                        copiaBurbujaLong[piv1] = aux;
                    }
                }
            }
            DateTime burFin = DateTime.Now;
            TimeSpan Res = burFin - burInicio;
            Console.Write("Tiempo de BURBUJA-INT64: ");
            Console.WriteLine(Res.TotalMilliseconds);
            Console.ReadKey();
        }


        #endregion

        #region merge
        static void MergeSort(int[] copiaMerge)
        {
            DateTime MerInicio = DateTime.Now;
            if (copiaMerge.Length <= 1) return;
            MergeSortRecursivo(copiaMerge, 0, copiaMerge.Length - 1);
            DateTime MerFin = DateTime.Now;
            TimeSpan Res = MerFin - MerInicio;
            Console.Write("Tiempo de MERGE-INT32: ");
            Console.WriteLine(Res.TotalMilliseconds);
            Console.ReadKey();
        }
        static void MergeSortRecursivo(int[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;
                MergeSortRecursivo(arreglo, izquierda, medio);
                MergeSortRecursivo(arreglo, medio + 1, derecha);
                Merge(arreglo, izquierda, medio, derecha);
            }
        }
        static void Merge(int[] arreglo, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            int[] izq = new int[n1];
            int[] der = new int[n2];

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


        static void MergeSort(long[] copiaMergeLong)
        {
            DateTime MerInicio = DateTime.Now;
            if (copiaMergeLong.Length <= 1) return;
            MergeSortRecursivo(copiaMergeLong, 0, copiaMergeLong.Length - 1);
            DateTime MerFin = DateTime.Now;
            TimeSpan Res = MerFin - MerInicio;
            Console.Write("Tiempo de MERGE-INT64: ");
            Console.WriteLine(Res.TotalMilliseconds);
            Console.ReadKey();
        }
        static void MergeSortRecursivo(long[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int medio = (izquierda + derecha) / 2;
                MergeSortRecursivo(arreglo, izquierda, medio);
                MergeSortRecursivo(arreglo, medio + 1, derecha);
                Merge(arreglo, izquierda, medio, derecha);
            }
        }
        static void Merge(long[] arreglo, int izquierda, int medio, int derecha)
        {
            int n1 = medio - izquierda + 1;
            int n2 = derecha - medio;

            long[] izq = new long[n1];
            long[] der = new long[n2];

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

        #region QuickSort
        static void QuickSort(int[] copiaQuick)
        {
            DateTime QuickInicio = DateTime.Now;
            QuickSortRecursivo(copiaQuick, 0, copiaQuick.Length - 1);
            DateTime QuickFin = DateTime.Now;
            TimeSpan Res = QuickFin - QuickInicio;
            Console.Write("Tiempo de BURBUJA-INT64: ");
            Console.WriteLine(Res.TotalMilliseconds);
            Console.ReadKey();
        }

        static void QuickSortRecursivo(int[] arreglo, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int p = Particion(arreglo, bajo, alto);
                QuickSortRecursivo(arreglo, bajo, p - 1);
                QuickSortRecursivo(arreglo, p + 1, alto);
            }
        }
        static int Particion(int[] arreglo, int bajo, int alto)
        {
            int pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    int temp = arreglo[i];
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;
                }
            }

            int temp2 = arreglo[i + 1];
            arreglo[i + 1] = arreglo[alto];
            arreglo[alto] = temp2;

            return i + 1;
        }


        #endregion
        static void QuickSortIterativo()
        { 
        
        }
        static void Selección()
        {

        }
        #endregion

        #region generar aleatorios
        static int[] GenerarEnterosAleatorios(int cantidad,Random rnd)
        {
            
            int[] arreglo = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = rnd.Next();
            }

            return arreglo;
        }
        







        public static long[] GenerarEnteros64(int cantidad, Random rnd)
        {
            long[] arreglo = new long[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = rnd.NextInt64();
            }

            return arreglo;
        }
        #endregion
    }
}
