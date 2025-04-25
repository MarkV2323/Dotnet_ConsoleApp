abstract class Menu(string menuText = "", string menuPrompt = "", string userInput = "0", bool isHeadless = false)
{
  protected string menuText = menuText;
  protected string menuPrompt = menuPrompt;
  protected string? userInput = userInput;
  protected readonly bool isHeadless = isHeadless;

  protected int GetInput()
  {
    int option = 0;

    if (!isHeadless)
    {
      userInput = Console.ReadLine();
      userInput ??= "";
    }

    try
    {
      option = System.Convert.ToInt32(userInput);
    }
    catch
    {
      option = 0;
    }

    if (isHeadless)
    {
      Console.WriteLine(option);
    }
    return option;
  }

  public abstract int ExecMenu();
}