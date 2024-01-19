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
        public Coord Coord { get; set; }

        public Individual(int id, string name, Gender gender, int age, string intro, string habits, Coord coord)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            Intro = intro;
            Habits = habits;
            Coord = coord;
        }
    }
}
