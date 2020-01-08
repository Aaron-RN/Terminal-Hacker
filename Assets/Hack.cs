using UnityEngine;

public class Hack : MonoBehaviour
{
    //Game state
    int level;
    public string password;
    string[] password_level1 = { "tissue", "plunger", "toilet", "shower", "soap" };
    string[] password_level2 = { "naruto", "bleach", "dragonballz", "onepiece", "swordartonline" };
    string[] password_level3 = { "nissan", "ford", "toyota", "honda", "mercedes" };
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowWelcomeMenu("Ronnie");
    }

    void ShowWelcomeMenu(string name = "Ronnie")
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Hello {name}");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 For The Whitehouse's Bathroom");
        Terminal.WriteLine("Press 2 For Kissanime.com");
        Terminal.WriteLine("Press 3 For Automotive industry");

        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowWelcomeMenu();
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Terminal.WriteLine("If on the web version, simply close the browser.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");

        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Invalid Level chosen.");
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        ShowMenuHint();
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = password_level1[Random.Range(0, password_level1.Length)];
                Terminal.WriteLine("The Whitehouse's Bathroom");
                break;
            case 2:
                password = password_level2[Random.Range(0, password_level2.Length)];
                Terminal.WriteLine("Kissanime.com");
                break;
            case 3:
                password = password_level3[Random.Range(0, password_level3.Length)];
                Terminal.WriteLine("Automotive Industry");
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Invalid Password. Please try again.");
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowReward();
        ShowMenuHint();
    }

    void ShowMenuHint()
    {
        Terminal.WriteLine("You can type menu at anytime.");
    }

    void ShowReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
     .-""""""-.
   .'          '.
  /   O      O   \
 :                :
 |                |   happy
 : ',          ,' :
  \  '-......-'  /
   '.          .'
     '-......-'
                ");
                break;

            case 2:
                Terminal.WriteLine(@"
     .-""""""-.
   .'          '.
  /   O    -=-   \
 :                :
 |                |
 : ',          ,' :
  \  '-......-'  /
   '.          .'
     '-......-'
                ");
                break;

            case 3:
                Terminal.WriteLine(@"
     .-""""""-.
   .(((      ))).
  /  (O)    (O)  \
 :                :
 | @            @ |
 :    _.-..-._    :
  \    '-..-'    /
   '.          .'
     '-......-'
                ");
                break;

            default:
                Debug.LogError("Invalid Level.");
                break;
        }
    }
}
