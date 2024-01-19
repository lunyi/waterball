using System;

namespace MatchMaking
{
    internal class MatchHabitsBased : IMatchMethod
    {
        public Individual[] Match<T>(Individual person, Individual[] individuals, Func<Dictionary<Individual, T>, IOrderedEnumerable<KeyValuePair<Individual, T>>> orderby) where T : struct
        {
            individuals = individuals.Where(p => p.Id != person.Id).ToArray();
            var habits = person.Habits.Split(',');
            var inds = new Dictionary<Individual, T>();

            for (int i = 0; i < individuals.Length; i++)
            {
                var habitCount = 0;
                var indHabits = individuals[i].Habits.Split(',');
                for (int j = 0; j < indHabits.Length; j++)
                {
                    for (int k = 0; k < habits.Length; k++)
                    {
                        if (indHabits[j].Contains(habits[k]))
                        {
                            habitCount++;
                        }
                    }
                }
                inds.Add(individuals[i], (T)(object)habitCount);
            }
            return orderby(inds).Select(p => p.Key).ToArray();
        }

        public Individual[] Match<T>(Individual person, Individual[] individuals)
        {
            individuals = individuals.Where(p => p.Id != person.Id).ToArray();
            var habits = person.Habits.Split(',');
            var inds = new Dictionary<Individual, T>();

            for (int i = 0; i < individuals.Length; i++)
            {
                var habitCount = 0;
                var indHabits = individuals[i].Habits.Split(',');
                for (int j = 0; j < indHabits.Length; j++)
                {
                    for (int k = 0; k < habits.Length; k++)
                    {
                        if (indHabits[j].Contains(habits[k]))
                        {
                            habitCount++;
                        }
                    }
                }
                inds.Add(individuals[i], (T)(object)habitCount);
            }
            return inds.Select(p => p.Key).ToArray();
        }
    }
}
