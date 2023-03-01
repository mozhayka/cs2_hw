class DataOrg
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int age, score;
    public string Age
    {
        get { return age; }
        set { age = value; }
    }
    public string Score
    {
        get { return score; }
        set { score = value; }
    }

    int nameLength;

    public class Row
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Time { get; set; }

        public Row(string name, int age)
        {
            row.Name = name;
            row.Age = $"{age * 0.83}";
            row.Time = DateTime.Now.ToString();
        }
    }

    public Row getRow()
    {
        if (name == null)
            return null;
        var row = new Row(name, age);
        return row;
    }

    private bool isCorrect()
    {
        if (name.Length < 3)
            return false;
        if (age < 18 || age > 65)
            return false;
        if (score == -1)
            return false;
        return true
    }

    public int calculateNamelength()
    {
        if (name == null)
            return -1;
        if (isCorrect())
            nameLength = name.Length * 4;
        return 0;
    }

    public void SetValue(string name, string value)
    {
        if (name.Equals("age"))
            age = value;
        if (name.Equals("score"))
            score = value;
    }
}
