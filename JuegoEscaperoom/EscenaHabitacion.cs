using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class EscenaHabitacion
    {
        private readonly Dictionary<Acertijo, Rectangle> _mapaInteractivo = new();

        public Image Fondo { get; private set; }

        public EscenaHabitacion(Image fondo)
        {
            Fondo = fondo;
        }

        public void RegistrarObjeto(Acertijo acertijo, Rectangle area)
        {
            if (acertijo == null) return;
            _mapaInteractivo[acertijo] = area;
        }

        public Acertijo GetAcertijoEnPunto(Point punto)
        {
            foreach (var kvp in _mapaInteractivo)
                if (kvp.Value.Contains(punto)) return kvp.Key;
            return null;
        }

        public IEnumerable<Rectangle> ObtenerAreas() => _mapaInteractivo.Values;

    }
}
