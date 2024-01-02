namespace MatchMaking
{
    public class Class1
    {
        public void p1(int[] k)
        {
            int n = k.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (k[j] > k[j + 1])
                    {
                        int ppp = k[j];
                        k[j] = k[j + 1];
                        k[j + 1] = ppp;
                    }
                }
            }
        }

        public void p2(int[] k)
        {
            int n = k.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (k[j] < k[j + 1])
                    {
                        int ppp = k[j];
                        k[j] = k[j + 1];
                        k[j + 1] = ppp;
                    }
                }
            }
        }
        public void sort(int[] k, Func<int, int, bool> compare)
        {
            int n = k.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (compare(k[j], k[j + 1]))
                    {
                        int ppp = k[j];
                        k[j] = k[j + 1];
                        k[j + 1] = ppp;
                    }
                }
            }
        }
        public bool compare1(int i, int j)
        {
            return i > j;
        }

        public bool compare2(int i, int j)
        {
            return i < j;
        }
    }


    public abstract class SortTemplate
    {
        public void sort(int[] k)
        {
            int n = k.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Compare(k[j], k[j + 1]))
                    {
                        int ppp = k[j];
                        k[j] = k[j + 1];
                        k[j + 1] = ppp;
                    }
                }
            }
        }

        public abstract bool Compare(int i, int j);
    }

    public class SortTemplateT1 : SortTemplate
    {
        public override bool Compare(int i, int j)
        {
            return i > j;
        }
    }
    public class SortTemplateT2 : SortTemplate
    {
        public override bool Compare(int i, int j)
        {
            return i < j;
        }
    }
}
