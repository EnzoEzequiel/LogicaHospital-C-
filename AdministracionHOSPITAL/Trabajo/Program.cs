using System;
using System.Collections;
using System.Net.Http.Headers;

namespace Trabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            MENU();
            
            Clinica C = new Clinica("C1");

            Servicios S1 = new Servicios("Morales", "Diabetologia", 5);
            Servicios S2 = new Servicios("Jimenez", "Pediatria", 5);
            Servicios S3 = new Servicios("Peña", "Toxicologia", 5);
            Servicios S4 = new Servicios("Contreras", "Neurologia", 5);
            Servicios S5 = new Servicios("Gonzáles", "Infectologia", 5);
            Medico M1 = new Medico(10, "00:00-08:00", "Martin", "Gomez", 30423395, DateTime.Parse("14/10/1985"), "Pediatria");
            Medico M2 = new Medico(11, "16:00-00:00", "Pablo", "Fardín", 32456123, DateTime.Parse("24/02/1990"), "Diabetologia");
            Paciente P1 = new Paciente(45584432, "Martin", "Rodriguez", DateTime.Parse("12/02/2008"), DateTime.Parse("14/06/2020"), "Bronquitis");
            Paciente P2 = new Paciente(34512347,"Santiago", "Ramirez", DateTime.Parse("11/09/1980"), DateTime.Parse("20/09/2019"), "Diabetes");

           
            C.AgregarServicio(S1);
            C.AgregarServicio(S2);
            C.AgregarServicio(S3);
            C.AgregarServicio(S4);
            C.AgregarServicio(S5);
           
            C.AgregarPaciente(P1);
            C.AgregarPaciente(P2);
            
            S1.AgregarMedico(M1);
            S2.AgregarMedico(M2);


            int opcion = 0;
            do
            {
                try
                {
                    Console.Write("Elija una opción: ");
                    opcion = int.Parse(Console.ReadLine()); 
                    switch (opcion)
                    {
                        case 1: //SI ELIGE AGREGAR MEDICO
                            Console.Write("Nombre medico: ");
                            string nombreMed = Console.ReadLine();
                            Console.Write("Apellido: ");
                            string apellidoMed = Console.ReadLine();
                            Console.Write("Dni: ");
                            int dni = int.Parse(Console.ReadLine());
                            Console.Write("Fecha Nacimiento (dd/MM/YYYY): ");
                            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());
                            Console.Write("Legajo: ");
                            int legajo = int.Parse(Console.ReadLine());
                            Console.WriteLine("Horarios\nH1- 8:00 a 16:00\nH2- 16:00 a 00:00\nH3-00:00 a 8:00");
                            string horario = null;
                            while (horario == null)
                            {
                                Console.Write("Horario: ");
                                string opcionH = Console.ReadLine().ToUpper();
                                switch (opcionH)
                                {
                                    case "H1":
                                        horario = "8:00-16:00";
                                        break;
                                    case "H2":
                                        horario = "16:00-00:00";
                                        break;
                                    case "H3":
                                        horario = "00:00-08:00";
                                        break;
                                    default:
                                        Console.WriteLine("Horario Incorrecto");
                                        break;
                                }
                            }
                            string es = Especialidades();
                            bool existe = false;
                            foreach(Servicios server in C.ListaServicios())
                            {
                                if(server.Especialidad == es)
                                {
                                    server.AgregarMedico(new Medico(legajo, horario, nombreMed, apellidoMed, dni, fechaNacimiento, es));
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe)
                            {
                                Console.WriteLine("Medico agregado");
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menu");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 2: //SI ELIGE LA OPCION DE BORRAR UN MEDICO
                            Console.Write("Ingrese el legajo del medico a borrar: ");
                            int leg = int.Parse(Console.ReadLine());
                            foreach (Servicios ser in C.ListaServicios())
                            {
                                if (ser.ExisteMedico(leg))
                                {
                                    ser.BorrarMedico(leg);
                                    Console.WriteLine("Medico borrado satisfactoriamente.");
                                    break;
                                }
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menu");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 3://SI ELIGE INTERNAR A UN PACIENTE
                            Console.Write("Ingrese DNI del paciente: ");
                            int dniPa = int.Parse(Console.ReadLine());
                            if (C.EsPaciente(dniPa))
                            {
                                Console.Write("Ingrese especialidad del servicio: ");
                                string espeS = Console.ReadLine();
                                if (C.ExisteServicio(espeS))
                                {
                                    Servicios s = C.RetornarServicio(espeS);
                                    try
                                    {
                                        if (s.CupoCama == 0)
                                        {
                                            throw new Exception();
                                        }
                                        Console.Write("Ingrese legajo del medico: ");
                                        int legaMe = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                        if (s.ExisteMedico(legaMe))
                                        {
                                            s.IngresarPaciente(s.RetornarMedico(legaMe), C.RetornarPaciente(dniPa));
                                            Console.WriteLine("Accion concretada correctamente-");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No existe el medico");
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("No hay cama disponible.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe el servicio");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existe el paciente");
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menu");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 4: //SI ELIGE VER LOS DATOS DE LOS MEDICOS DE SERVICIO NOCTURNO
                            ArrayList aux = new ArrayList();
                            foreach (Servicios x in C.TodosServicios())
                            {
                                foreach (Medico m in x.TodosMed())
                                {
                                    if (m.Horario == "00:00-08:00")
                                    {
                                        if (!aux.Contains(x.Especialidad))
                                        {
                                            aux.Add(x.Especialidad);
                                        }
                                    }
                                }
                            }
                            foreach (string service in aux)
                            {
                                Console.WriteLine(service);
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 5: //SI ELIGE VER EL PORCENTAJE DE LOS SERVICIOS CON TODAS SUS CAMAS OCUPADAS
                            int serviciosLlenos = 0;
                            foreach (Servicios x in C.ListaServicios())
                            {
                                if (x.CupoCama == 0)
                                {
                                    serviciosLlenos++;
                                }
                            }
                            float porcentajeCamas = (float)serviciosLlenos * 100 / C.CantidadServicios();
                            Console.WriteLine("Hay {0}% de camas ocupadas.", porcentajeCamas);
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 6: //SI ELIGE DAR DE ALTA A UN PACIENTE
                            Console.Write("Ingrese DNI del paciente: ");
                            int dniPaa = int.Parse(Console.ReadLine());
                            if (C.EsPaciente(dniPaa))
                            {
                                Console.Write("Ingrese especialidad del servicio: ");
                                string espeS = Especialidades();
                                if (C.ExisteServicio(espeS))
                                {
                                    Servicios s = C.RetornarServicio(espeS);
                                    Console.Write("Ingrese legajo del medico: ");
                                    int legaMe = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    if (s.ExisteMedico(legaMe))
                                    {
                                        s.DarAltaPaciente(s.RetornarMedico(legaMe), C.RetornarPaciente(dniPaa));
                                        Console.WriteLine("paciente dado de alta-");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe el medico");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe el servicio");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existe el paciente");
                                
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú..."); ;
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 7: //SI ELIGE VER LA LISTA DE PACIENTES INTERNADOS
                            foreach (Servicios service in C.ListaServicios())
                            {
                                foreach (Medico med in service.TodosMed())
                                {
                                    foreach (Paciente pa in med.TodosPacientesInternados())
                                    {
                                        pa.Imprimir();
                                    }
                                }
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 8: //SI ELIGE MOSTRAR LA LISTA DE SERVICIOS
                            foreach (Servicios sss in C.ListaServicios())
                            {
                                sss.Imprimir();
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 9: //SI ELIGE VER LA LISTA DE PACIENTES
                            foreach (Paciente x in C.TodosPacientes())
                            {
                                x.Imprimir();
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;

                        case 10: // SI ELIGE VER LA LISTA DE MEDICOS EN LA CLINICA
                            foreach (Servicios ii in C.ListaServicios())
                            {
                                foreach (Medico xx in ii.TodosMed())
                                {
                                    xx.Imprimir();
                                }
                            }
                            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;
                        case 11: //SI ELIGE SALIR DEL PROGRAMA
                            Console.WriteLine("El programa termino.");
                            break;

                        default:
                            Console.WriteLine("Ingrese un numero del 1 al 7: ");
                            Console.ReadKey();
                            Console.Clear();
                            MENU();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese bien el dato");
                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                    Console.ReadKey();
                    Console.Clear();
                    MENU();
                }
            } while (opcion != 11);

        }
            



        static void MENU() //funcion menu
        {
            Console.WriteLine("¡Bienvenido a la mejor clinica!");
            Console.WriteLine("-------");
            Console.WriteLine("1_Agregar a un médico en el servicio correspondiente a su especialidad");
            Console.WriteLine("2_Eliminar a un médico.");
            Console.WriteLine("3_Internar a un paciente en un servicio dado y a cargo de un médico determinado");
            Console.WriteLine("4_Listado de los servicios que tienen médicos de guardia en horario nocturno(de 24:00 a 8:00)");
            Console.WriteLine("5_Porcentaje de servicios con todas sus camas ocupadas");
            Console.WriteLine("6_Dar el alta(egreso) a un paciente internado en un servicio dado y a cargo de un médico determinado.");
            Console.WriteLine("7_Ver lista de pacientes internados");
            Console.WriteLine("8_Mostrar lista de servicios");
            Console.WriteLine("9_Ver lista de pacientes");
            Console.WriteLine("10_Lista de Médicos");
            Console.WriteLine("11_Para salir del programa");
            Console.WriteLine("-------");
        }
        static string Especialidades()
        {
            Console.WriteLine("Especialidad: \nE1- Diabetologia\nE2-Pediatria\nE3-Toxicologia\nE4-Neurología\nE5-Infectología\n");
            string especialidad = null;
            while (especialidad == null)
            {
                Console.Write("Ingrese especialidad: ");
                string espe = Console.ReadLine().ToUpper();
                switch (espe)
                {
                    case "E1":
                        especialidad = "Diabetologia"; break;
                    case "E2":
                        especialidad = "Pediatria"; break;
                    case "E3":
                        especialidad = "Toxicologia"; break;
                    case "E4":
                        especialidad = "Neurología"; break;
                    case "E5":
                        especialidad = "Infectología";break;
                    default:
                        Console.WriteLine("Tiene que ingresar un codigo de una especialidad. Ejemplo: E2.");break;
                }
            }
            return especialidad;

        }

    }
}
    


