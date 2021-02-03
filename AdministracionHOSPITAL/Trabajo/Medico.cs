using System;
using System.Collections;
using System.Text;

namespace Trabajo
{
    public class Medico : Persona //CLASE MEDICO CON HERENCIA DE LA CLASE PERSONA 
    {
        //ATRIBUTOS
        private int legajo;
        private string especialidad;
        private string horario;
        private ArrayList pacientes;



        //CONSTRUCTORES
        public Medico(int legajo, string horario, string nombre, string apellido, int dni, DateTime fechaNac, string especialidad) : base(nombre, apellido, fechaNac, dni)
        {
            this.legajo = legajo;
            this.horario = horario;
            pacientes = new ArrayList();
            this.especialidad = especialidad;
        }



        //SETTERS & GETTERS
        public int Legajo
        {
            set { legajo = value; }
            get { return legajo; }
        }
        public string Especialidad
        {
            set { especialidad = value; }
            get { return especialidad; }
        }
        public string Horario
        {
            set { horario = value; }
            get { return horario; }
        }



        //METODOS
        public override void Imprimir()//IMPRIME UN MEDICO
        {
            base.Imprimir();
            Console.WriteLine("Horario: {0}", horario);
            Console.WriteLine("Especialidad: {0}", especialidad);
            Console.WriteLine("Legajo {0}", legajo);
            Console.WriteLine("----------------");
        }

        public void InternarPaciente(Paciente pac)
        {
            pacientes.Add(pac);
        }

        public ArrayList TodosPacientesInternados() //RETORNA LA LISTA DE PACIENTES INTERNADOS POR EL MEDICO
        {
            return pacientes;
        }

        public void AltaPaciente(int dni) //DA DE ALTA UN PACIENTE REMOVIENDOLO DE LA LISTA
        {
            
            for (int i = 0; i < pacientes.Count; i++)
            {
                Paciente x = (Paciente)pacientes[i];
                if (x.Dni == dni)
                {
                    pacientes.RemoveAt(i);
                    break;
                }
            }
            
        }

        public int TotalPacientes() //RETORNA LA CANTIDAD TODAL DE PACIENTES EN LA LISTA DEL MEDICO
        {
            return pacientes.Count;
        }

        public Paciente VerPac(int i) //RETORNA EL PACIENTE IÉSIMO EN LA LISTA DEL MEDICO
        {
            return (Paciente)pacientes[i];
        }
    }
}
