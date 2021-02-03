using System;
using System.Collections;
using System.Text;


namespace Trabajo
{
    public class Clinica 
    {
        //ATRIBUTOS
        private string nombre;
        private ArrayList servicios;
        private ArrayList pacientes;



        //CONSTRUCTORES
        public Clinica (string nombre)
        {
            this.nombre = nombre;
            servicios = new ArrayList();
            pacientes = new ArrayList();
        }



        //SETTERS Y GETTERS
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre;  }
        
        }
        public ArrayList ListaServicios()
        {
            return servicios;
        }



        //METODOS
        public void AgregarServicio(Servicios ser)//AGREGA A LA LISTA DE SERVICIOS, EL SERVICIO PASADO COMO PARAMETRO
        {
            servicios.Add(ser);
        }

        public void EliminarServicio(string especialidad)//ELIMINA UN SERVICIO CON LA ESPECIALIDAD PASADA COMO PARAMETRO
        {
            foreach(Servicios x in servicios)
            {
                if(x.Especialidad == especialidad)
                {
                    servicios.Remove(x);
                }
            }
        }

        public int CantidadServicios()//RETORNA LA CANTIDAD DE SERVICIOS
        {
            return servicios.Count;
        }
        
        public Servicios VerServicio(int i)//RETORNA EL SERVICIO I-ESIMO
        {
            return (Servicios) servicios[i];
        }
        
        public ArrayList TodosServicios()//RETORNA LA LISTA DE SERVICIOS
        {
            return servicios;
        }

        public Servicios RetornarServicio(string especialidad)
        {
            Servicios se = null;
            foreach(Servicios x in servicios)
            {
                if(x.Especialidad == especialidad)
                {
                    se = x;
                    break;
                }
            }
            return se;
        }
        
        public bool ExisteServicio(string especialidad)//RETORNA TRUE SI EXISTE EL SERVICIO CON LA ESPECIALIDAD PASADA COMO PARAMETRO, O FALSE EN CASO CONTRARIO
        {
            bool existe = false;
            foreach(Servicios x in servicios)
            {
                if(x.Especialidad == especialidad)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        
        public void AgregarPaciente(Paciente pac)//AGREGA UN PACIENTE A LA LISTA DE PACIENTES
        {
            pacientes.Add(pac);
        }
        
        public void EliminarPaciente(int dni)//ELIMINA UN PACIENTE DE LA LISTA DE PACIENTES
        {
            foreach(Paciente x in pacientes)
            {
                if(x.Dni == dni)
                {
                    pacientes.Remove(x);
                }
            }
        }
        public int CantidadPaciente()//RETORNA LA CANTIDAD DE PACIENTES
        {
            return pacientes.Count;
        }
        
        public Paciente VerPaciente(int i)//RETORNA EL PACIENTE I-ESIMO
        {
            return (Paciente) pacientes[i];
        }
        
        public ArrayList TodosPacientes()//RETORNA LA LISTA DE PACIENTES
        {
            return pacientes;
        }

        public Paciente RetornarPaciente(int dni)
        {
            Paciente pa = null;
            foreach(Paciente x in pacientes)
            {
                if(x.Dni == dni)
                {
                    pa = x;
                    break;
                }
            }
            return pa;
        }

        public bool EsPaciente(int dni)//RETORNA TRUE SI EL PACIENTE EXISTE, CASO CONTRARIO FALSE
        {
            bool existe = false;
            foreach(Paciente x in pacientes)
            {
                if(x.Dni == dni)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
    } 
}