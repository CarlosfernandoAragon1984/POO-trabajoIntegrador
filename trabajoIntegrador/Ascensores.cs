using System;
using System.Collections.Generic;
using System.Text;

namespace trabajoIntegrador
{
    class Ascensores
    {
        public string marca { get; private set; }
        public string modelo { get; private set; }
        public string serial { get; private set; }
        public string ultimaRevision { get; private set; }
        public Tecnico tecnicoUltimaRevision { get; private set; }
       
        public Ascensores(string Marca,string Modelo,string Serial)
        {
            this.marca = Marca;
            this.modelo = Modelo;
            this.serial = Serial;

            this.ultimaRevision = "00/00/0000";
            this.tecnicoUltimaRevision = null;
        }
        
        
        
        
        public void SetUltimaRevision(Tecnico unTecnico,string ultimaRevi)
        {
            this.ultimaRevision = ultimaRevi;
            this.tecnicoUltimaRevision = unTecnico;
        }
    }
}
