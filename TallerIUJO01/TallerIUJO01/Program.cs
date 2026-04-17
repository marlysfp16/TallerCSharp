/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/4/2026
 * Hora: 10:53 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace TallerIUJO01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			
			
			//1. El dato del usuario
			
			string registroUsuario = "    ID_666   ; marlysflores ;  EVALUACION   ;   95";
			
			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim().Trim();
			
		
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El id es: {0} \n Usuario: {1} \n La nota {2} \n Evaluacion: {3}", id, nombre, nota, tarea));
			
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}