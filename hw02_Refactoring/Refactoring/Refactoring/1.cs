class DataOrg
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int age, score;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    int nameLength;
    const int nameLenghtCoefficient = 4, minNameLength = 3;
    const int minAge = 18, maxAge = 65;

    public class Row
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Time { get; set; }
        const double ageCoefficient = 0.83;

        public Row(string name, int age)
        {
            Name = name;
            Age = $"{age * ageCoefficient}";
            Time = DateTime.Now.ToString();
        }
    }

    public Row? GetRow()
    {
        if (name == null)
            return null;
        var row = new Row(name, age);
        return row;
    }

    private bool IsCorrectData()
    {
        if (name.Length < minNameLength)
            return false;
        if (age < minAge || age > maxAge)
            return false;
        if (score == -1)
            return false;
        return true;
    }

    public int CalculateNamelength()
    {
        if (name == null)
            return -1;
        if (IsCorrectData())
            nameLength = name.Length * nameLenghtCoefficient;
        return 0;
    }

    public void SetValue(string name, int value)
    {
        if (name.Equals("age"))
            age = value;
        if (name.Equals("score"))
            score = value;
    }
}
