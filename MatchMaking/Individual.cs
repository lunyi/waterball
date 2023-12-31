namespace MatchMaking
{
    internal class Individual
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Intro { get; set; }
        public string Habits { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }

        private IMatchMethod _matchMethod;

        public Individual(int id, Gender gender, int age, string intro, string habits, double coordX, double coordY)
        {
            Id = id;
            Gender = gender;
            Age = age;
            Intro = intro;
            Habits = habits;
            CoordX = coordX;
            CoordY = coordY;
        }
        public void SetMatchNMethod(IMatchMethod method)
        {
            _matchMethod = method;
        }

        public Individual[] Match(IMatchMethod method, Individual[] others)
        {
            return _matchMethod.Match(this, others);
        }
    }
}
