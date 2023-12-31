namespace MatchMaking
{
    internal interface IMatchMethod
    {
        public Individual[] Match(Individual ind, Individual[] others);

    }
}
