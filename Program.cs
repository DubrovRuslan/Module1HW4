using System.ComponentModel.DataAnnotations;

var toUpperChars = new char[] { 'a', 'e', 'i', 'd', 'h', 'j' };
var arrSize = GetArraySize(100);
var arr = GenerateArray(arrSize, 1, 26);
var intArrayA = new int[arrSize];
var intArrayB = new int[arrSize];

var a = 0;
var b = 0;
for (var i = 0; i < arr.Length; i++)
{
    if (arr[i] % 2 == 0)
    {
        intArrayA[a++] = arr[i];
    }
    else
    {
        intArrayB[b++] = arr[i];
    }
}

Array.Resize(ref intArrayA, a);
Array.Resize(ref intArrayB, b);

Console.WriteLine("original array of digits:");
PrintIntArray(arr);
Console.WriteLine("first array of digits:");
PrintIntArray(intArrayA);
Console.WriteLine("second array of digits:");
PrintIntArray(intArrayB);

var charArrayA = new char[intArrayA.Length];
var charArrayB = new char[intArrayB.Length];

ChangeToLetters(charArrayA, intArrayA, toUpperChars);
ChangeToLetters(charArrayB, intArrayB, toUpperChars);

Console.WriteLine("first array of letters:");
PrintCharArray(charArrayA);
Console.WriteLine("second array of letters:");
PrintCharArray(charArrayB);

var capitalLettersCoutA = 0;
var capitalLettersCoutB = 0;
for (var i = 0; i < charArrayA.Length; i++)
{
    if (char.IsUpper(charArrayA[i]))
    {
        capitalLettersCoutA++;
    }
}

for (var i = 0; i < charArrayB.Length; i++)
{
    if (char.IsUpper(charArrayB[i]))
    {
        capitalLettersCoutB++;
    }
}

if (capitalLettersCoutA > capitalLettersCoutB)
{
    Console.WriteLine($"There are more capital letters in the first array ({capitalLettersCoutA} vs {capitalLettersCoutB})");
}
else if (capitalLettersCoutA < capitalLettersCoutB)
{
    Console.WriteLine($"There are more capital letters in the second array ({capitalLettersCoutB} vs {capitalLettersCoutA})");
}
else
{
    Console.WriteLine("the number of capital letters is the same");
}

void ChangeToLetters(char[] charArray, int[] intArrray, char[] toUpperChars)
{
    for (var i = 0; i < intArrray.Length; i++)
    {
        charArray[i] = Convert.ToChar(intArrray[i] + 96);
        foreach (var item in toUpperChars)
        {
            if (charArray[i] == item)
            {
                charArray[i] = char.ToUpper(charArray[i]);
            }
        }
    }
}

int GetArraySize(int maxArrSize, int minArrSize = 1)
{
    var size = 0;
    Console.WriteLine($"Enter array size ({minArrSize} - {maxArrSize}): ");
    var flag = false;
    do
    {
        flag = int.TryParse(Console.ReadLine(), out size);
        if (flag)
        {
            if (size < minArrSize || size > maxArrSize)
            {
                flag = false;
            }
        }

        if (!flag)
        {
            Console.WriteLine("Wrong range!");
        }
    }
    while (!flag);
    return size;
}

int[] GenerateArray(int arrSize, int minArrValue, int maxArrValue)
{
    var arr = new int[arrSize];
    for (var i = 0; i < arr.Length; i++)
    {
        arr[i] = new Random().Next(minArrValue, maxArrValue + 1);
    }

    return arr;
}

void PrintIntArray(int[] arr)
{
    for (var i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);
        Console.Write(" ");
    }

    Console.WriteLine();
}

void PrintCharArray(char[] arr)
{
    for (var i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);
        Console.Write(" ");
    }

    Console.WriteLine();
}