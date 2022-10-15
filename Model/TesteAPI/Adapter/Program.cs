// See https://aka.ms/new-console-template for more information

using Adapter;

Adapter.Adapter adapter = new Adapter.Adapter(new Adaptee());

var xx = adapter.GetName();
var xxx = adapter.GetName(xx);

Console.WriteLine("Hello, World!");
