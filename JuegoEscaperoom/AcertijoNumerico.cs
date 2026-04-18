using JuegoEscaperoom.EscapeRoomPOO;
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

        public AcertijoNumerico(string nombre, string pregunta, int numero, Rectangle area,
                                string pista = "", string itemRec = "")
        {
            NombreObjeto = nombre;
            Pregunta = pregunta;
            _numeroCorrecto = numero;
            AreaInteractiva = area;
            Pista = pista;
            ItemRecompensa = itemRec;
        }

        public override bool ValidarRespuesta(string respuesta)
            => int.TryParse(respuesta, out int res) && res == _numeroCorrecto;
    }
}
