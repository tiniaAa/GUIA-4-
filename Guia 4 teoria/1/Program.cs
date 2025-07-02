namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arreglo = new int[] { 2, 6, 3, 1, 7, 9,11,4,20,0,5,17,13,15 };

            DateTime incion = DateTime.Now;

            for (int piv1 = 0; piv1 < arreglo.Length - 1; piv1++)
            {
                for (int piv2 = piv1 + 1; piv2 < arreglo.Length; piv2++)
                {
                    if (arreglo[piv1] > arreglo[piv2])
                    {
                        int aux = arreglo[piv2];
                        arreglo[piv2] = arreglo[piv1];
                        arreglo[piv1] = aux;
                    }
                }
            }
            DateTime fin = DateTime.Now;

            TimeSpan resultado = fin - incion;
            Console.WriteLine("");
            Console.WriteLine(resultado.TotalMilliseconds);
            Console.ReadKey();


        }
    }
}
