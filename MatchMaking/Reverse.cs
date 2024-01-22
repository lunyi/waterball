namespace MatchMaking
{
    internal class Reverse : IMatchMethod
    {
        IMatchMethod _method;
        public Reverse(IMatchMethod method) 
        {
            _method = method;
        }
        public Individual[] Match<T>(Individual ind, Individual[] others, Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct
        {
            return _method.Match(ind, others, orderby);
        }

        public Individual[] Match<T>(Individual ind, Individual[] others)
        {
            var result = _method.Match<T>(ind, others);
            result.Reverse();
            return result;
        }
    }
}
