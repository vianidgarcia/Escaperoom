using JuegoEscaperoom.EscapeRoomPOO;
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

        public AcertijoTexto(string nombre, string pregunta, string respuesta, Rectangle area, string pista = "", string itemReq = "", string itemRec = "")
        {
            NombreObjeto = nombre;
            Pregunta = pregunta;
            _respuestaCorrecta = Normalizar(respuesta);
            AreaInteractiva = area;
            Pista = pista;
            ItemRequerido = itemReq;
            ItemRecompensa = itemRec;
        }

        public override bool ValidarRespuesta(string respuesta)
            => Normalizar(respuesta) == _respuestaCorrecta;
    }
}
