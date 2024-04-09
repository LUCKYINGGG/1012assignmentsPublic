using ClientInfor;

Client myClient = new Client();

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
            ShowPetInfo(myClient);

        if (mainMenuChoice == "A")
            AddPetToList(myClient, listOfPets);
        if (mainMenuChoice == "F")
            myClient = FindPetInList(listOfPets);
        if (mainMenuChoice == "R")
            RemovePetFromList(myClient, listOfPets);
        if (mainMenuChoice == "D")
            DisplayAllPetsInList(listOfPets);
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listOfPets);
            loopAgain = false;
            throw new Exception("Bye, hope to see you again.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
                if (editMenuChoice == "T")
                    GetTag(myClient);
                if (editMenuChoice == "N")
                    GetName(myClient);
                if (editMenuChoice == "A")
                    GetAge(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "P")
                    GetType(myClient);
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
    Console.WriteLine("N) New Pet PartA");
    Console.WriteLine("S) Show Pet Info PartA");
    Console.WriteLine("E) Edit Pet Info PartA");
    Console.WriteLine("A) Add Pet To List PartB");
    Console.WriteLine("F) Find Pet In List PartB");
    Console.WriteLine("R) Remove Pet From List PartB");
    Console.WriteLine("D) Display all Pets in List PartB");
    Console.WriteLine("Q) Quit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit Menu");
    Console.WriteLine("T) Tag");
    Console.WriteLine("N) Name");
    Console.WriteLine("A) Age");
    Console.WriteLine("W) Weight");
    Console.WriteLine("P) Type");
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

double PromptDoubleBetweenMinMax(String msg, double min, double max)
{
    double num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max} inclusive: ");
            num = double.Parse(Console.ReadLine());
            if (num < min || num > max)
                throw new Exception($"Must be between {min:n2} and {max:n2}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

Client NewClient()
{

    return myClient;
}