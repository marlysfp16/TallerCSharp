using System;
using System.IO;

namespace TallerIUJO01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			Console.WriteLine("\n");
			
			//1. El dato del usuario
			
			string registroUsuario = "    ID_666   ; marlysflores ;  EVALUACION   ;   95";
			
			
			string registroLimpio = registroUsuario.Trim().Trim();
			
		
			Console.WriteLine(registroLimpio);
			
			Console.WriteLine("\n");
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine("=================================");
			Console.WriteLine(string.Format(" El id es: {0} \n Usuario: {1} \n La nota {2} \n Evaluacion: {3}", id, nombre, nota, tarea));
			Console.WriteLine("=================================");
			
			Console.WriteLine("\n");
			
			//flujo de archivos
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIUJO");
			
			if(!Directory.Exists("Reportes"))
			{
				Directory.CreateDirectory("Reportes");
				
				Console.WriteLine("Directorio Creado con exito");
			}
			
			string archivotexto =Path.Combine(rutaraiz,"notas.txt");
			
			
			
			Console.WriteLine("\n");
			
			Console.WriteLine(archivotexto);
			
			Console.WriteLine("\n");
			
			using(StreamWriter sw = new StreamWriter(archivotexto, true))
			{
				sw.WriteLine(string.Format("ID : {0} Nota {1} Fecha: {yyyy-MM-dd-HH:mm}", id, nota, DateTime.Now));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}