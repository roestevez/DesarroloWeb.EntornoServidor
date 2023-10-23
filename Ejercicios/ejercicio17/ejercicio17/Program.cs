using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ejemplo clave M123456&ar
            string letraMayuscula, letraMinuscula, simbolo, numero;
            letraMayuscula = GetClave("LETRA MAYUSCULA");
            Console.WriteLine("La clave generada es: " + clave);
        }
        public static string GetClave(string tipoClave, int cantidad)
        {
            char clave = char.MinValue;
            Random r = new Random();
            if (tipoClave == "LETRA MAYUSCULA")
            {
                clave = (char)r.Next();

            }

            return clave.ToString();
        }
        public static string GeneradorPassSuperSeguras()

        {
            string claveSegura = string.Empty;
            int numeroDigitos;
            Random r = new Random();
            numeroDigitos = r.Next(5, 8 + 1);

            return claveSegura;
        }
    }
}
