namespace FootballTeams
{
    static class SomePlayers
    {
        public static Player Player1 = new()
        {
            FirstName = "Leo",
            SecondName = "Messi",
            Address = new()
            {
                Country = "Ru",
                City = "SPb",
                Street = "str1",
                Building = 3,
                Apartment = 4,
            },

            NumberOfGoals = 0
        };

        public static Player Player2 = new()
        {
            FirstName = "Cris",
            SecondName = "Ronal",
            Address = new()
            {
                Country = "Ru",
                City = "SPb",
                Street = "str2",
                Building = 7,
                Apartment = 8,
            },

            NumberOfGoals = 3
        };

    }
}