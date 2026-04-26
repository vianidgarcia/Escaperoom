using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class AcertijoNumerico : Acertijo
    {
        private readonly int _numeroCorrecto;

        public AcertijoNumerico(string nombre, string pregunta, int numero,
                            string pista = "", string itemRec = "", Habitacion? habitacionDestino = null)
        {
            NombreObjeto = nombre;
            Pregunta = pregunta;
            _numeroCorrecto = numero;
            Pista = pista;
            HabitacionDestino = habitacionDestino;
            ItemRecompensa = itemRec;
        }

        public override bool ValidarRespuesta(string respuesta)
            => int.TryParse(respuesta, out int res) && res == _numeroCorrecto;
    }
}
