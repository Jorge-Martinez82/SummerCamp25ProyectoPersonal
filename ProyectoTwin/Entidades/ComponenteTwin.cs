using System;

namespace ProyectoTwin.Entidades
{
    public class ComponenteTwin
    {
        public int IdComponente { get; set; }
        public string Nombre { get; set; }
        public string TipoDatos { get; set; }
        public string EstadoReal { get; set; }
        public string EstadoDigital { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public string IndicadorSostenibilidad { get; set; }
        public bool MantenimientoProgramado { get; set; }
    }
}
