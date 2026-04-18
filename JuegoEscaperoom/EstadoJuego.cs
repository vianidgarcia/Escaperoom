using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class EstadoJuego
    {
        public int Puntaje { get; set; } = 0;
        public string HabitacionActual { get; set; } = "Habitacion";

        // Objetos que ya recogió el jugador
        public List<string> Inventario { get; set; } = new();

        // Nombres de objetos/acertijos ya resueltos
        public List<string> ObjetosResueltos { get; set; } = new();

        // Pistas que ya encontró
        public List<string> PistasEncontradas { get; set; } = new();

        // Para saber si la intro ya se vio
        public bool IntroVista { get; set; } = false;

        public DateTime FechaGuardado { get; set; } = DateTime.Now;
    }
}
