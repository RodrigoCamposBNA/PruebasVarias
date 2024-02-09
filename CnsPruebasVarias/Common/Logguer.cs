using Newtonsoft.Json;

namespace CnsPruebasVarias.Common
{

    public enum MessageType
    {
        INFO = 0,
        ERROR = 1,
        DEBUG = 2
    }

    public class Logguer
    {

        #region Singleton

        private static Logguer? instance;

        public static Logguer Instance => instance = instance ?? new Logguer();

        #endregion

        private string? Path = default;

        private Logguer()
        {

            Path = Config.GetValue("LogPath") != null ? Config.GetValue("LogPath") : @"C:\Temp";

            Path = Path.EndsWith(@"\") ? Path : Path + @"\";

            CreateDirectory();

        }

        public void Write(string message, MessageType messageType = MessageType.INFO)
        {

            string lineLog = $"{FormattedDate} - {messageType} - {message} \n";

            File.AppendAllText(GetNameFile(), lineLog);
        }

        public void Write(object obj, MessageType messageType = MessageType.INFO)
        {

            string lineLog = $"{FormattedDate} - {messageType} - Type : {obj.GetType().Name} \n{JsonConvert.SerializeObject(obj, Formatting.Indented)}\n";

            File.AppendAllText(GetNameFile(), lineLog);
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private string FormattedDate => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        private string GetNameFile() => Path + "CnsPruebasVarias_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
    }

}