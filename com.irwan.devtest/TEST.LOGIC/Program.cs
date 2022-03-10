// See https://aka.ms/new-console-template for more information


int i, j, k, inputNumber;

Console.Write("Enter number : ");
inputNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("===========================================================");

for (i = inputNumber; i >= 1; i--)
{
    for (j = 1; j < i; j++)
    {
        Console.Write(" ");
    }
    for (k = inputNumber; k >= i; k--)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
