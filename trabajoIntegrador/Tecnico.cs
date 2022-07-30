using System;
using System.Collections.Generic;
using System.Text;

namespace trabajoIntegrador
{
    class Tecnico
    {
        private const int cantTec = 50;
        public Tecnico[] tecnicos { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Mail { get; private set; }
        public string Telefono { get; private set; }

        public Tecnico(string nombre,string apellido,string mail, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Telefono = telefono;
                 
        }
    }
}
