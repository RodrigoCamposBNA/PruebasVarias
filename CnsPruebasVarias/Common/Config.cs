public static class Config
{

    private static Dictionary<string, string> Application = new();

    private static readonly string file = "../../../user.ini";

    static Config()
    {
        if (File.Exists(file))
        {
            foreach (var line in File.ReadAllLines(file))
            {
                if (line.StartsWith("#") || line.StartsWith("[") || line.Length == 0) continue;

                var keyValueLine = line.Split('=');

                (string key, string value) = (keyValueLine[0].Trim().ToUpper(), keyValueLine[1].Trim().Split('#')[0]);

                if (!Application.ContainsKey(key)) Application.Add(key, value);

            }
        }

    }

    public static string? GetValue(string key) => Application.GetValueOrDefault(key.ToUpper());

}
