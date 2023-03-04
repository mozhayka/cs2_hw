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
            throw new ArgumentNullException("name");
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

    public void CalculateNamelength()
    {
        if (name == null)
            throw new ArgumentNullException("name");
        if (IsCorrectData())
            nameLength = name.Length * nameLenghtCoefficient;
    }

    public void SetValue(string name, int value)
    {
        if (name.Equals("age"))
            SetAge(value);
        if (name.Equals("score"))
            SetScore(value);
    }

    private void SetAge(int value)
    {
        age = value;
    }

    private void SetScore(int value)
    {
        score = value;
    }
}
