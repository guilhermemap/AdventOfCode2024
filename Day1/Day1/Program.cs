const string filename = "input";

var lines = File.ReadAllLines(filename);

int size = lines.Length;
int[] arrayA = new int[size];
int[] arrayB = new int[size];
int totalDistance = 0;
int index = 0;
foreach (var line in lines)
{
    (int a, int b) = ParseInput(line);
    arrayA[index] = a;
    arrayB[index] = b;
    index++;
}

arrayA = arrayA.OrderBy(a => a).ToArray();
arrayB = arrayB.OrderBy(b => b).ToArray();

for (int i = 0; i < size; i++)
{
    totalDistance += Math.Abs(arrayA[i] - arrayB[i]);
}

Console.WriteLine(totalDistance);

(int, int) ParseInput(string input)
{
    var splitted = input.Split([' '], StringSplitOptions.RemoveEmptyEntries);
    var numbers = splitted.Select(int.Parse).ToArray();
    if (numbers.Length != 2) throw new FormatException($"input {input} is invalid");
    return (numbers[0], numbers[1]);
}