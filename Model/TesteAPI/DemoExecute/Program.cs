// See https://aka.ms/new-console-template for more information

using Services.GenericDelegates;

var Generates = new Generate();
var g = new Services.Order { Id = 2, Name = "Bag" };
var g3 = new Services.Order { Id = 3, Name = "Bag3" };
Generates.Add(g);
Generates.Add(g3);
var order = Generates.GetById(2);
Console.WriteLine($"{order.Id} {order.Name}");
Console.WriteLine("All order:::::::");
Generates.Get().ToList().ForEach(x => Console.WriteLine($"{x.Id} {x.Name}"));


//Console.WriteLine(Demo003.Get(new() { Name = "" }));

//Demo003.DateValues();
//POO p = new();
//p._Name = "Laura";
//p._Description = "Vaz";
//var value = 5;
//Console.WriteLine(Add(value));
//var valueRef = value;
//Console.WriteLine(AddRed(ref value));
//Console.WriteLine(AddOut(out value, 2));
//Console.WriteLine(p.Get(p));
//100 --0
// 20 -180

static int Add(int value)
{
    int a = 2;
    a += value;
    return a;
}
static int AddRed(ref int value)
{
    int a = 6;
    value = a;
    return value;
}
static int AddOut(out int value, int a)
{
    int inter = a;
    value = inter;

    return value;
}

var MaxValue = DateOnly.MaxValue;
var UtcNow = DateTime.UtcNow;
var Local = (int)DateTimeKind.Local;
var Now = DateTimeOffset.Now;
var UnixEpoch = DateTime.UnixEpoch;
//"C:\\D"
//@"\D"
//Console.WriteLine("Document\n valude this\tchange");

//Console.WriteLine($"{MaxValue} - {UtcNow} - {Local} - {Now} - {UnixEpoch}");
