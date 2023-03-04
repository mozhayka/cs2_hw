using System;

public class gMethods
{
    public string Name { get; set; }
    private int price;
    private int amount;
    private string platform;
    private const float amountCoefficient = 0.956f;
    private const double tempCoefficient = 0.8;

    public void PrintPack()
    {
        this.PrintBanner();
        this.PrintDetails();
    }

    private void PrintDetails()
    {
        Console.WriteLine("name: " + this.Name);
        Console.WriteLine("amount: " + this.GetAmount());
        Console.WriteLine("price: " + this.price);
        Console.WriteLine("platform: " + platform);
    }

    public float GetAmount()
    {
        if (IsPlatformNameGood())
            return amount * amountCoefficient;
        ChangeTempAndWrite();
        return -1;
    }

    private bool IsPlatformNameGood()
    {
        return (platform.ToUpper().IndexOf("PC") > -1) &&
            (Name.ToUpper().IndexOf("XX") > -1) && amount > 0;
    }

    private void ChangeTempAndWrite()
    {
        double temp = amount * price;
        Console.WriteLine(temp);
        temp = tempCoefficient * amount * price;
        Console.WriteLine(temp);
    }
}