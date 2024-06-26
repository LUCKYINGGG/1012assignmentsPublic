﻿
// TODO: declare a constant to represent the max size of the values
// and dates arrays. The arrays must be large enough to store
// values for an entire month.
using Microsoft.VisualBasic;

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
        Console.WriteLine(prompt);
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
    Console.WriteLine($"Dates         Values");
    for (int i = 1; i < csvFileInput.Length; i++)
    {
        string[] items = csvFileInput[i].Split(',');
        Console.WriteLine($"{items[0]}    {items[1]}");
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
    Array.Sort(dates, values, 0, logicalSize);
    Console.WriteLine($"\nCurrent Loaded Entries: {logicalSize}");
    Console.WriteLine($"   Date     Value");
    for (int i = 0; i < logicalSize; i++)
    {
        Console.WriteLine($"{dates[i]}   {values[i]}");
    }
}

double FindHighestValueInMemory(double[] values, int logicalSize)
{
    double max = 0;
    for (int i = 0; i < logicalSize; i++)
    {
        if (max < values[i])
        {
            max = values[i];
        }
    }
    Console.WriteLine($"The Highest values is {max:n2}.");
    return max;
    //TODO: Replace this code with yours to implement this function.
}

double FindLowestValueInMemory(double[] values, int logicalSize)
{
    double min = values[0];
    for (int i = 0; i < logicalSize; i++)
    {
        if (min > values[i])
        {
            min = values[i];
        }
    }
    Console.WriteLine($"The Lowest values is {min:n2}.");
    return min;
    //TODO: Replace this code with yours to implement this function.
}

void FindAverageOfValuesInMemory(double[] values, int logicalSize)
{
    double sum = 0;
    for (int i = 0; i < logicalSize; i++)
    {
        sum += values[i];
    }
    double avg = sum / logicalSize;
    Console.WriteLine($"The average is {avg:n2}.");
    //TODO: Replace this code with yours to implement this function.
}

void SaveMemoryValuesToFile(string[] dates, double[] values, int logicalSize)
{
    string fileName = Prompt("Please enter file name including .csv or .txt: ");
    string filePath = $"./data/{fileName}";
    if (logicalSize == 0)
        throw new Exception($"No entries loaded. Please load or add entries into memory.");
    if (logicalSize > 1)
    {
        Array.Sort(dates, values, 0, logicalSize);
    }
    string[] csvFileLines = new string[logicalSize + 1];
    csvFileLines[0] = "dates,values";
    for (int i = 1; i <= logicalSize; i++)
    {
        csvFileLines[i] = $"{dates[i - 1]}, {values[i - 1].ToString()}";
    }
    File.WriteAllLines(filePath, csvFileLines);
    Console.WriteLine($"Save completed. {fileName} has {logicalSize} entries.");
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
            if (value >= min && value < max)
            {
                value = Math.Round(value, 1);
                return value;
            }
            else
                throw new Exception($"Invalida input: ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}Please enter a valid double between {min} and {max}.");
        }
    }
}

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{
    string addMore;
    do
    {
        if (logicalSize <= physicalSize)
        {
            try
            {
                string StringDate = PromptDate($"Enter the Date of the entry in the format of mm-dd-yyyy (eg 11-23-2023): ");
                // TODO: handle multi user input. what if user input same dates multiple times?
                int flag = Array.IndexOf(dates, StringDate);
                if (flag == -1)
                {
                    double DoubleValue = PromptDouble($"Enter a double value: ", 0.0, 1000.0);
                    dates[logicalSize] = StringDate;
                    values[logicalSize] = DoubleValue;
                    logicalSize++;
                    Console.WriteLine($"You have entered one entry at date {dates[logicalSize - 1]} with value {values[logicalSize - 1]}.");
                }
                else
                {
                    throw new Exception("This date has already in the file. Please enter a different date. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"This month has no spare days for adding entry.");
        }
        addMore = Prompt("Do you want to add more entries? Please answer Y or N.").ToUpper();
    } while (addMore != "N");
    return logicalSize;
    //TODO: Replace this code with yours to implement this function.
}

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
    string addMore;
    if (logicalSize == 0)
    {
        throw new Exception($"No entries loaded. Please load a file to memory or add a value in memory.");
    }
    do
    {
        string editDate = PromptDate("Please select a date of entry in the format of mm-dd-yyyy (eg 11-23-2023): ");
        for (int i = 0; i < logicalSize; i++)
        {
            if (editDate.Equals(dates[i]))
            {
                dates[i] = editDate;
                double editValue = PromptDouble("Please enter an updated value: ", 0.0, 1000.0);
                values[i] = editValue;
                Console.WriteLine($"You have edited one entry at {editDate} with the value of {editValue}.");
                break;
            }
            else if (i == logicalSize - 1)
            {
                Console.WriteLine("There is no matching date of entry. Please load files or enter data before editing.");
            }
        }
        addMore = Prompt("Do you want to edit more entries? Please answer Y or N.").ToUpper();
    } while (addMore != "N");
    //TODO: Replace this code with yours to implement this function.
}

void GraphValuesInMemory(string[] dates, double[] values, int logicalSize)
{
    Array.Sort(dates, values, 0, logicalSize);
    double max = FindHighestValueInMemory(values, physicalSize);
    int yAxisMaxRoundUp = Convert.ToInt32(Math.Ceiling(max));

    int yAxisInterval;

    if (yAxisMaxRoundUp < 100)
    {
        yAxisInterval = 5;
    }
    else if (yAxisMaxRoundUp >= 100 && yAxisMaxRoundUp < 300)
    {
        yAxisInterval = 10;
    }
    else
    {
        yAxisInterval = 50;
    }
    double[] valuesOfMonth = new double[32];
    for (int i = 0; i < logicalSize; i++)
    {
        if (dates[i] != null)
        {
            string date = dates[i];
            string test = date.Substring(3, 2);
            int intDate = int.Parse(date.Substring(3, 2));
            double value = values[i];
            valuesOfMonth[intDate] = value;
        }
    }

    int yAxisNum = yAxisMaxRoundUp / yAxisInterval + 1;
    Console.WriteLine($"\t\t\t\t Sales for selected month");
    string empty = "";
    char bar = '|';
    for (int i = 0; i < yAxisNum; i++)
    {
        Console.Write($" ${yAxisMaxRoundUp}");
        if (yAxisMaxRoundUp < 10)
        {
            Console.Write(empty.PadLeft(3)+bar);
        }
        else if (yAxisMaxRoundUp >= 100)
        {
            Console.Write(empty.PadLeft(1)+bar);
        }
        else
        {
            Console.Write(empty.PadLeft(2)+bar);
        }
        // Console.Write(" ");
        for (int h = 1; h < physicalSize + 1; h++)
        {
            if (valuesOfMonth[h] >= yAxisMaxRoundUp && valuesOfMonth[h] < yAxisMaxRoundUp + yAxisInterval)
            {
                valuesOfMonth[h] = Math.Floor(valuesOfMonth[h]);
                string strValues = valuesOfMonth[h].ToString().PadRight(4);
                Console.Write(strValues);
            }
            else
            {
                Console.Write("    ");
            }
        }
        yAxisMaxRoundUp -= yAxisInterval;
        Console.WriteLine("");
    }
    for (int j = 0; j < physicalSize + 2; j++)
    {
        Console.Write($"----");
    }
    Console.Write("\n Days | ");
    for (int k = 1; k < physicalSize + 1; k++)
    {
        string strK = k.ToString().PadRight(4);
        Console.Write(strK);
    }
    Console.WriteLine("\n");
    //TODO: Replace this code with yours to implement this function.
}