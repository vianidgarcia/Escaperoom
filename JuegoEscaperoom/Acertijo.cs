using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    using JuegoEscaperoom.JuegoEscaperoomS;
    using System.Drawing;

    namespace EscapeRoomPOO
    {
        public abstract class Acertijo : IResoluble
        {
            // Propiedades públicas (Lectura)
            public string Pregunta { get; protected set; } = "";
            public string Pista { get; protected set; } = "";
            public string NombreObjeto { get; protected set; } = "";
            public string ItemRequerido { get; protected set; } = "";
            public string ItemRecompensa { get; protected set; } = "";

            // --- NUEVOS CAMPOS PARA INTERACTIVIDAD ---
            public Rectangle AreaInteractiva { get; set; } // Dónde hacer clic en el pbx
            public Habitacion? HabitacionDestino { get; set; } // Si es una puerta, a dónde lleva
            public bool Resuelto { get; private set; } = false;
            public int Intentos { get; private set; } = 0;

            public abstract bool ValidarRespuesta(string respuesta);

            public bool Resolver(string respuesta)
            {
                Intentos++;
                bool exito = ValidarRespuesta(respuesta);
                if (exito) Resuelto = true;
                return exito;
            }

            // Método de utilidad para limpiar texto
            protected string Normalizar(string texto) =>
                texto?.Trim().ToLowerInvariant().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u") ?? "";
        }
    }
}
