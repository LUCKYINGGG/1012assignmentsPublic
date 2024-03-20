
// TODO: declare a constant to represent the max size of the values
// and dates arrays. The arrays must be large enough to store
// values for an entire month.
int physicalSize = 31;
int logicalSize = 0;

// TODO: create a double array named 'values', use the max size constant you declared
// above to specify the physical size of the array.
double[] values = new double[physicalSize];

// TODO: create a string array named 'dates', use the max size constant you declared
// above to specify the physical size of the array.
string[] dates = new string[physicalSize];

bool goAgain = true;
while (goAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (mainMenuChoice == "L")
            logicalSize = LoadFileValuesToMemory(dates, values);
        if (mainMenuChoice == "S")
            SaveMemoryValuesToFile(dates, values, logicalSize);
        if (mainMenuChoice == "D")
            DisplayMemoryValues(dates, values, logicalSize);
        if (mainMenuChoice == "A")
            logicalSize = AddMemoryValues(dates, values, logicalSize);
        if (mainMenuChoice == "E")
            EditMemoryValues(dates, values, logicalSize);
        if (mainMenuChoice == "Q")
        {
            goAgain = false;
            throw new Exception("Bye, hope to see you again.");
        }
        if (mainMenuChoice == "R")
        {
            while (true)
            {
                if (logicalSize == 0)
                    throw new Exception("No entries loaded. Please load a file into memory");
                DisplayAnalysisMenu();
                string analysisMenuChoice = Prompt("\nEnter an Analysis Menu Choice: ").ToUpper();
                if (analysisMenuChoice == "A")
                    FindAverageOfValuesInMemory(values, logicalSize);
                if (analysisMenuChoice == "H")
                    FindHighestValueInMemory(values, logicalSize);
                if (analysisMenuChoice == "L")
                    FindLowestValueInMemory(values, logicalSize);
                if (analysisMenuChoice == "G")
                    GraphValuesInMemory(dates, values, logicalSize);
                if (analysisMenuChoice == "R")
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
    Console.WriteLine("L) Load Values from File to Memory");
    Console.WriteLine("S) Save Values from Memory to File");
    Console.WriteLine("D) Display Values in Memory");
    Console.WriteLine("A) Add Value in Memory");
    Console.WriteLine("E) Edit Value in Memory");
    Console.WriteLine("R) Analysis Menu");
    Console.WriteLine("Q) Quit");
}

void DisplayAnalysisMenu()
{
    Console.WriteLine("\nAnalysis Menu");
    Console.WriteLine("A) Find Average of Values in Memory");
    Console.WriteLine("H) Find Highest Value in Memory");
    Console.WriteLine("L) Find Lowest Value in Memory");
    Console.WriteLine("G) Graph Values in Memory");
    Console.WriteLine("R) Return to Main Menu");
}

string Prompt(string prompt)
{
    string response = "";
    try
    {
        Console.Write(prompt);
        response = Console.ReadLine().Trim();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Invalid input: {ex.Message}");
    }
    return response;
}

string GetFileName()
{
    string fileName = "";
    do
    {
        fileName = Prompt("Enter file name including .csv or .txt: ");
    } while (string.IsNullOrWhiteSpace(fileName));
    return fileName;
}

int LoadFileValuesToMemory(string[] dates, double[] values)
{
    string fileName = GetFileName();
    int logicalSize = 0;
    string filePath = $"./data/{fileName}";
    if (!File.Exists(filePath))
        throw new Exception($"The file {fileName} does not exist.");
    string[] csvFileInput = File.ReadAllLines(filePath);
    for (int i = 0; i < csvFileInput.Length; i++)
    {
        Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
        string[] items = csvFileInput[i].Split(',');
        for (int j = 0; j < items.Length; j++)
        {
            Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
        }
        if (i != 0)
        {
            dates[logicalSize] = items[0];
            values[logicalSize] = double.Parse(items[1]);
            logicalSize++;
        }
    }
    Console.WriteLine($"Load complete. {fileName} has {logicalSize} data entries");
    return logicalSize;
}

void DisplayMemoryValues(string[] dates, double[] values, int logicalSize)
{
    if (logicalSize == 0)
        throw new Exception($"No Entries loaded. Please load a file to memory or add a value in memory");
    Console.WriteLine($"\nCurrent Loaded Entries: {logicalSize}");
    Console.WriteLine($"   Date     Value");
    for (int i = 0; i < logicalSize; i++)
        Console.WriteLine($"{dates[i]}   {values[i]}");
}

double FindHighestValueInMemory(double[] values, int logicalSize)
{
    double max = values[logicalSize];
    for (logicalSize = 0; logicalSize < values.Length; logicalSize++)
    {
        if (max < values[logicalSize])
        {
            max = values[logicalSize];
        }
    }
    return max;
    //TODO: Replace this code with yours to implement this function.
}

double FindLowestValueInMemory(double[] values, int logicalSize)
{
    double min = values[logicalSize];
    for (logicalSize = 0; logicalSize < values.Length; logicalSize++)
    {
        if (min > values[logicalSize])
        {
            min = values[logicalSize];
        }

    }
    return min;
    //TODO: Replace this code with yours to implement this function.
}

void FindAverageOfValuesInMemory(double[] values, int logicalSize)
{
    double sum = 0;
    for (logicalSize = 0; logicalSize < values.Length; logicalSize++)
    {
        sum += values[logicalSize];
    }
    //return sum / values.Length;
    double avg = sum / logicalSize;
    Console.WriteLine($"{avg}");
    //TODO: Replace this code with yours to implement this function.
}

void SaveMemoryValuesToFile(string[] dates, double[] values, int logicalSize)
{

    Console.WriteLine("Not Implemented Yet");
    //TODO: Replace this code with yours to implement this function.
}

string PromptDate(string prompt)
{
    DateTime date = DateTime.Today;
    string dateString = prompt;
    while (true)
    {
        try
        {
            Console.WriteLine(prompt);
            date = DateTime.Parse(Console.ReadLine());
            dateString = date.ToString("MM-dd-yyyy");
            return dateString;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

double PromptDouble(string prompt, double min, double max)
{
    double value = 0;
    while (true)
    {
        try
        {
            Console.WriteLine(prompt);
            value = double.Parse(Console.ReadLine());
            if (value > min && value < max)
            {
                return value;
            }
            // else
            // {
            //     throw new Exception($"Please enter a valid double between {min} and {max}.");
            // }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Please enter a valid double between {min} and {max}: {ex.Message}");
        }
        
    }
}

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{

    if (logicalSize < physicalSize)
    {
        string StringDate = PromptDate($"Enter the Date of the entry in the format of mm-dd-yyyy (eg 11-23-2023): ");
        double DoubleValue = PromptDouble($"Enter a double value: ", 0.0, 1000.0);
        dates[logicalSize] = StringDate;
        values[logicalSize] = DoubleValue;
        return logicalSize++;
    }
    else
    {
        Console.WriteLine($"This month has no spare days for adding entry.");
        return logicalSize;
    }
    //TODO: Replace this code with yours to implement this function.
}

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
    PromptDate("Please select a date of entry: ");
    string editDate = Console.ReadLine();
    for (int i = 0; i < logicalSize; i++)
    {
        if (editDate.Equals(dates[i]))
        {
            dates[i] = editDate;
        }
        else
        {
            Console.WriteLine("There is no matching date of entry. Please load files or enter data before editing.");
        }
    }
    PromptDouble("Please enter an updated value: ", 0.0, 1000.0);
    double editValue = double.Parse(Console.ReadLine());
    for (int j = 0; j < logicalSize; j++)
    {
        values[j] = editValue;
    }

    //TODO: Replace this code with yours to implement this function.
}

void GraphValuesInMemory(string[] dates, double[] values, int logicalSize)
{
    Console.WriteLine("Not Implemented Yet");
    //TODO: Replace this code with yours to implement this function.
}