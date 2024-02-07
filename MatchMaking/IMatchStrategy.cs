
namespace MatchMaking
{
    internal interface IMatchStrategy
    {
        Individual[] Match<T>(
            Individual ind, 
            Individual[] others, 
            Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct;

        Individual[] Match<T>(Individual ind, Individual[] others);
    }
}
