using System;
using System.Collections.Generic;
using System.Text;

namespace trabajoIntegrador
{
    class App
    {
        private const string agregarTecnico = "1", agregarClinetes = "2", AgreEdificio = "3",
             AgreAscensor = "4", iformeVisita = "5", inforFacturacion = "6", Salir = "7";
        private string Opciones = "";
        private const int maxClientes = 1000;
        private const int maxTecnicos = 50;
        Clientes[] Clientes;
        Tecnico[] Tecnico;

        public App()
        {
            Clientes = new Clientes[maxClientes];
            Tecnico = new Tecnico[maxTecnicos];
        }
        public void Ejecutar(Edificios Ascensor)
        {
            do
            {
                Console.WriteLine("Menú Principal");
                Console.WriteLine(agregarTecnico + "- Agregar Empleado");
                Console.WriteLine(agregarClinetes + "-Agregar Clientes");
                Console.WriteLine(AgreEdificio + "-Agregar Edificio al Cliente");
                Console.WriteLine(AgreAscensor + "-Agregar Ascensor al edificio ");
                Console.WriteLine(iformeVisita + "-Registrar informe de visita");
                Console.WriteLine(inforFacturacion + "- Informe de facturacion");
                Console.WriteLine(Salir + "-Salir");
                Opciones = ConvaliDatos.PedirStrNoVac("Eliga una Opción");
                switch (Opciones)
                {
                    case agregarTecnico:
                        IngresarTecnico();
                        break;
                    case agregarClinetes:
                        IngresarClientes();
                        break;
                    case AgreEdificio:
                        IngresarEdificios();
                        break;
                    case AgreAscensor:

                        IngresarAscensor(Ascensor);
                        break;
                    case iformeVisita:
                        break;
                    case inforFacturacion:
                        break;
                    case Salir:
                        break;
                    default:
                        break;

                }
            } while (Opciones != Salir);
        }
        
        public int ProximoCliente()//Busca el espacio libre.
        {
            int retorno = -1;
            do
            {
                retorno++;
            } while (retorno < maxClientes && Clientes[retorno] != null);
            if (Clientes[retorno] != null)
            {
                return -1;
            }
            return retorno;
        }
      
        public int BuscarClientes(string razonSocial)
        {
            int retorno = -1;
            do
            {
                retorno++;

            } while (retorno < maxClientes && Clientes[retorno].razonSocial != razonSocial);
            if (Clientes[retorno].razonSocial != razonSocial || Clientes[retorno] == null)
            {
                return -1;
            }
            return retorno;
        }
        public int AgregarCliete(Clientes ClienteAgregar)
        {
            int posicion = this.ProximoCliente();
            if (posicion != -1)
            {
                Clientes[posicion] = ClienteAgregar;
            }
            return posicion;
        }
        public void IngresarClientes()
        {
             string razonSocial = "";
            if (ProximoCliente() == -1)
            {
                Console.WriteLine("No hay más lugar para clientes");

            }
            else
            {
                razonSocial = ConvaliDatos.PedirStrNoVac("Ingrese la razón social del cliente");
                if (BuscarClientes(razonSocial) != -1)
                {
                    Console.WriteLine("Existe un cliente con la razón social");
                }
                else
                {
                    string domicilio = ConvaliDatos.PedirStrNoVac("Ingrese el domicilio del cliente");
                    string email = ConvaliDatos.PedirStrNoVac("Ingrese el Email del cliente");
                    string telefono = ConvaliDatos.PedirStrNoVac("Ingrese el teléfono del cliente");
                    //Clientes[ProximoCliente()] = new Clientes(razonSocial,domicilio,email,telefono);
                    Clientes uncliente = new Clientes(razonSocial, domicilio, email, telefono);
                    AgregarCliete(uncliente);


                }
            }
        }
        public int ProximoTecnico()//Busca el espacio libre.
        {
            int retorno = -1;
            do
            {
                retorno++;
            } while (retorno < maxTecnicos && Tecnico[retorno] != null);
            if (Tecnico[retorno] != null)
            {
                return -1;
            }
            return retorno;
        }
        public int BuscarTecnico(string EMail)
        {
            int retorno = -1;
            do
            {
                retorno++;

            } while (retorno < maxTecnicos && Tecnico[retorno].Mail != EMail);
            if (Tecnico[retorno].Mail != EMail || Tecnico[retorno] == null)
            {
                return -1;
            }
            return retorno;
        }
        public int AgregarTecnico(Tecnico TecnicoAgregar)
        {
            int posicion = this.ProximoTecnico();
            if (posicion != -1)
            {
                Tecnico[posicion] = TecnicoAgregar;
            }
            return posicion;
        }
        public void IngresarTecnico()
        {
            string Email = "";
            if (ProximoTecnico() == -1)
            {
                Console.WriteLine("No hay más lugar para Tecnico");

            }
            else
            {
                Email = ConvaliDatos.PedirStrNoVac("Ingrese El EMail del Ténico");
                if (BuscarTecnico(Email) != -1)
                {
                    Console.WriteLine("Existe Ténico con ese mail");
                }
                else
                {
                    string nombre = ConvaliDatos.PedirStrNoVac("Ingrese el nombre del técnico");
                    string Apellido = ConvaliDatos.PedirStrNoVac("Ingrese el apellido del técnico");
                    string telefono = ConvaliDatos.PedirStrNoVac("Ingrese el teléfono del técnico");
                   
                    Tecnico unTecnico = new Tecnico(nombre, Apellido, Email, telefono);
                    AgregarTecnico(unTecnico);


                }
            }
        }
        
