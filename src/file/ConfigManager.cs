using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// Config class is a "pure" data class,
// It only allows the get, sets & toString.
class Config
{
  public ConsoleColor BackgroundColor
  { get; set; }
  public ConsoleColor ForegroundColor
  { get; set; }

  public Config()
  {
    ForegroundColor = ConsoleColor.White;
    BackgroundColor = ConsoleColor.Black;
  }

  public override string ToString()
  {
    return JsonSerializer.Serialize(this);
  }

}

class ConfigManager(string filePath = "")
{
  public string ConfigPath
  { get; set; } = filePath;
  public Config ConfigObj
  { get; set; } = new();

  public void readConfig()
  {
    if (File.Exists(ConfigPath))
    {
      Config? tmp = JsonSerializer.Deserialize<Config>
        (File.ReadAllText(ConfigPath));
      if (tmp != null)
      {
        ConfigObj = tmp;
      }
      else
      {
        Console.WriteLine("Failed to read config file...");
        return;
      }
    }
    else
    {
      Console.WriteLine(ConfigPath
        + " does not exist, cannot read.");
      Console.WriteLine(Directory.GetCurrentDirectory()
        + " is my working directory.");
      return;
    }
  }

  public void writeConfig()
  {
    string jString = JsonSerializer.Serialize(ConfigObj);
    File.WriteAllText(ConfigPath, jString);
  }
}