using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Gavin Nelson", "Algebra");
        string summary = assignment1.GetSummary();
        Console.WriteLine(summary);
        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment("Eve Nelson", "Trigonometry", "8.2", "1-12");
        string mathHomework = $"{assignment2.GetSummary()}\n{assignment2.GetHomeworkList()}";
        Console.WriteLine(mathHomework);
        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Graydon Lea", "Chinese History", "The Shang Dynasty");
        string writingEssay = $"{assignment3.GetSummary()}\n{assignment3.GetWritingInformation()}";
        Console.WriteLine(writingEssay);
    }
}