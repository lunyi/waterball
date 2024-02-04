namespace MatchMaking
{
    internal class MatchDistanceBased : IMatchStrategy
    {
        public Individual[] Match<T>(
            Individual ind, 
            Individual[] others, 
            Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T: struct
        {
            var distList = new Dictionary<Individual, T>();
            others = others.Where(p => p.Id != ind.Id).ToArray();

            foreach (var other in others)
            {
                var dis = ind.Coord.GetDistance(other.Coord);
                distList.Add(other, (T)(object)dis);
            }

            return orderby(distList).Select(p => p.Key).ToArray();
        }

        public Individual[] Match<T>(Individual ind, Individual[] others)
        {
            var distList = new List<Individual>();
            others = others.Where(p => p.Id != ind.Id).ToArray();

            foreach (var other in others)
            {
                var dis = ind.Coord.GetDistance(other.Coord);
                distList.Add(other);
            }

            return distList.OrderBy(p=>p.Coord.GetDistance(ind.Coord)).ToArray();
        }
    }
}
