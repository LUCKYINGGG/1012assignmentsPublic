using ClientInfor;

Client myClient = new Client();
List<Client> listOfClient = [];

bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);
        if (mainMenuChoice == "A")
            AddClientToList(myClient, listOfClient);
        if (mainMenuChoice == "F")
            myClient = FindClientInList(listOfClient);
        if (mainMenuChoice == "R")
            RemoveClientFromList(myClient, listOfClient);
        if (mainMenuChoice == "D")
            DisplayAllClientInList(listOfClient);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listOfClient);
            loopAgain = false;
            throw new Exception("Bye, hope to see you again.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

void DisplayMainMenu()
{
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("N) New Client PartA");
    Console.WriteLine("S) Show Client Info PartA");
    Console.WriteLine("E) Edit Client Info PartA");
    Console.WriteLine("A) Add Client To List PartB");
    Console.WriteLine("F) Find Client In List PartB");
    Console.WriteLine("R) Remove Client From List PartB");
    Console.WriteLine("D) Display all Clients in List PartB");
    Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit Menu");
    Console.WriteLine("F) Firstname");
    Console.WriteLine("L) Lastname");
    Console.WriteLine("W) Weight");
    Console.WriteLine("H) Height");
    Console.WriteLine("R) Return to Main Menu");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(myString))
                throw new Exception($"Empty Input: Please enter something.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}

int PromptIntBetweenMinMax(String msg, int min, int max)
{
    int num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max} inclusive: ");
            num = int.Parse(Console.ReadLine());
            if (num < min || num > max)
                throw new Exception($"Must be between {min} and {max}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

void ShowClientInfo(Client client)
{
    if (client == null)
    {
        throw new Exception($"No client in memory.");
    }

}

Client NewClient()
{
    Client myClient = new Client();
    GetFirstName(myClient);
    GetLastName(myClient);
    GetWeight(myClient);
    GetHeight(myClient);
    return myClient;
}

void GetFirstName(Client myClient)
{
    string firstName = Prompt($"Enter firstname: ");
    myClient.Firstname = firstName;
}
void GetLastName(Client myClient)
{
    string lastname = Prompt($"Enter lastname");
    myClient.Lastname = lastname;
}
void GetWeight(Client myClient)
{
    int weight = PromptIntBetweenMinMax("Enter weight in pounds: ", 0, 800);
    myClient.Weight = weight;
}
void GetHeight(Client myClient)
{
    int height = PromptIntBetweenMinMax("Enter height in inches", 0, 100);
    myClient.Height = height;
}

void AddClientToList(Client myClient, List<Client> listOfClient)
{
    listOfClient.Add(myClient);
}

Client FindClientInList(List<Client> listOfClient)
{
    return myClient;
}

void RemoveClientFromList(Client myClient, List<Client> listOfClient)
{

}

void DisplayAllClientInList(List<Client> listOfClient)
{

}

void SaveMemoryValuesToFile(List<Client> listOfClient)
{

}