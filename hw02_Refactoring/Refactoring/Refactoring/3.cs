using System;

class Fighter
{
    private int iDamage;
    // public string sName;
    public int FighterHealth
    { get; set; }
    public int FighterDamage
    { get; set; }
    public int Weapon_Status
    { get; set; }

    private void LogStatus(string name, int age, int health, int damage, int weaponStatus)
    {
        Console.WriteLine($"name:{name}, " +
            $"age:{age}, health:{health}, " +
            $"damage:{damage}, weaponStatus:{ weaponStatus}"); 
    }

    public int GetDamage()
    {
        // TODO: implement damage

        // Weapon_Status * 5 
        // Console.WriteLine($"Get Damage {iDamage}"); 
        return iDamage;
    }

    private void DoAttack()
    {
        Console.WriteLine("Go Attack!");
        // TODO: implement attack 
    }

    public void Attack()
    {
        try
        {
            DoAttack();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Go Attack Exception: {e}");
            // throw e;
        }
    }
}