using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class AcertijoTransicion : Acertijo
    {
        public AcertijoTransicion(string nombre, Rectangle area, Habitacion destino, string itemReq = "")
        {
            NombreObjeto = nombre;
            AreaInteractiva = area;
            HabitacionDestino = destino;
            ItemRequerido = itemReq;
            Pregunta = ""; // No hay pregunta
        }

        public override bool ValidarRespuesta(string respuesta) => true; // Siempre válido
    }
}
