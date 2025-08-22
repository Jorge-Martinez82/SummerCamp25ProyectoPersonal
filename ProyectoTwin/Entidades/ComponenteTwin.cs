using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTwin.Entidades
{
    public class ComponenteTwin
    {
        [Key]
        public int IdComponente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDatos { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoReal { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoDigital { get; set; }

        [Required]
        public DateTime UltimaActualizacion { get; set; }

        [StringLength(100)]
        public string IndicadorSostenibilidad { get; set; }

        public bool MantenimientoProgramado { get; set; }
    }
}
