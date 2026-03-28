// See https://aka.ms/new-console-template for more information

using APBD1.Equipment;
using APBD1.User;
using APBD1.Service;
using OperatingSystem = APBD1.Equipment.OperatingSystem;

var laptop = new Laptop("Laptop", 17, 10000, OperatingSystem.Linux);
var laptop1 = new Laptop("Laptop 2", 17, 10000, OperatingSystem.Linux);

laptop1.State = EquipmentState.Rented;

var date = DateTime.Now;
var date2 = DateTime.Now.AddDays(5);

var user1 = new Student("Konrad", "Dominowski");
var user2 = new Employee("Andrzej", "Kowalski");
var user3 = new Employee("Andrzej", "Kowalski");

Console.WriteLine("Witaj w systemie zarządzania wypożyczalnią.");

Service.ShowMenu();
