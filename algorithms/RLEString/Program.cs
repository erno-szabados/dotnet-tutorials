using System.Text;

namespace Algorithms;

/**
 * Run-lenght encode and print string example.
 * aaabbbccaa -> a3b3c2a2
 * For byte RLE, use MemoryStream.
 */
class Program
{
    private static string CompressString(String input)
    {
        StringBuilder sb = new();
        Stack<char> stack = new();

        if (input is null || input.Length == 0)
        {
            return sb.ToString();
        }

        foreach (var s in input)
        {
            if (stack.TryPeek(out char c))
            {
                if (c != s)
                {
                    WriteCharOnStack();
                }
            }
            stack.Push(s);
        }

        // String is over, but stack is not empty
        WriteCharOnStack();
        return sb.ToString();

        #region Helpers
        void WriteCharOnStack()
        {
            int i = 0;
            char c = ' ';
            while (stack.TryPop(out char n))
            {
                c = n;
                i++;
            }
            sb.Append($"{c}{i}");
        }
        #endregion
    }

    static void Main(string[] args)
    {
        Console.WriteLine(CompressString(null));
        Console.WriteLine(CompressString(""));
        Console.WriteLine(CompressString("aaabbbccabba"));
        Console.WriteLine(CompressString("aaa"));
        Console.WriteLine(CompressString("a"));
        Console.WriteLine(CompressString("ababaababbab"));
    }
}