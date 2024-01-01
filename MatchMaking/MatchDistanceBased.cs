using System.Linq;

namespace MatchMaking
{
    internal class MatchDistanceBased : IMatchMethod
    {
        public Individual[] Match<T>(Individual ind, Individual[] others, Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T: struct
        {
            var distList = new Dictionary<Individual, T>();
            others = others.Where(p => p.Id != ind.Id).ToArray();

            for (int i = 0; i < others.Length; i++)
            {
                var dis = Math.Pow(others[i].CoordX - ind.CoordX, 2) + Math.Pow(others[i].CoordY - ind.CoordY, 2);
                distList.Add(others[i], (T)(object)dis);
            }

            return orderby(distList).Select(p => p.Key).ToArray();
        }
    }
}
