// See https://aka.ms/new-console-template for more information
using Builder.BuilderPattern;

var emp = EmployeeBuilderDirector
           .employeeBuilder.SetName("")
           .AtPosition("")
           .WithSalary(23).Build();

var products = new List<Product>
            {
                new Product { Name = "Monitor", Price = 200.50 , Id = 1
                },
                new Product { Name = "Mouse", Price = 20.41 , Id = 2},
                new Product { Name = "Keyboard", Price = 30.15, Id = 3}
            };

var builder = new ProductStockReportBuilder(products);
var director = new ProductStockReportDirector(builder);
director.BuildStockReport();


//var report = builder.Get();


var list = builder.GetAll();
var xx = builder.Retrieve(2);

Console.WriteLine("One object:::::::::");
Console.WriteLine(builder.Show(xx));

Console.WriteLine("All object::::::::");
list.ToList().ForEach(x => Console.WriteLine(builder.Show(x)));
//Console.WriteLine(report.Header + "-" + report.Footer + "-" + report.Body);