using ClientInfor;

Client myClient = new Client();
List<Client> listofClients = new List<Client>();

LoadFileValuesToMemory(listofClients);

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
            AddClientToList(myClient, listofClients);
        if (mainMenuChoice == "F")
            myClient = FindClientInList(listofClients);
        if (mainMenuChoice == "R")
            RemoveClientFromList(myClient, listofClients);
        if (mainMenuChoice == "D")
            DisplayAllClientInList(listofClients);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listofClients);
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
    Console.WriteLine($"Client Name:\t{client.FullName}");
    Console.WriteLine($"Bmi Score:\t{client.BmiScore}");
    Console.WriteLine($"Bmi Status:\t{client.BmiStatus}\n");

}

Client NewClient()
{
    Client myClient = new Client();
    GetFirstName(myClient);
    GetLastName(myClient);
    GetWeight(myClient);
    GetHeight(myClient);
    Console.WriteLine($"New client has added into memory.");
    return myClient;
}

void GetFirstName(Client myClient)
{
    string firstName = Prompt($"Enter firstname: ");
    myClient.Firstname = firstName;
}
void GetLastName(Client myClient)
{
    string lastname = Prompt($"Enter lastname: ");
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

void AddClientToList(Client myClient, List<Client> listofClients)
{
    if (myClient == null)
    {
        throw new ArgumentNullException($"No client provided to add to list.");
    }
    listofClients.Add(myClient);
    Console.WriteLine($"New client has added to list.");
}

Client FindClientInList(List<Client> listofClients)
{
    string myString = Prompt($"Enter partial client name: ");
    foreach (Client client in listofClients)
    {
        if (client.FullName.Contains(myString, StringComparison.OrdinalIgnoreCase))
        {
            ShowClientInfo(client);
            return client;
        }
    }
    Console.WriteLine("No clients match.");
    return null;
}

void RemoveClientFromList(Client myClient, List<Client> listofClients)
{
    if (myClient == null)
    {
        throw new ArgumentNullException($"No client provided to remove from list.");
    }
    listofClients.Remove(myClient);
    Console.WriteLine($"Client removed.");
}

void DisplayAllClientInList(List<Client> listofClients)
{
    foreach (Client client in listofClients)
    {
        ShowClientInfo(client);
    }
}

void LoadFileValuesToMemory(List<Client> listOfClients)
{
    while (true)
    {
        try
        {
            string fileName = "regin.csv";
            string filePath = $"./data/{fileName}";
            //Console.WriteLine($"{filePath}");
            if (!File.Exists(filePath))
            {
                throw new Exception($"The file {fileName} does not exist.");
            }
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                string[] items = csvFileInput[i].Split(",");
                Client myClient = new Client(items[0], items[1], int.Parse(items[2]), int.Parse(items[3]));
                listOfClients.Add(myClient);
            }
            Console.WriteLine($"Load complete. {fileName} has {listOfClients.Count} data entries.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}


void SaveMemoryValuesToFile(List<Client> listofClients)
{
    string fileName = "regout.csv";
    string filePath = $"./data/{fileName}";
    string[] csvLines = new string[listofClients.Count];
    for (int i = 0; i < listofClients.Count; i++)
    {
        csvLines[i] = listofClients[i].FullName + ',' + listofClients[i].Weight + ',' + listofClients[i].Height;
    }
    File.WriteAllLines(filePath, csvLines);
    Console.WriteLine($"Save complete. {fileName} has {listofClients.Count} entries.");
}