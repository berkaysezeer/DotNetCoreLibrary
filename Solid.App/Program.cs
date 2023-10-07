// See https://aka.ms/new-console-template for more information
//using Solid.App.OCPBad;
//using Solid.App.OCPGood;

#region OCP
using Solid.App.OCPGood2;

//Kötü ocp örneği
//SalaryCalculator salaryCalculator = new SalaryCalculator();
//Console.WriteLine($"Low: {salaryCalculator.Calculate(1000, SalaryType.Low)}");
//Console.WriteLine($"Medium: {salaryCalculator.Calculate(1000, SalaryType.Medium)}");
//Console.WriteLine($"High: {salaryCalculator.Calculate(1000, SalaryType.High)}");

//iyi ocp örneği
//SalaryCalculator salaryCalculator = new SalaryCalculator();

//Console.WriteLine($"Low: {salaryCalculator.Calculate(1000, new LowSalaryCalculate())}");
//Console.WriteLine($"Medium: {salaryCalculator.Calculate(1000, new MediumSalaryCalculate())}");
//Console.WriteLine($"High: {salaryCalculator.Calculate(1000, new HighSalaryCalculate())}");


//iyi ocp örneği-2
SalaryCalculator salaryCalculator = new SalaryCalculator();

Console.WriteLine($"Low: {salaryCalculator.Calculate(1000, new LowSalaryCalculate().Calculate)}");
Console.WriteLine($"Medium: {salaryCalculator.Calculate(1000, new MediumSalaryCalculate().Calculate)}");
Console.WriteLine($"High: {salaryCalculator.Calculate(1000, new HighSalaryCalculate().Calculate)}");

//delegate olunca isimsiz metod kullanabiliyoruz
Console.WriteLine($"Custom: {salaryCalculator.Calculate(1000, x =>
{
    return x * 5;
})}");


#endregion
