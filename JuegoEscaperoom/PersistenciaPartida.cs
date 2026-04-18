using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public static class PersistenciaPartida
    {
        private static readonly string rutaGuardado = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "guardado.json");
        public static void GuardarPartida(EstadoJuego estado)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(estado, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(rutaGuardado, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la partida: {ex.Message}");
            }
        }
        public static EstadoJuego CargarPartida()
        {
            try
            {
                if (!File.Exists(rutaGuardado))
                    throw new FileNotFoundException("No se encontró el archivo de guardado.");
                string json = File.ReadAllText(rutaGuardado);
                return System.Text.Json.JsonSerializer.Deserialize<EstadoJuego>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la partida: {ex.Message}");
                return null;
            }
        }
        public static bool ExistePartida()
        {
            return File.Exists(rutaGuardado);
        }
        public static void BorrarPartida()
        {
            try
            {
                if (ExistePartida())
                    File.Delete(rutaGuardado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar la partida: {ex.Message}");
            }
        }
    }
}
