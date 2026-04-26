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
            return _mapaInteractivo
                .FirstOrDefault(kvp => kvp.Value.Contains(punto))
                .Key;
        }

        public IEnumerable<Rectangle> ObtenerAreas() => _mapaInteractivo.Values;

    }
}
