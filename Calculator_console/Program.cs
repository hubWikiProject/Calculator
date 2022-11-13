internal class Program
{
    private static void Main(string[] args)
    {
        double numberOne;
        double numberTwo;
        string operation;

        do
        {
            try
            {
                numberOne = GetInputNumber("Введите первое число");
                numberTwo = GetInputNumber("Введите второе число");
                operation = GetInputOperation("Введите арифметическую операцию -, +, *, /, max, min");

                Console.WriteLine(GetResult(numberOne, numberTwo, operation));
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        } while (AskContinue());

    }

    private static bool AskContinue()
    {
        while (true)
        {
            Console.WriteLine("Хотите продолжить y/n");
            string? answer = Console.ReadLine();
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Операция не распознана. Введите y или n: ");
            }
        }
    }

    static double GetInputNumber(string message)
    {
        Console.WriteLine(message);

        while (true)
        {
            if (Double.TryParse(Console.ReadLine(), out double number) == true)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз. Введите корректное число.");
            }
        }
    }

    static string GetInputOperation(string message)
    {
        string[] operations = { "-", "+", "*", "/", "max", "min" };

        Console.WriteLine(message);

        while (true)
        {
            int indexOperation = Array.IndexOf(operations, Console.ReadLine());
            if (indexOperation == -1)
            {
                Console.WriteLine(message);
            }
            else
            {
                return operations[indexOperation];
            }
        }
    }

    static double GetResult(double x, double y, string operation)
    {
        double result = 0;
        switch (operation)
        {
            case "+":
                result = x + y;
                break;
            case "-":
                result = x - y;
                break;
            case "*":
                result = x * y;
                break;
            case "/":
                if (y == 0)
                {
                    throw new Exception("На 0 делить нельзя.");
                }
                result = x / y;
                break;
            case "max":
                result = GetMax(x, y);
                break;
            case "min":
                result = GetMin(x, y);
                break;
            default: throw new Exception("Операция не найдена");
        }
        return result;

    }

    static double GetMax(double a, double b)
    {
        double max = 0;
        if (a >= b)
        {
            max = a;
        }
        else
        {
            max = b;
        }
        return max;
    }

    static double GetMin(double a, double b)
    {
        double min;
        if (a <= b)
        {
            min = a;
        }
        else
        {
            min = b;
        }
        return min;
    }

}