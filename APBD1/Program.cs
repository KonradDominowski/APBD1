// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using APBD1.Equipment;
using OperatingSystem = APBD1.Equipment.OperatingSystem;

var laptop = new Laptop("lap", 17, 10000, OperatingSystem.Linux);
var laptop1 = new Laptop("lap", 17, 10000, OperatingSystem.Linux);

Console.WriteLine(laptop.Id);
Console.WriteLine(laptop1.Id);

var date = DateTime.Now;
var date2 = DateTime.Now.AddDays(5);

Console.WriteLine(date.Day);
