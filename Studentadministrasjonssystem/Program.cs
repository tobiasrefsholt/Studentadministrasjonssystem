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
    Console.WriteLine("4. Add Student");
    Console.WriteLine("5. Add Subject");
    Console.WriteLine("6. Add Assessment");
    var input = Helpers.AskForInt("Skriv in et nummer: ", true, 1, 6);
    Console.Clear();
    switch (input)
    {
        case 1:
            data.ShowStudents();
            break;
        case 2:
            data.ShowSubjects();
            Helpers.ContinuePrompt();
            break;
        case 3:
            data.ShowAssessments();
            Helpers.ContinuePrompt();
            break;
        case 4:
            data.AddStudentPrompt();
            Helpers.ContinuePrompt();
            break;
        case 5:
            data.AddSubjectPrompt();
            Helpers.ContinuePrompt();
            break;
        case 6:
            data.AddAssessmentPrompt();
            Helpers.ContinuePrompt();
            break;
    }
}