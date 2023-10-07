// See https://aka.ms/new-console-template for more information
using Solid.App.OCPBad;

Console.WriteLine("Hello, World!");


SalaryCalculator salaryCalculator = new SalaryCalculator();
Console.WriteLine($"Low: {salaryCalculator.Calculate(1000, SalaryType.Low)}");
Console.WriteLine($"Medium: {salaryCalculator.Calculate(1000, SalaryType.Medium)}");
Console.WriteLine($"High: {salaryCalculator.Calculate(1000, SalaryType.High)}");