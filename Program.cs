int a = 10, b = 3;
Console.WriteLine(a + b); // Output: 13
Console.WriteLine(a % b); // Output: 1


// Key Components of LINQ


// 1 Query Syntax

int[] numbers = { 1, 2, 3, 4, 5 };
var evenNumbers = from num in numbers
                  where num % 2 == 0
                  select num;

foreach (var num in evenNumbers)
{
	Console.WriteLine(num); // Output: 2, 4
}

// 2 Method Syntax

int[] nums = { 1, 2, 3, 4, 5 };
var evenNum = numbers.Where(num => num % 2 == 0);

foreach (var num in evenNum)
{
    Console.WriteLine(num); // Output: 2, 4
}