using CnsPruebasVarias.Common;

namespace CnsPruebasVarias
{
    class Program
    {

        private static Logguer _logguer = Logguer.Instance;

        static void Main()
        {

            string? key = Config.GetValue("KeyDePrueba") ?? throw new Exception("No existe la clave");

            _logguer.Write(key, MessageType.INFO);

            Console.WriteLine(key);

        }
    }
}