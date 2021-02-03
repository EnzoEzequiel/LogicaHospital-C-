using System;
using System.Collections;
using System.Text;

namespace Trabajo
{
    public class Servicios
    {
        //ATRIBUTOS
        private ArrayList medicos; //lista de medicos 
        private string jefe; 
        private string especialidad;
        private int cupoCama;



        //CONSTRUCTORES
        public Servicios(string jefe, string especialidad, int cupoCama) //añade un nuevo servicio
        {
            medicos = new ArrayList();
            this.jefe = jefe;
            this.especialidad = especialidad;
            this.cupoCama = cupoCama;
        }



        //SETTERS Y GETTERS

        public string Jefe
        {
            set { jefe = value;  }
            get { return jefe;  }
        }

        public string Especialidad
        {
            set { especialidad = value; }
            get { return especialidad;  }
        }

        public int CupoCama
        {
            set { cupoCama = value; }
            get { return cupoCama;  }
        }



        //METODOS
        public ArrayList TodosMed()
        {
            return medicos;
        }

        public void Imprimir()
        {
            Console.WriteLine("Especialidad: {0}\nJefe: {1}\nCamas disponibles: {2}",especialidad, jefe, cupoCama);
            Console.WriteLine("----------------");
        }
        
        public void AgregarMedico(Medico med) //AGREGA UN MEDICO A LA LISTA DE MEDICOS
        {
            medicos.Add(med);
        }

        public void BorrarMedico (int leg)//BORRA UN MEDICO DE LA LISTA DE MEDICOS DANDOLE EL LEGAJO
        {
            /*for (int i = 0; i < medicos.Count; i++)
            {
                if (((Medico)medicos[i]).Legajo==leg)
                {
                    medicos.RemoveAt(i);
                }
            }*/
            foreach(Medico med in medicos)
            {
                if(med.Legajo == leg)
                {
                    medicos.Remove(med);
                    break;
                }
            }
        }

        public int TotalMedicos() //sRETORNA LA CANTIDAD DE MEDICOS
        {
            return medicos.Count;
        }

        public Medico VerMed(int i) //VER UN MEDICO IÉSIMO
        {
            return (Medico)medicos[i];
        }

        public Medico RetornarMedico(int legajo)
        {
            Medico med = null;
            foreach(Medico x in medicos)
            {
                if(x.Legajo == legajo)
                {
                    med = x;
                    break;
                }
            }
            return med;
        }
         
        public void IngresarPaciente(Medico med, Paciente pac)//INGRESA UN PACIENTE Y REDUCE EN 1 EL CUPO DE CAMAS
        {
            med.InternarPaciente(pac);
            cupoCama--;
        }

        public void DarAltaPaciente (Medico med, Paciente pac)//LE DA EL ALTA A UN PACIENTE
        {
            med.AltaPaciente(pac.Dni);
            cupoCama++;
        }

        public bool ExisteMedico(int legajo)
        {
            bool existe = false;
            foreach(Medico x in medicos)
            {
                if(x.Legajo == legajo)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }



        
    }
}