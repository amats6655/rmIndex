namespace Remove
{
    class RemoveIndex
    {
        private static List<int> CreateList(int start, int end)
        {
            List<int> numbers = new();
            for (; start < end; start++)
                numbers.Add(start);
            return numbers;
        }


        private static void CreateIndices(int len, out List<int> honestIndices, out List<int> oddIndices)
        {
            honestIndices = new List<int>();
            oddIndices = new List<int>();
            for (int i = 0; i < len; i++)
            {
                if (i % 2 == 0) { honestIndices.Add(i); }
                else { oddIndices.Add(i); }
            }
        }


        private static void RemoveElements(ref List<int> numbers, List<int> indices)
        {
            indices.Reverse();
            foreach (int i in indices)
            {
                numbers.RemoveAt(i);
            }
        }


        static void Main(string[] args)
        {
            string input = "input.txt";
            string output = "output.txt";
            int start = int.Parse(File.ReadLines(input).ElementAtOrDefault(0));
            int end = int.Parse(File.ReadLines(input).ElementAtOrDefault(1));
            List<int> numbers = CreateList(start, end);

            while (numbers.Count > 1)
            {
                CreateIndices(numbers.Count, out List<int> honestIndices, out _);
                RemoveElements(ref numbers, honestIndices);
                while (numbers.Count > 1)
                {
                    CreateIndices(numbers.Count, out _, out List<int> oddIndices);
                    RemoveElements(ref numbers, oddIndices);
                    break;
                }
            }
            StreamWriter writer = new(output);
            writer.WriteLine(numbers[0]);
            writer.Close();
        }
    }
}