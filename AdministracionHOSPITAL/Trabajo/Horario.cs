using System;
using System.Collections;
using System.Text;



namespace Trabajo
{
    public class Horario //CLASE DE HORARIOS
    {
        //ATRIBUTOS
        private string dia;
        private int horainicio;
        private int horafin;





        //CONSTRUCTORES
        public Horario(string dia, int horainicio, int horafin)
        {
            this.dia = dia;
            this.horainicio = horainicio;
            this.horafin = horafin;
        }





        //SETTERS & GETTERS
        public string Dia
        {
            set { dia = value; }
            get { return dia; }
        }
        public int Horainicio
        {
            set { horainicio = value; }
            get { return horainicio; }
        }
        public int Horafin
        {
            set { horafin = value; }
            get { return horafin; }
        }
        public  void Imprimir()
        {
            Console.WriteLine("Dia: {0} Hora de inicio: {1} Hora de finalizacion: {2}",dia,horainicio, horafin);
        }
    }
}