        public void IngresarEdificios()
        {
            string razonSocial = ConvaliDatos.PedirStrNoVac("Ingrese la razón social del cliente");
            if (BuscarClientes(razonSocial) != -1)
            {
                Console.WriteLine("No hay cliente con la razón social");
            }
            else
            {
                string domicilio = ConvaliDatos.PedirStrNoVac("Ingrese el Domicilio");
                int i = -1;
                do
                {
                    i++;
                } while (i < maxClientes && Clientes[i].BuscarEdificio(domicilio) == -1);
                if (Clientes[i].BuscarEdificio(domicilio) == -1)
                {
                    Console.WriteLine("Ya Existe ese domicilio");
                }
                else
                {
                    int Cliente = -1;
                    do
                    {
                        Cliente++;
                      
                    } while (Cliente<maxClientes && Clientes[Cliente].razonSocial != razonSocial);
                    if (Clientes[Cliente].BuscarEdificio(domicilio) != -1)
                    {
                        Console.WriteLine("Exite esa dirección en el cliente");
                    }
                  
                    else
                    {
                        string nombreEcargado = ConvaliDatos.PedirStrNoVac("Ingrese el nombre del encargado");
                        string telefono = ConvaliDatos.PedirStrNoVac("Ingrese el Teléfono");
                        Edificios Edificio = new Edificios(domicilio, nombreEcargado, telefono);
                        Clientes[Cliente].AgregarEdificio(Edificio);
                    }
                    
                  
                }
            }
        }
        public void IngresarAscensor(Edificios miEdificio)
        {
             
            string domicilio = ConvaliDatos.PedirStrNoVac("Ingrese el domicilio");
            int i = -1;
            do
            {
                i++;
            } while (i < maxClientes && Clientes[i].BuscarEdificio(domicilio) != -1);
            if (Clientes[i].BuscarEdificio(domicilio) != -1)
            {
                Console.WriteLine("No existe edificio con el Domicilio ingresado");
            }
            else
            {
                string numSerie = ConvaliDatos.PedirStrNoVac("Ingrese el número de serie");

               if(miEdificio.BuscarAscensor(numSerie)!=-1)
               {
                    
                    Console.WriteLine("Ya existe un ascensor con el numero de serie especificado.Se encuentra en el edificio con domicilio "
                        + miEdificio.domicilio);
               }
                else
                {
                    
                    string marca = ConvaliDatos.PedirStrNoVac("Ingrese la marca");
                    string modelo = ConvaliDatos.PedirStrNoVac("Ingrese el modelo");
                    
                    Ascensores Ascensores = new Ascensores(marca,modelo, numSerie);
                    miEdificio.AgregarAscensor(Ascensores);
                    
                }
            }
        }
        public void InformeDeVicita()
        {
            string nombre = ConvaliDatos.PedirStrNoVac("Ingrese el Nombre  del tecnico");
            string Apellido = ConvaliDatos.PedirStrNoVac("Ingrese el Apellido  del tecnico");
            int posicion = 0;
            do
            {
                nombre = Tecnico[posicion].Nombre;
                Apellido=Tecnico[posicion].Apellido;
                posicion++;
            } while (posicion < maxTecnicos);
            if (posicion == maxTecnicos)
            {
                Console.WriteLine("No existe tecnico");

            }
            else
            {
                string domicilio = ConvaliDatos.PedirStrNoVac("Ingrese el Domicilio");
                int i = -1;
                do
                {
                    i++;
                } while (i < maxClientes && Clientes[i].BuscarEdificio(domicilio) != -1);
                if (Clientes[i].BuscarEdificio(domicilio) != -1)
                {
                    Console.WriteLine("No Existe ese domicilio");
                }
                else
                {
                    

                }
            }
           
        }
    }

}
