using Arreglos.Logica;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nArreglos");

        MiArreglo oMiArreglo = new MiArreglo(5);

        try
        {
            oMiArreglo.Agregar(10);
            oMiArreglo.Agregar(5);
            oMiArreglo.Agregar(-4);

            Console.WriteLine(oMiArreglo);
            Console.ReadKey();

            oMiArreglo.Insertar(200, 1);

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
        //Console.WriteLine(oMiArreglo);


        //Console.WriteLine("\nArreglo ordenado descendente");
        //oMiArreglo.Ordenar(false);
        //Console.WriteLine(oMiArreglo);

        Console.ReadKey();
    }
}

namespace Arreglos.Logica
{
    public class MiArreglo
    {
        private int[] datos;
        private int count;

        public MiArreglo(int capacidad)
        {
            if (capacidad <= 0) throw new ArgumentException("La capacidad debe ser mayor que 0.", nameof(capacidad));
            datos = new int[capacidad];
            count = 0;
        }

        public void Agregar(int value)
        {
            if (count >= datos.Length) throw new InvalidOperationException("Arreglo lleno.");
            datos[count++] = value;
        }

        public void Insertar(int value, int index)
        {
            if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index));
            if (count >= datos.Length) throw new InvalidOperationException("Arreglo lleno.");
            for (int i = count; i > index; i--) datos[i] = datos[i - 1];
            datos[index] = value;
            count++;
        }

        public void Llenar(int min, int max)
        {
            var rnd = new Random();
            for (int i = 0; i < datos.Length; i++) datos[i] = rnd.Next(min, max);
            count = datos.Length;
        }

        public void Ordenar(bool asc = true)
        {
            var slice = datos.Take(count).ToArray();
            Array.Sort(slice);
            if (!asc) Array.Reverse(slice);
            for (int i = 0; i < slice.Length; i++) datos[i] = slice[i];
        }

        public override string ToString()
        {
            if (count == 0) return "[]";
            return "[" + string.Join(", ", datos.Take(count)) + "]";
        }
    }
}