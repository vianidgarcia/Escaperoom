using JuegoEscaperoom.JuegoEscaperoomS;
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
        public Habitacion HabitacionActual { get; set; } = Habitacion.Cuarto;
        public bool IntroVista { get; set; } = false;
        public DateTime FechaGuardado { get; set; } = DateTime.Now;

        // Las listas deben ser propiedades públicas con get y set para guardarse correctamente
        public List<string> Inventario { get; set; } = new();
        public List<string> ObjetosResueltos { get; set; } = new();
        public void SumarPuntos(int puntos)
        {
            if (puntos > 0) Puntaje += puntos;
        }

        public void RegistrarObjetoResuelto(string nombreObjeto)
        {
            if (!ObjetosResueltos.Contains(nombreObjeto))
                ObjetosResueltos.Add(nombreObjeto);
        }

        public void AgregarAlInventario(string item)
        {
            if (!string.IsNullOrEmpty(item) && !Inventario.Contains(item))
                Inventario.Add(item);
        }

        public void CambiarHabitacion(Habitacion nuevaHabitacion)
        {
            HabitacionActual = nuevaHabitacion;
        }
    }
}
