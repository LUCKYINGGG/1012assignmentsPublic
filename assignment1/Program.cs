// See https://aka.ms/new-console-template for more information

Assignment1();

void Assignment1() {
    Console.WriteLine("Please enter the initial investment amount: ");
    double investment = double.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the annual interest rate in percentage: ");
    double rate = double.Parse(Console.ReadLine());
    double monthlyRate = rate/100/12;
    Console.WriteLine("Please enter the number of years: ");
    int numYears = int.Parse(Console.ReadLine());
    double futureVal = investment * Math.Pow(1 + monthlyRate, numYears*12);
    Console.WriteLine($"Future value is {futureVal:c}");
}
