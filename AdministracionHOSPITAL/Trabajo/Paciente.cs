using System;
using System.Collections;
using System.Text;

namespace Trabajo
{
    public class Paciente : Persona //CLASE PACIENTE CON HERENCIA DE LA CLASE PERSONA
    {
        //ATRIBUTOS
        private DateTime fecha_ingreso;
        private string diagnostico;



        //CONSTRUCTORES
        public Paciente (int dni, string nombre, string apellido,  DateTime fechaNac, DateTime fecha_ingreso, string diagnostico) :base(nombre, apellido, fechaNac, dni)
        {   
            this.fecha_ingreso = fecha_ingreso;
            this.diagnostico = diagnostico;
        }



        //SETTERS Y GETTERS
        public DateTime Fecha_ingreso
        {
            set { fecha_ingreso = value; }
            get { return fecha_ingreso ; }
        }
        public string Diagnostico
        {
            set { diagnostico = value; }
            get { return diagnostico; }
        }



        //METODOS
        public override void Imprimir()//IMPRIME UNA PERSONA SOLO CON LOS ATRIBUTOS DE PERSONA
        {
            base.Imprimir();
            Console.Write("Fecha ingreso: {0}\nDiagnostico: {1}\n",  fecha_ingreso.ToShortDateString(),  diagnostico);
            Console.WriteLine("----------------");
        }
    }
}