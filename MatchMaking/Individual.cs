namespace MatchMaking
{
    internal class Individual
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Intro { get; set; }
        public string Habits { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }

        public Individual(int id, string name, Gender gender, int age, string intro, string habits, double coordX, double coordY)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Intro = intro;
            Habits = habits;
            CoordX = coordX;
            CoordY = coordY;
        }
    }
}
