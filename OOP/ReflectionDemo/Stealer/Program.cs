using System;
public class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);

    }
}

