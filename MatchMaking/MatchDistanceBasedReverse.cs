namespace MatchMaking
{
    internal class MatchDistanceBasedReverse : IMatchMethod
    {
        private IMatchMethod _method;
        public MatchDistanceBasedReverse(IMatchMethod method)
        {
            _method = method;
        }

        public Individual[] Match<T>(Individual ind, Individual[] others)
        {
            var res = _method.Match<T>(ind, others);
            res.Reverse();
            return res;
        }

        public Individual[] Match<T>(Individual ind, Individual[] others, Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct
        {
            return _method.Match(ind, others, orderby);
        }
    }
}
