using Arreglos.Logica;

[8:16 a.m., 6 / 10 / 2026] Dulce 🌸: using Arreglos.Logica;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nArreglos");

        MiArreglo oMiArreglo = new MiArreglo(5);

        try
        {

            for (int i = 0; i < oMiArreglo.N; i++)
            {
                oMiArreglo.Agregar(i * 3);
            }


        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine(oMiArreglo);



        // oMiArreglo.Llenar(5, 20);

        // Console.WriteLine("\nArreglo desordenado");
        //Console.WriteLine(oMiArreglo);

        //.WriteLine("\nArreglo ordenado ascendente");
        // oMiArreglo.Ordenar();
        //Console.Wr…
        [8:17 a.m., 6 / 10 / 2026] Dulce 🌸: namespace Arreglos.Logica
{
    public class MiArreglo
    {

        //Atributos o campos
        private int _tope;
        private int[] _arreglo;



        //Constructor
        public MiArreglo(int n)
        {
            N = n;
            _arreglo = new int[N];
            _tope = 0;


        }

        //Propiedades
        public int N { get; }
        public bool EstaVacio => _tope == 0;
        public bool EstaLleno => _tope == N;

        //Métodos

        public void Llenar(int minimo, int maximo)
        {
            Random oRandom = new Random();
            for (int i = 0; i < N; i++)
            {
                _arreglo[i] = oRandom.Next(minimo, maximo);
            }
            _tope = N;

        }
        // Metodo Ordenar 

        public void Ordenar()
        {
            Ordenar(true);
        }

        //Método Ordenar
        public void Ordenar(bool ascendente)
        {
            for (int i = 0; i < _tope - 1; i++)
            {
                for (int j = i + 1; j < _tope; j++)
                {
                    if (ascendente)
                    {
                        if (_arreglo[i] > _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }


                    }

                    else
                    {
                        if (_arreglo[i] > _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }
                    }
                }
            }
        }

        //Método Cambiar

        public void Cambiar(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }


        //Método agregar

        public void Agregar(int numero)
        {
            if (EstaLleno)
            {
                throw new Exception("El arreglo esta lleno");
            }
            else

                _arreglo[_tope] = numero;
            _tope++;

        }



        public override string ToString()
        {

            if (EstaVacio)
            {
                return "El arreglo esta vacio";
            }


            string salida = string.Empty;

            int contador = 0;


            for (int i = 0; i < _tope; i++)
            {
                salida = salida + $"{_arreglo[i]} ";
                contador++;

                if (contador > 9)
                {
                    contador = 0;
                    salida += "\n";
                }




            }

            return salida;
        }



    }
}