﻿using System;

namespace MigracionSap
{
    public class Documento
    {
        public int Id { get; set; }

        public string Empresa { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }

        public string Estado { get; set; } //Pendiente, Sincronizado y Error
        public DateTime FechaRecepcion { get; set; } = DateTime.Now;
        public DateTime? FechaEnvio { get; set; } = null;
    }
    
}