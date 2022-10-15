// See https://aka.ms/new-console-template for more information

int number = 420;

unsafe
{
    var ptr = stackalloc int[1];
    int* pointer = &number;
}

var app = new Application();
DateStruct dateStruct = new DateStruct() { Day = 2, Month = 2, Year = 2};

Console.WriteLine(number);

public class Application
{
    private int number = 66;
}

public struct DateStruct
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}
