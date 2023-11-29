// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Security;
using System.Xml.Linq;
using Studentadministrasjonssystem;

var studentList = new StudentList();
var subjectList = new SubjectList();

while (true) ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("1. Vis studenter");
    Console.WriteLine("2. Vis alle fag");
    Console.WriteLine("3. Legg til student");
    Console.WriteLine("4. Legg til fag");
    Console.WriteLine("5. Legg til testdata");
    var input = Helpers.AskForInt("Skriv in et nummer: ", true, 1, 5);
    Console.Clear();
    switch (input)
    {
        case 1:
            studentList.Show(subjectList);
            break;
        case 2:
            subjectList.Show();
            Helpers.ContinuePrompt();
            break;
        case 3:
            studentList.AddPrompt();
            Helpers.ContinuePrompt();
            break;
        case 4:
            subjectList.AddPrompt();
            Helpers.ContinuePrompt();
            break;
        case 5:
            AddDemoData();
            break;
    }
}

void AddDemoData()
{
    studentList.AddStudent(new Student("Torgeir Granskau", 18, "IT-arkitektur", 1469));
    studentList.AddStudent(new Student("Geir Mykvare", 21, "Data Science", 1235));
    subjectList.AddData();
}