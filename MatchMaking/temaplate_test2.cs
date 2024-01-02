namespace MatchMaking
{
    public class SearchLongestMessage
    {
        public string GetMaxString(List<string> test)
        {
            return test.Where(c => c.Length == test.Max(p => p.Length)).First();
        }

        public string Search(string[] messages)
        {
            string maxLengthMessage = "";
            foreach (string message in messages)
            {
                if (message.Length > maxLengthMessage.Length)
                {
                    maxLengthMessage = message;
                }
                Console.WriteLine(message);
            }
            return maxLengthMessage;
        }
    }

    public class SearchEmptyMessageIndex
    {
        public int GetWaterballCount(List<string> test)
        {
            return test.Count(p => !string.IsNullOrEmpty(p));
        }

        public int Search(string[] messages)
        {
            int index = 0;
            while (index < messages.Length && !string.IsNullOrEmpty(messages[index]))
            {
                Console.WriteLine(messages[index]);
                index++;
            }
            return index >= messages.Length ? -1 : index;
        }
    }
    public class CountNumberOfWaterballs
    {
        public int GetWaterballCount(List<string> test)
        {
            return test.Count(p => p.Equals("Waterball"));
        }

        public int Count(string[] messages)
        {
            int count = 0;
            foreach (string message in messages)
            {
                if ("Waterball".Equals(message))
                {
                    count++;
                }
                Console.WriteLine(message);
            }
            return count;
        }
    }

    public abstract class StringTemplate<T>
    {
        public T Calculate(string[] messages)
        {
            T count = default;
            foreach (string message in messages)
            {
                count = Compare(message, count);
                Console.WriteLine(message);
            }
            return count;
        }

        public abstract T Compare(string message, T count);
    }

    public class ContainWaterball : StringTemplate<int>
    {
        public override int Compare(string message, int count)
        {
            if (message.Equals("Waterball"))
            {
                count++;
            }
            return count;
        }
    }

    public class ContainNotContainEmpty : StringTemplate<int>
    {
        public override int Compare(string message, int count)
        {
            if (!string.IsNullOrEmpty(message))
            {
                count++;
            }
            return count;
        }
    }

    public class FindMaxString : StringTemplate<string>
    {
        public override string Compare(string message, string count)
        {
            var tmp = message;
            if (message.Length > count.Length)
            {
                tmp = message;
            }
            return tmp;
        }
    }
}
