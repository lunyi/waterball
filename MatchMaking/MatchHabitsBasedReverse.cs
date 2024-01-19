namespace MatchMaking
{
    internal class MatchHabitsBasedReverse : IMatchMethod
    {
        private IMatchMethod _method;

        public MatchHabitsBasedReverse(IMatchMethod method)
        {
            _method = method;
        }

        public Individual[] Match<T>(Individual person, Individual[] individuals)
        {
            var res = _method.Match<T>(person, individuals);
            res.Reverse();
            return res;
        }

        public Individual[] Match<T>(Individual person, Individual[] individuals, Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct
        {
            return _method.Match(person, individuals, orderby);
        }
    }
}
