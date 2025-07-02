namespace Strings
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PC usada: Ryzen 7, 8GB RAM, Windows 11 64-bit");
            #region Crear palabras aleatorias 8 y 32 caracteres
            Random rnd = new Random(12345);
            int cantidad = 100000;
            string[] palabras8 = GenerarStrings8(cantidad,rnd);
            string[] palabras32 = GenerarStrings32(cantidad,rnd);
            #endregion
            #region creacion de copia del arreglo para cada metodo de ordenamiento
            string[] copiaBurbuja = (string[])palabras8.Clone();
            string[] copiaBurbujaLong = (string[])palabras32.Clone();

            string[] copiaMerge = (string[])palabras8.Clone();
            string[] copiaMergeLong = (string[])palabras32.Clone();

            string[] copiaQuick = (string[])palabras8.Clone();
            string[] copiaQuickLong = (string[])palabras32.Clone();

            string[] copiaQuickIT = (string[])palabras8.Clone();
            string[] copiaQuickITLong = (string[])palabras32.Clone();

            string[] copiaSeleccion = (string[])palabras8.Clone();
            string[] copiaSeleccionLong = (string[])palabras32.Clone();

            #endregion

            #region llamada a metodos de ordenamiento

            Burbuja(copiaBurbuja);
            Burbuja(copiaBurbujaLong);

            Console.Write("Tiempo de MERGE-STRING 8: ");
            MergeSort(copiaMerge);

            Console.Write("Tiempo de MERGE-STRING 32: ");
            MergeSort(copiaMergeLong);

            QuickSort(copiaQuick);
            QuickSort(copiaQuickLong);

            QuickSortIterativo(copiaQuickIT);
            QuickSortIterativo(copiaQuickITLong);

            Selección(copiaSeleccion);
            Selección(copiaSeleccionLong);
            #endregion

        }
        #region metodos de ordenamiento 
        #region burbuja
        static void Burbuja(string[] arreglo)
        {
            DateTime inicio = DateTime.Now;

            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                for (int j = i + 1; j < arreglo.Length; j++)
                {
                    if (string.Compare(arreglo[i], arreglo[j]) > 0)
                    {
                        string temp = arreglo[i];
                        arreglo[i] = arreglo[j];
                        arreglo[j] = temp;
                    }
                }
            }

            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;
            Console.Write("Tiempo de BURBUJA-STRING: ");
            Console.WriteLine(duracion.TotalMilliseconds);
            
        }



        #endregion

        #region merge
        static void MergeSort(string[] arreglo)
        {
            DateTime inicio = DateTime.Now;

            if (arreglo.Length > 1)
                MergeSortRecursivo(arreglo, 0, arreglo.Length - 1);

            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;
            
            Console.WriteLine(duracion.TotalMilliseconds);
         
        }

        static void MergeSortRecursivo(string[] arreglo, int izq, int der)
        {
            if (izq < der)
            {
                int medio = (izq + der) / 2;
                MergeSortRecursivo(arreglo, izq, medio);
                MergeSortRecursivo(arreglo, medio + 1, der);
                Merge(arreglo, izq, medio, der);
            }
        }

        static void Merge(string[] arreglo, int izq, int medio, int der)
        {
            int n1 = medio - izq + 1;
            int n2 = der - medio;

            string[] L = new string[n1];
            string[] R = new string[n2];

            Array.Copy(arreglo, izq, L, 0, n1);
            Array.Copy(arreglo, medio + 1, R, 0, n2);

            int i = 0, j = 0, k = izq;

            while (i < n1 && j < n2)
            {
                if (string.Compare(L[i], R[j]) <= 0)
                    arreglo[k++] = L[i++];
                else
                    arreglo[k++] = R[j++];
            }

            while (i < n1) arreglo[k++] = L[i++];
            while (j < n2) arreglo[k++] = R[j++];
        }
        #endregion

        #region QuickSort
        static void QuickSort(string[] arreglo)
        {
            DateTime inicio = DateTime.Now;

            QuickSortRecursivo(arreglo, 0, arreglo.Length - 1);

            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;
            Console.Write("Tiempo de QUICK-STRING: ");
            Console.WriteLine(duracion.TotalMilliseconds);
        }

        static void QuickSortRecursivo(string[] arreglo, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int p = Particion(arreglo, bajo, alto);
                QuickSortRecursivo(arreglo, bajo, p - 1);
                QuickSortRecursivo(arreglo, p + 1, alto);
            }
        }

        static int Particion(string[] arreglo, int bajo, int alto)
        {
            string pivote = arreglo[alto];
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (string.Compare(arreglo[j], pivote) <= 0)
                {
                    i++;
                    (arreglo[i], arreglo[j]) = (arreglo[j], arreglo[i]);
                }
            }

            (arreglo[i + 1], arreglo[alto]) = (arreglo[alto], arreglo[i + 1]);
            return i + 1;
        }


        #endregion
        #region quicksort itertativo 
        static void QuickSortIterativo(string[] arreglo)
        {
            DateTime inicio = DateTime.Now;

            int bajo = 0, alto = arreglo.Length - 1;
            int[] pila = new int[arreglo.Length];

            int tope = -1;
            pila[++tope] = bajo;
            pila[++tope] = alto;

            while (tope >= 0)
            {
                alto = pila[tope--];
                bajo = pila[tope--];

                int p = Particion(arreglo, bajo, alto);

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

            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;
            Console.Write("Tiempo de QUICK ITERATIVO-STRING: ");
            Console.WriteLine(duracion.TotalMilliseconds);
      
        }

        #endregion

        #region seleccion 
        static void Selección(string[] arreglo)
        {
            DateTime inicio = DateTime.Now;

            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arreglo.Length; j++)
                {
                    if (string.Compare(arreglo[j], arreglo[min]) < 0)
                        min = j;
                }

                if (min != i)
                {
                    string temp = arreglo[i];
                    arreglo[i] = arreglo[min];
                    arreglo[min] = temp;
                }
            }

            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;
            Console.Write("Tiempo de SELECCIÓN-STRING: ");
            Console.WriteLine(duracion.TotalMilliseconds);
        }

        #endregion
        #endregion

        #region generar palabras aleatorias
        public static string[] GenerarStrings8(int cantidad, Random rnd)
        {
            string[] arreglo = new string[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = rnd.Next(10_000_000, 100_000_000).ToString(); // siempre 8 caracteres
            }

            return arreglo;
        }

        // Generar string de 32 caracteres alfanuméricos
        public static string[] GenerarStrings32(int cantidad, Random rnd)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string[] arreglo = new string[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                char[] str = new char[32];
                for (int j = 0; j < 32; j++)
                {
                    str[j] = caracteres[rnd.Next(caracteres.Length)];
                }
                arreglo[i] = new string(str);
            }

            return arreglo;
        }
        #endregion
    }


}
