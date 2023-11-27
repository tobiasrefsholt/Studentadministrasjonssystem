// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Security;
using System.Xml.Linq;
using Studentadministrasjonssystem;

var data = new Data();
data.AddTestData();

while (true) ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("1. Show students");
    Console.WriteLine("2. Show subjects");
    Console.WriteLine("3. Show assessments");
    Console.WriteLine("4. Show all");
    Console.WriteLine("5. Add Student");
    Console.WriteLine("6. Add Subject");
    Console.WriteLine("7. Add Assessment");
    var input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "1":
            data.ShowStudents();
            Helpers.ContinuePrompt();
            break;
        case "2":
            data.ShowSubjects();
            Helpers.ContinuePrompt();
            break;
        case "3":
            data.ShowAssessments();
            Helpers.ContinuePrompt();
            break;
        case "4":
            data.ShowAll();
            Helpers.ContinuePrompt();
            break;
        case "5":
            data.AddStudentPrompt();
            Helpers.ContinuePrompt();
            break;
        case "6":
            data.AddSubjectPrompt();
            Helpers.ContinuePrompt();
            break;
        case "7":
            data.AddAssessmentPrompt();
            Helpers.ContinuePrompt();
            break;
        default:
            Console.WriteLine("Ugyldig valg. Prøv igjen.");
            break;
    }
}