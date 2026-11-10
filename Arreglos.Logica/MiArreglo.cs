using Arreglos.Logica;

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
        namespace Arreglos.Logica
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

        //Método insertar

        public void Insertar(int numero, int posicion)
        {
            if (EstaLleno)
            {
                throw new Exception("El arreglo esta lleno");
            }
            if (posicion < 0 || posicion >= _tope)
            {
                throw new Exception("Posicion invalida");
            }
            for (int i = _tope; i > posicion; i--)
            {
                _arreglo[i] = _arreglo[i - 1];
            }
            _arreglo[posicion] = numero;
            _tope++;
        }

        //Método Insertar
         public void Insertar(int numero, int posicion)
        {
            if(EstaLleno)
            {
                throw new Exception("El arreglo esta lleno");
            }
            if(posicion < 0)
            {
                posicion = 0;
            }
            if (posicion > _tope)
            {
                posicion = _tope;
            }
            for (int i= _tope; i > posicion; i--)
            {
                _arreglo[posicion] = numero;
            }
            _arreglo[posicion] = numero;
            _tope++;

        }
        //Método eliminar
        public void Eliminar(int posicion)
        {
            if(EstaVacioVacio)
            {
                throw new Exception("El arreglo esta vacio");
            }
            if(posicion < 0)
            {
                posicion = 0;
            }
            if (posicion > _tope)
            {
                posicion = _tope;
            }
            for(int i = posicion; 1<= _tope - 1; i++)
            {
                _arreglo[i] = _arreglo[i + 1];
            }
            _tope--;
        }

        //Metodo obtener pares

        public MiArreglo ObtenerPares()
        {
            int contandoPares = 0;
            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] % 2 == 0)
                {
                    contandoPares++;
                }
            }
            var arregloPares = new MiArreglo(contandoPares);

            MiArreglo oMiArreglo = new MiArreglo(contandoPares);

                for(int j = 0; j < _tope; j++)
                {
                    if (_arreglo[j] % 2 == 0)
                    {
                        oMiArreglo.Agregar(_arreglo[j]);
                    }
                }
            
            return arregloPares;
        }

        private bool EsPrimo(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //Método obtener primos
        public MiArreglo ObtenerPrimos()
        {
            int contandoPrimos = 0;
            for(int i = 0; i < _tope; i++)
            {
                if (EsPrimo(_arreglo[i]))
                {
                    contandoPrimos++;
                }
            }
            var arregloPrimos = new MiArreglo(contandoPrimos);
            for(int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] % 2 == 0)
                {
                    arregloPrimos.Agregar(_arreglo[i]);
                }
            }
            return arregloPrimos;
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