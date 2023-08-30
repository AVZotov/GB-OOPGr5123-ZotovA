// See https://aka.ms/new-console-template for more information
using VenidngMachine.Services;

Console.WriteLine("Hello, World!");

VendingMachine vendingMachine= new VendingMachine(123, "Mosscow");
vendingMachine.Start();
