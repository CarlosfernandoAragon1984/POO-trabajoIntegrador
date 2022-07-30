using System;
using System.Collections.Generic;
using System.Text;

namespace trabajoIntegrador
{
    class Clientes
    {
        private const int MaxEdif = 50;
        public string razonSocial { get; private set; }
        public string domicilio { get; private set; }
        public string eMial { get; private set; }
        public string telefono { get; private set; }
        Edificios[] unEdificio;

        public Clientes(string RazonSocial, string Domicilio,string Email,string Telefono)
        {
            this.razonSocial = RazonSocial;
            this.domicilio = Domicilio;
            this.eMial = Email;
            this.telefono = Telefono;
            unEdificio = new Edificios[MaxEdif];
        }
        public int Proximo()//Busca el espacio libre.
        {
            int retorno = -1;
            do
            {
                retorno++;
            } while (retorno<MaxEdif && unEdificio[retorno]!=null);
            if(unEdificio[retorno] != null)
            {
                return -1;
            }
            return retorno;
        }
        public int AgregarEdificio(Edificios EdificioAgregar)
        {
            int posicion = this.Proximo();
            if (posicion != -1)
            {
                unEdificio[posicion] = EdificioAgregar;
            }
            return posicion;
        }
        
        public int BuscarEdificio(string domicilio)
        {
            int retorno = -1;
            do
            {
                retorno++;

            } while (retorno < MaxEdif && unEdificio[retorno].domicilio != domicilio);
            if (unEdificio[retorno].domicilio != domicilio || unEdificio[retorno] == null)
            {
                return -1;
            }
            return retorno;
        }
        

    }
}
