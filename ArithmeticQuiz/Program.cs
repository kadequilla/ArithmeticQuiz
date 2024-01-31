class Arithmetic
{
    static void Main(string[] args)
    {

        Arithmetic arithmetic = new Arithmetic();
        arithmetic.Solution();

    }


    public void Solution()
    {
        Dictionary<int, char> dict = GenerateRandomOperators();

        int numOfQuiz = new Random().Next(5, 15);
        int correctCount = 0;
        long num1;
        long num2;
        int range = 0;

        string diffculty = "";

        while (diffculty != "easy" && diffculty != "hard")
        {
            Console.Write("\nChoose difficulty(easy,hard): ");
            diffculty = Console.ReadLine()!.ToLower();
            if (diffculty == "easy")
            {
                range = 10;
            }
            else if (diffculty == "hard")
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

        for (int i = 1; i <= numOfQuiz; i++)
        {
            char op = dict[new Random().Next(1, 8)];
            num1 = new Random().Next(range);
            num2 = new Random().Next(range);

            Console.WriteLine($"Question {i}: What is {num1} {op} {num2}?");
            Console.Write("Your Answer: ");

            long ans = Compute(num1, num2, op);

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
            $"Percentage of Correct Answers: {Math.Round(((double)correctCount / (double)numOfQuiz) * 100, 2)}{"%"}\n");


        Console.Write("Try again? yes/no: ");
        if (Console.ReadLine()!.ToLower().Equals("yes"))
        {
            Console.Clear();
            Main([]);
        }

        Console.WriteLine("\n\n");
    }

    public long Compute(long num1, long num2, char op)
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


    public Dictionary<int, char> GenerateRandomOperators()
    {
        Dictionary<int, char> dict = new Dictionary<int, char>();
        dict.Add(1, '+');
        dict.Add(2, '-');
        dict.Add(3, '*');
        dict.Add(4, '/');
        dict.Add(5, '+');
        dict.Add(6, '-');
        dict.Add(7, '*');
        dict.Add(8, '/');

        return dict;
    }
}