namespace ArithmeticQuiz;

internal class Arithmetic
{
    public static void Main(string[] args)
    {
        new Arithmetic().Solution();
    }


    private void Solution()
    {
        var dict = GenerateRandomOperators();
        Random random = new();

        var numOfQuiz = random.Next(5, 15);
        var correctCount = 0;
        var range = 0;

        var diff = "";

        while (diff != "easy" && diff != "hard")
        {
            Console.Write("\nChoose difficulty(easy,hard): ");
            diff = Console.ReadLine()!.ToLower();
            if (diff == "easy")
            {
                range = 10;
            }
            else if (diff == "hard")
            {
                range = 1000;
            }
            else
            {
                Console.WriteLine("\nYou've chosen invalid difficulty option! Please choose again!");
            }
        }

        Console.Clear();
        Console.WriteLine("\nArithmetic Quiz\n");

        for (var i = 1; i <= numOfQuiz; i++)
        {
            var op = dict[random.Next(1, 8)];
            long num1 = random.Next(range);
            long num2 = random.Next(range);

            Console.WriteLine($"Question {i}: What is {num1} {op} {num2}?");
            Console.Write("Your Answer: ");

            var ans = Compute(num1, num2, op);

            if (Console.ReadLine() == ans.ToString())
            {
                correctCount++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect! The correct answer is {ans}");
            }

            Console.WriteLine("\n");
        }


        Console.WriteLine("" +
                          "Results:\n" +
                          $"Total Correct Answers: {correctCount}\n" +
                          $"Percentage of Correct Answers: {Math.Round(((double)correctCount / (double)numOfQuiz) * 100, 2)}%\n");


        Console.Write("Try again? yes/no: ");
        if (Console.ReadLine()!.ToLower().Equals("yes"))
        {
            Console.Clear();
            Main([]);
        }

        Console.WriteLine("\n\n");
    }

    private static long Compute(long num1, long num2, char op)
    {
        if (op == '+')
        {
            return num1 + num2;
        }

        if (op == '-')
        {
            return num1 - num2;
        }


        if (op == '*')
        {
            return num1 * num2;
        }

        if (op == '/')
        {
            return num1 / (num2 == 0 ? 1 : num2);
        }

        return 0;
    }


    private static Dictionary<int, char> GenerateRandomOperators()
    {
        var dict = new Dictionary<int, char>
        {
            { 1, '+' },
            { 2, '-' },
            { 3, '*' },
            { 4, '/' },
            { 5, '+' },
            { 6, '-' },
            { 7, '*' },
            { 8, '/' }
        };

        return dict;
    }
}