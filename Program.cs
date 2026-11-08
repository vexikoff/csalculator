using System.Linq;
using System.Text;

class Calculator
{
    public int EnteredCount => stat.Count;
    private List<int> stat = new List<int>();
    
    public int Multiplication(int one, int two)
    {
        
        return one * two;
    }
    
    public int Addition(int one, int two)
    {
        return one + two;
    }
    
    public void Stat()
    {
        if (stat.Count == 0)
        {
            Console.WriteLine("Пока нет вычислений!");
            return;
        }
        Console.WriteLine("Статистика:");
        Console.WriteLine($"Введено чисел: {EnteredCount}");
        Console.WriteLine($"Сумма всех число: {stat.Sum()}");
        Console.WriteLine($"Максимальное число: {stat.Max()}");
        Console.WriteLine($"Среднее число: {stat.Average()}");
    }
    
    public (int one, int two) ReadTwoIntegers()
    {
        Console.Write("Введи первое число: ");
        int one;
        while (!int.TryParse(Console.ReadLine(), out one))
        {
            Console.Write("Это не число. Заново: ");
        }

        Console.Write("Введи второе число: ");
        int two;
        while (!int.TryParse(Console.ReadLine(), out two))
        {
            Console.Write("Это не число. Заново: ");
        }

        stat.Add(one);
        stat.Add(two);
        return (one, two);
    }
    
    public virtual string Describe()
    {
        return $"{name}, родитель";
    }
    
    // Конструктор
    
    protected string name;

    public Calculator(string calculatorName)
    {
        name = calculatorName;
    }
}

class ScientificCalculator : Calculator
{
    private List<int> stat = new List<int>();
    public int ReadInteger()
    {
        Console.Write("Введи число: ");
        int one;
        while (!int.TryParse(Console.ReadLine(), out one))
        {
            Console.Write("Это не число. Заново: ");
        }
        stat.Add(one);
        return one;
    }
    public double Sqrt()
    {
        double x = ReadInteger();
        return Math.Sqrt(x);
    }
    public ScientificCalculator(string ScientificCalculatorName) : base(ScientificCalculatorName)
    {
        name = ScientificCalculatorName;
    }
    
    public override string Describe()
    {
        return $"{name}, ребенок";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        ScientificCalculator sci = new ScientificCalculator("Scientific");
        Calculator calc = new Calculator("Default");
        List<Calculator> all = new List<Calculator>();
        all.Add(calc);
        all.Add(sci);
        foreach (Calculator c in all)
        {
            Console.WriteLine(c.Describe());
        }
        while (true)
        {
            Console.WriteLine("Команда \n1 - сумма\n2 - умножение\n3 - статистика\n4 - Корень\n5 - выход");
            string? command = Console.ReadLine();
            switch (command)
            {
                case "1":
                {
                    (int one, int two) = calc.ReadTwoIntegers();
                    Console.WriteLine($"{calc.Addition(one, two)}");
                    break;
                }
                case "2":
                {
                    (int one, int two) = calc.ReadTwoIntegers();
                    Console.WriteLine($"{calc.Multiplication(one, two)}");
                    break;
                }
                case "3":
                {
                    calc.Stat();
                    break;
                } 
                case "4":
                {
                    Console.WriteLine(sci.Sqrt());
                    break;
                } 
                case "5":
                {
                    Console.WriteLine("Пока!");
                    Environment.Exit(0);
                    break;
                } 
                default:
                    Console.WriteLine("Введи число от 1 до 5!");
                    break;
            }
        }
    }
}