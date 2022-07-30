using System;
using System.Collections.Generic;
using System.Text;

namespace trabajoIntegrador
{
    class Edificios
    {
        private const int maxAscensores = 20;
        public string domicilio { get; private set; }
        public string encargado { get; private set; }
        public string telefono { get; private set; }
        Ascensores[] unAscensor;

        public Edificios(string Domicilio, string Encargado, string Telefono)
        {
            this.domicilio = Domicilio;
            this.encargado = Encargado;
            this.telefono = Telefono;
            unAscensor = new Ascensores[maxAscensores];

        }
        public int Proximo()//Busca el espacio libre.
        {
            int retorno = -1;
            do
            {
                retorno++;
            } while (retorno < maxAscensores && unAscensor[retorno] != null);
            if (unAscensor[retorno] != null)
            {
                return -1;
            }
            return retorno;
        }
        public int AgregarAscensor(Ascensores AscensorAgregar)
        {
            int posicion = this.Proximo();
            if (posicion != -1)
            {
                unAscensor[posicion] = AscensorAgregar;
            }
            return posicion;
        }
        public int BuscarAscensor(string Serial)
        {
            int retorno = -1;
            do
            {
                retorno++;

            } while (retorno < maxAscensores && unAscensor[retorno].serial != Serial);
            if (unAscensor[retorno].serial != Serial || unAscensor[retorno] == null)
            {
                return -1;
            }
            return retorno;
        }
       
    }
}
