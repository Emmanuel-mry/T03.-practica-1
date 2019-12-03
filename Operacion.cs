using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P_Evaluativa1
{
    class Operacion
    {
           public List<string> ObtenerLineas(string path)
        {
            List<string> personas = new List<string>();
            if (File.Exists(path))
            {
                string[] datos = File.ReadAllLines(path);
                foreach (var item in datos)
                {
                    personas.Add(item);
                }
            }
            else
            {
                Console.WriteLine("ARCHIVO NO ENCONTRADO");
                Console.WriteLine();
                return null;
            }

            return personas;
        }
           public List<Persona> ObtenerPersona()
        {
            var lineas = ObtenerLineas("Datos.txt");
            List<Persona> ListPer = new List<Persona>();
            foreach (var item in lineas)
            {
                string[] info = item.Split(',');
                ListPer.Add(new Persona { Id = int.Parse(info[0]), Nombre = info[1], Profesion = info[2], Edad = int.Parse(info[3]) });
            }
            return ListPer;
        }
           public void VerPersona()
        {
            bool repeat = true;
            while (repeat == true)
            {

                try
                {
                    Console.WriteLine("INGRESE ID: ");
                    int busqueda = int.Parse(Console.ReadLine());
                    var persona = ObtenerPersona();
                    Persona PE = new Persona();
                    foreach (var item in persona)
                    {
                        if (busqueda == item.Id)
                        {
                            PE = item;
                        }
                    }
                    Console.WriteLine("NOMBRE: " + PE.Nombre); 
                    Console.WriteLine();
                    Console.WriteLine("PROFESION: " + PE.Profesion); 
                    Console.WriteLine();
                    Console.WriteLine("EDAD: " + PE.Edad); 
                    Console.WriteLine();

                    Console.WriteLine("DESEA INGRESAR OTRA PERSONA?");
                    Console.WriteLine("1) SI");
                    Console.WriteLine("2) NO");
                    int option = int.Parse(Console.ReadLine());
                    if (option != 1)
                    {
 
                        repeat = false;
                        Console.ReadKey();
                    }
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("NO ENCONTRADO ", ex.Message);
                    Console.ReadKey();
                    
                }
            }

        }
    }
}
