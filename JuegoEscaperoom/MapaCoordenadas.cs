using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public static class MapaCoordenadas
    {
        public static Rectangle ObtenerArea(Habitacion hab, string nombreObjeto)
        {
            return (hab, nombreObjeto) switch
            {   (Habitacion.Cuarto, "Computadora") => new Rectangle(11, 240, 50, 50),
                (Habitacion.Cuarto, "Caja Fuerte") => new Rectangle(600, 300, 50, 50),
                (Habitacion.Cocina, "Soporte de Cuchillos") => new Rectangle(340, 185, 144, 61),
                (Habitacion.Cocina, "Grifo goteante") => new Rectangle(82, 245, 45, 34),
                (Habitacion.Biblioteca, "Terminal Antigua") => new Rectangle(278, 2, 83, 37),
                (Habitacion.Biblioteca, "Libro de Cuero") => new Rectangle(557, 97, 50, 40),
                (Habitacion.Salida, "Puerta Final") => new Rectangle(252, 29, 521, 325),
                _ => Rectangle.Empty
            };
        }
    }
}
