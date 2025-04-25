abstract class Menu(string menuText = "", string menuPrompt = "", string userInput = "0", bool isHeadless = false)
{
  protected string menuText = menuText;
  protected string menuPrompt = menuPrompt;
  protected string? userInput = userInput;
  protected readonly bool isHeadless = isHeadless;

  protected int GetInput()
  {
    int option = 0;

    // headless
    if (isHeadless)
    {
      option = System.Convert.ToInt32(userInput);
      return option;
    }

    // Non headless
    userInput = Console.ReadLine();
    userInput ??= "";
    try
    {
      option = System.Convert.ToInt32(userInput);
    }
    catch
    {
      option = -1;
    }
    return option;
  }

  public abstract int ExecMenu();
}