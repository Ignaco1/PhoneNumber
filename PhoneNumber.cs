using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace PhoneProgramme
{
    class PhoneNumber
    {
        static void Main(string[] args)
        {
            List<string> lista_ingreso = new List<string>();
            List<string> lista_formateada = new List<string>();
            bool vari = true;

            while (vari ==  true)
            {
                Console.WriteLine("INGRESO DE NUMEROS TELEFONICOS");
                Console.WriteLine("##############################\n");
                Console.Write("Telefono registrado:");
                string tel = Console.ReadLine();

                if (tel == "0")
                {
                    Console.WriteLine("CARGA DE NUMEROS TELEFONICOS FINALIZADA\n");
                    break;
                }

                while (!ValidaString(tel) || !ValidaLongi(tel))
                {
                    if (!ValidaString(tel))
                    {
                        Console.WriteLine("Error en el ingreso del numero telefonico, asegurese que solo contenga numeros o simbolos\n");
                        Console.WriteLine("Reingrese el telefono registrado:");
                        tel = Console.ReadLine();
                    }
                    else if (!ValidaLongi(tel))
                    {
                        Console.WriteLine("Error en la longitud del numero telefonico\n");
                        Console.WriteLine("Reingrese el telefono registrado:");
                        tel = Console.ReadLine();
                    }                                                        
                }

                lista_ingreso.Add(tel);

                tel = Clean(tel);

                lista_formateada.Add(tel);

            }

            for (int i= 0; i < lista_ingreso.Count; i++)
            {
                Console.WriteLine("telefono ingresado: " + lista_ingreso[i]);
                Console.WriteLine("telefono formateado: " + lista_formateada[i]);
                Console.WriteLine();
            }

        }
        
        private static bool ValidaString(string telefono)
        {
            bool respuesta = Regex.IsMatch(telefono, @"[a-zA-Z]");

            if (respuesta) return false;

            else return true;
        }
        
        private static bool ValidaLongi_clean(string telefono)
        {
            int cont = telefono.Length;

            if (cont >= 10 || cont <= 12)
            {
                return true;
            }
            return false;
        }

        private static bool ValidaLongi(string telefono)
        {
            int cont = telefono.Length;

            if (cont >= 10 && cont <= 17)
            {
                telefono = Clean(telefono);

                return ValidaLongi_clean(telefono);
            }
            return false;
        }

        private static string Clean(string telefono)
        {
            try
            {
                if (telefono.Contains("(") || telefono.Contains(")"))
                {
                    telefono = telefono.Replace("(", "");
                    telefono = telefono.Replace(")", "");
                }

                if (telefono.Contains("-"))
                {
                    telefono = telefono.Replace("-", "");
                }
                
                if (telefono.Contains("."))
                {
                    telefono = telefono.Replace(".", "");
                }

                if (telefono.Contains(" "))
                {
                    telefono = telefono.Replace(" ", "");
                }

                return telefono;
            }
            catch (Exception e)
            {
                return ($"Error en el formateo del telefono: {e.Message}");
            }
            
            
        }
    }
}
