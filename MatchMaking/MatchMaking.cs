namespace MatchMaking
{
    internal class MatchMaking
    {
        private readonly Individual[] _individuals;
        private IMatchStrategy _matchMethod;
        
        public MatchMaking(Individual[] individuals)
        {
            _individuals = individuals;
        }

        public void SetMatchMethod(IMatchStrategy matchMethod)
        {
            _matchMethod = matchMethod;
        }
        public Individual[] Match<T>(
            Individual ind, 
            Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct
        {
            return _matchMethod.Match(ind, _individuals, orderby);
        }
    }
}
