using System;
using System.IO;

namespace TallerIUJO01
{
    class Program
    {
        
        static string registroUsuario = "    ID_666   ; marlysflores ;  EVALUACION   ;   95";

        public static void Main(string[] args)
        {
            Console.WriteLine("=== Taller 01 - IUJO ===");
            
            string registroLimpio = registroUsuario.Trim();
            string[] partes = registroLimpio.Split(';');
            
            if (partes.Length >= 4)
            {
                string id = partes[0].Trim();
                string nombre = partes[1].Trim();
                string tarea = partes[2].Trim();
                string nota = partes[3].Trim();

                Console.WriteLine("=================================");
                Console.WriteLine(string.Format(" El id es: {0} \n Usuario: {1} \n La nota {2} \n Evaluacion: {3}", id, nombre, nota, tarea));
                Console.WriteLine("=================================");
            }
            
            string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
            if (!Directory.Exists(rutaRaiz))
            {
                Directory.CreateDirectory(rutaRaiz);
                Console.WriteLine("\n> Directorio 'DatosIUJO' creado con éxito.");
            }

            string archivoTexto = Path.Combine(rutaRaiz, "notas.txt");
            using (StreamWriter sw = new StreamWriter(archivoTexto, true))
            {
                sw.WriteLine(string.Format("ID: {0} | Nota: {1} | Fecha: {2}", partes[0].Trim(), partes[3].Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            }

            // MENU DE DESAFÍOS
            int opcion = 0;
            while (opcion != 4)
            {
                Console.WriteLine("\n===== MENÚ DE DESAFÍOS ====");
                Console.Write("1. Desafío 1 (Seguridad)\n2. Desafío 2 (Clonador)\n3. Desafío 3 (Inspector)\n4. Salir\n5. Limpiar\nSeleccione: ");
                
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: DesafioUno(); break;
                        case 2: DesafioDos(); break;
                        case 3: DesafioTres(rutaRaiz); break;
                        case 4: Console.WriteLine("Saliendo..."); break;
                        case 5: Console.Clear(); break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }
                }
            }
        }
		
        static void DesafioUno()
        {
            
            string pruebaSeguridad = "marlys;marlys123";
            string[] datos = pruebaSeguridad.Split(';');
            
            if (datos.Length >= 2)
            {
                string usuario = datos[0].Trim();
                string clave = datos[1].Trim();

                if (clave.Contains("123"))
                {
                    using (StreamWriter sw = new StreamWriter("seguridad.txt", true))
                    {
                        sw.WriteLine("Clave Débil detectada para el usuario: " + usuario);
                    }
                    Console.WriteLine(">> Alerta: Clave débil detectada y registrada.");
                }
                else
                {
                    Console.WriteLine(">> Clave segura.");
                }
            }
        }

        static void DesafioDos()
        {
            string origen = "avatar.jpg"; 
            string destino = "respaldo.jpg";

            if (File.Exists(origen))
            {
           
                using (FileStream fsOrigen = new FileStream(origen, FileMode.Open, FileAccess.Read))
                using (FileStream fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesLeidos;

                    while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsDestino.Write(buffer, 0, bytesLeidos);
                    }
                }
                Console.WriteLine(">> Imagen clonada exitosamente byte a byte.");
            }
            else
            {
                Console.WriteLine(">> Error: No se encontró 'avatar.jpg' en la carpeta del programa.");
            }
        }

        static void DesafioTres(string ruta)
        {
            if (Directory.Exists(ruta))
            {
           
                string[] archivos = Directory.GetFiles(ruta);
                foreach (string archivo in archivos)
                {
                    FileInfo info = new FileInfo(archivo);
                    //5KB = 5120 bytes
                    if (info.Length > 5120) 
                    {
                        Console.WriteLine(">> Borrando archivo pesado (>5KB): " + info.Name);
                        info.Delete();
                    }
                }
                Console.WriteLine(">> Inspección y limpieza completada.");
            }
        }
    }
}