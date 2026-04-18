using JuegoEscaperoom.EscapeRoomPOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    namespace JuegoEscaperoomS
    {
        public static class BancoPreguntas
        {
            private static readonly Random _rng = new Random();

            public static List<Acertijo> ObtenerAcertijosPorHabitacion(Habitacion habitacion)
            {
                return habitacion switch
                {
                    Habitacion.Cuarto => GenerarCuarto(),
                    Habitacion.Cocina => GenerarCocina(),
                    Habitacion.Biblioteca => GenerarBiblioteca(),
                    Habitacion.Salida => GenerarSalida(),
                    _ => new List<Acertijo>()
                };
            }

            private static List<Acertijo> GenerarCuarto()
            {
                //acertijo aleatorio para la caja fuerte
                var acertijosCaja = new List<Acertijo>
            {
                new AcertijoNumerico("Caja Fuerte", "Si 1=5, 2=25, 3=125, ¿cuánto es 5?", 1,
                    new Rectangle(600, 300, 50, 50), "No te compliques, lee la primera igualdad.", "Nota con Manchas"),

                new AcertijoNumerico("Caja Fuerte", "Código de 4 dígitos: El primero es la mitad del segundo, el tercero es el doble del cuarto. La suma es 15. (Pista: 2463)", 2463,
                    new Rectangle(600, 300, 50, 50), "Prueba con el número de la pista.", "Nota con Manchas")
            };

                var cajaFuerte = acertijosCaja[_rng.Next(acertijosCaja.Count)];

                // 2. La computadora (Requiere el objeto de la caja)
                var computadora = new AcertijoTexto(
                    "Computadora",
                    "USUARIO BLOQUEADO. Ingrese el nombre del propietario:",
                    "LEON", 
                    new Rectangle(11, 240, 50, 50),
                    "Mira la nota de tu inventario de cabeza",
                    "Nota con Manchas",
                    "Llave de la Cocina"
                );

                return new List<Acertijo> { cajaFuerte, computadora };
            }

            private static List<Acertijo> GenerarCocina()
            {
                return new List<Acertijo>
            {
                // Acertijo 1: Los Cuchillos
                new AcertijoNumerico(
                    "Soporte de Cuchillos",
                    "Hay 5 espacios, pero solo 4 cuchillos. Falta el que está entre el segundo y el cuarto. ¿Qué número de espacio es?",
                    3,
                    new Rectangle(340, 185, 144, 61),
                    "Cuenta los espacios de izquierda a derecha.",
                    "Fusible Gastado"
                ),


                new AcertijoTexto("Grifo goteante", "Limpia el pecado, pero nunca la memoria. ¿Qué fluye aquí que la vida entrega y quita?", "Agua", new Rectangle(82, 245, 45, 34),"Es un elemento vital.", "Fusible Gastado"
                )
            };
            }

            private static List<Acertijo> GenerarBiblioteca()
            {
                return new List<Acertijo>
            {
                new AcertijoTexto(
                    "Terminal Antigua",
                    "Traducción de sistema: 01010011 01001111 01010011. ¿Qué palabra forman estas siglas?",
                    "SOS",
                    new Rectangle(278, 2, 83, 37),
                    "Es una señal de auxilio internacional.",
                    "", "Tijeras Oxidadas"
                ),

                new AcertijoTexto(
                    "Libro de Cuero",
                    "En la última página dice: 'Soy alguien que cuenta historias, pero nunca vive la suya'. ¿Quién soy?",
                    "ESCRITOR",
                    new Rectangle(557, 97, 50, 40),
                    "La profesión de quien escribió este libro.",
                    "Tijeras Oxidadas",
                    "Llave Maestra"
                )
            };
            }

            private static List<Acertijo> GenerarSalida()
            {
                return new List<Acertijo>
                {
                      new AcertijoTexto(
                    "Puerta Final",
                    "Si dices mi nombre, me rompes. ¿Cuál es mi nombre?",
                    "Silencio",
                    new Rectangle(252, 29, 521, 325),
                    "Lo opuesto al ruido",
                    "Llave Maestra",
                    ""
                    )
                };
            
            }
        }

        public enum Habitacion
        {
            Cuarto,
            Cocina,
            Biblioteca,
            Salida
        }
    }
}
