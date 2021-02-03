using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo
{
    public abstract class Persona //CLASE PERSONA
    {
        //ATRIBUTOS
        protected string nombre;
        protected string apellido;
        protected int dni;
        protected DateTime fechaNacimiento;



        //CONSTRUCTORES
        public Persona(string nombre, string apellido, DateTime fechaNac, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            fechaNacimiento = fechaNac;
        }



        //SETTERS & GETTERS
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public string Apellido
        {
            set { apellido = value; }
            get { return apellido; }
        }
        public int Dni
        {
            set { dni = value; }
            get { return dni; }
        }
        public DateTime FechaNacimiento
        {
            set { fechaNacimiento = value; }
            get { return fechaNacimiento; }
        }


        //METODOS
        public virtual void Imprimir()//IMPRIMIR
        {
            Console.Write("Nombre: {0}\nApellido: {1}\nDNI: {2}\nFecha nacimiento: {3}\n",nombre,apellido,dni,fechaNacimiento.ToShortDateString());
        }

    }
}
