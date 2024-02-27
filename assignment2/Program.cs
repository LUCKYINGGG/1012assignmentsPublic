
Console.WriteLine("---- DMITCryptoEx ETH Trader ---- \n");
Random rnd = new Random();
double ETHprice = rnd.Next(2601, 3000);
Console.WriteLine($"Current ETH spot price is : {ETHprice:c2} \n");

double userPurchaseAmount = GetPurchaseAmount($"Enter amount of ETH to purchase: ", 0.000001);

double GetPurchaseAmount(string purchaseMsg, double minPurchase)
{
    bool invalidInput = true;
    double purchaseAmount = 0;
    while (invalidInput)
    {
        try
        {
            Console.Write(purchaseMsg);
            purchaseAmount = double.Parse(Console.ReadLine());
            if (purchaseAmount < minPurchase)
            {
                //Console.WriteLine($"Invalid purchase amount. Must be > {minPurchase:n6}");
                throw new Exception($"Invalid purchase amount. Must be > {minPurchase:n6}");
            }
            invalidInput = false;
        }
        catch (Exception minEx)
        {
            Console.WriteLine(minEx.Message);
        }
    }
    return purchaseAmount;
}

double stakeRate = 0.031;
Console.WriteLine($"\nCurrent stake rate is {stakeRate:p3}");

double getCommissionRate(double userPurchaseAmount)
{
    double commissionRate = 0;
    if (userPurchaseAmount > 0 && userPurchaseAmount < 1)
    {
        commissionRate = 0.019;
    }
    else if (userPurchaseAmount >= 1 && userPurchaseAmount < 5)
    {
        commissionRate = 0.0175;
    }
    else if (userPurchaseAmount >= 5 && userPurchaseAmount < 10)
    {
        commissionRate = 0.015;
    }
    else
    {commissionRate = 0.0125;}
    return commissionRate;
}
double monthlyStakeReward = ETHprice * stakeRate / 12;

void getStake()
{
    bool invalidInput = true;
    while (invalidInput)
    {
        try
        {
            Console.Write("Stake your ETH (y/n): ");
            string stakeAnswer = Console.ReadLine();
            if (stakeAnswer.ToLower() == "y")
            {
                Console.WriteLine($"\nYou will earn {monthlyStakeReward:c} per month for your staked ETH.");
                Console.WriteLine($"\nPlease review your order ...\n");
                Console.WriteLine($"Total ETH purchased: {userPurchaseAmount:n6}");
                double commissionRate = getCommissionRate(userPurchaseAmount);
                double totalCommission = ETHprice * commissionRate;
                double totalPurchase = ETHprice * userPurchaseAmount + totalCommission;
                Console.WriteLine($"Total ETH purchased: {userPurchaseAmount}");
                Console.WriteLine($"ETH spot price: {ETHprice:c}");
                Console.WriteLine($"Commission rate: {commissionRate:p3}");
                Console.WriteLine($"Total commission: {totalCommission:c}");
                Console.WriteLine($"Staked?: {stakeAnswer}");
                Console.WriteLine($"Stake monthly reward: {monthlyStakeReward:c}");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"Total purchase: {totalPurchase:n2}");
                invalidInput = false;
            }
            else if (stakeAnswer.ToLower() == "n")
            {
                Console.WriteLine($"\nPlease review your order ...\n");
                double commissionRate = getCommissionRate(userPurchaseAmount);
                double totalCommission = ETHprice * commissionRate;
                double totalPurchase = ETHprice * userPurchaseAmount + totalCommission;
                Console.WriteLine($"Total ETH purchased: {userPurchaseAmount:n6}");
                Console.WriteLine($"ETH spot price: {ETHprice:c}");
                Console.WriteLine($"Commission rate: {commissionRate:p3}");
                Console.WriteLine($"Total commission: {totalCommission:c}");
                Console.WriteLine($"Staked?: {stakeAnswer}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Total purchase: {totalPurchase:n2}");
                invalidInput = false;
            }
            else
            {throw new Exception($"Invalid input. Must be y or n");}
        }
        catch (Exception stakeEx)
        {
            Console.WriteLine(stakeEx.Message);
        }
    }
}
getStake();

void getCountinue()
{
    bool invalidInput = true;
    while (invalidInput)
    {
        try
        {
            Console.WriteLine("\nWould you like to continue with your order (y/n): ");
            string continuAnswer = Console.ReadLine();
            if (continuAnswer.ToLower() == "y")
            {
                Console.WriteLine("\nYour order has been sent. Thank you.");
                invalidInput = false;
            }
            else if (continuAnswer.ToLower() == "n")
            {
                Console.WriteLine("\nYour order has been cacelled.");
                invalidInput = false;
            }
            else
            {throw new Exception($"Invalid input. Must be y or n");}
        }
        catch (Exception continueEx)
        {
            Console.WriteLine(continueEx.Message);
        }
    }
}
getCountinue();

Console.WriteLine("\nThank you for using DMITCryptoEx!");






/*
The following code is only for my own exploration.
void getOrderView(string prompMessage, double orderValue)
{
    if (prompMessage == "ETH spot price" || prompMessage == "Total commission" || prompMessage == "Total purchase" || prompMessage == "Stake monthly reward")
    {
        Console.WriteLine($"{prompMessage}: {orderValue:c}");
    }
    else
        Console.WriteLine($"{prompMessage}: {orderValue:n2}");
}*/

/*
    getOrderView("Total ETH purchased", userPurchaseAmount);
    getOrderView("ETH spot price", ETHprice);
    getOrderView("Commission rate", commissionRate);
    getOrderView("Total commission", totalCommission);
    Console.WriteLine($"Staked? {stakeAnswer}");
    getOrderView("Stake monthly reward", monthlyStakeReward);
    Console.WriteLine("-----------------------------------------------------------------");
    getOrderView("Total purchase", totalPurchase); */