// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Security;
using System.Xml.Linq;
using Studentadministrasjonssystem;

var data = new Data();
data.AddTestData();
ShowMenu();

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
            AddStudentPrompt();
            Helpers.ContinuePrompt();
            break;
        case "6":
            AddSubjectPrompt();
            Helpers.ContinuePrompt();
            break;
        case "7":
            AddAssessmentPrompt();
            Helpers.ContinuePrompt();
            break;
        default:
            Console.WriteLine("Ugyldig valg. Prøv igjen.");
            break;
            
    }
    ShowMenu();
}

void AddStudentPrompt()
{
    var name = Helpers.AskForString("Navn: ", true);
    var age = Helpers.AskForInt("Alder: ");
    var program = Helpers.AskForString("Studieprogram: ", true);
    var id = Helpers.AskForInt("StudentID: ");
    var student = new Student(name, age, program, id);
    student.ShowInfo();
    if (Helpers.AskForBool("Legg til student?")) 
        data.AddStudent(student);
}

void AddSubjectPrompt()
{
    var code = Helpers.AskForString("Fagkode: ", true);
    var name = Helpers.AskForString("Fagnavn: ", true);
    var points = Helpers.AskForInt("Studiepoeng: ");
    var subject = new Subject(code, name, points);
    subject.ShowInfo();
    if (Helpers.AskForBool("Legg til fag?")) 
        data.AddSubject(subject);
}

void AddAssessmentPrompt()
{
    throw new NotImplementedException();
}