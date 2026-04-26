using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class AcertijoTexto : Acertijo
    {
        private readonly string _respuestaCorrecta;

        public AcertijoTexto(string nombre, string pregunta, string respuesta,
                        string pista = "", string itemReq = "", string itemRec = "", Habitacion? habitacionDestino = null)
        {
            NombreObjeto = nombre;
            Pregunta = pregunta;
            Pista = pista;
            ItemRequerido = itemReq;
            HabitacionDestino = habitacionDestino;
            ItemRecompensa = itemRec;
            _respuestaCorrecta = Normalizar(respuesta);
        }

        public override bool ValidarRespuesta(string respuesta)
        { return Normalizar(respuesta) == _respuestaCorrecta; }
    }
}
