namespace Studentadministrasjonssystem;

public class Student
{
    private readonly string _name;
    private readonly int _age;
    private readonly string _program;
    private readonly int _id;

    private List<Subject> _subjects = new List<Subject>();
    private List<Grade> _grades = new List<Grade>();

    public Student(string name, int age, string program, int id)
    {
        _name = name;
        _age = age;
        _program = program;
        _id = id;
    }

    public void AddSubject(Subject subject)
    {
        _subjects.Add(subject);
    }

    public void RemoveSubject(Subject subject)
    {
        _subjects.Remove(subject);
    }

    public void AddAssessment(Grade grade)
    {
        _grades.Add(grade);
    }

    public void RemoveAssessment(Grade grade)
    {
        _grades.Remove(grade);
    }
    
    public void ShowGrades()
    {
        Console.WriteLine("Fag: ");
        foreach (var grade in _grades)
        {
            grade.ShowInfo();
        }
    }
    
    public void AddGradePrompt(int? studentId = null)
    {
        studentId ??= (int)Helpers.AskForInt("StudentID: ", true)!;
        var subjectCode = Helpers.AskForString("Fagkode: ", true);
        var gradeInput = Helpers.AskForChar("Karakter: ");
        var grade = new Grade((int)studentId, subjectCode, gradeInput);
        grade.ShowInfo();
        if (Helpers.AskForBool("Legg til karakter?"))
            _grades.Add(grade);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Navn: {_name}, Alder: {_age}, Studieprogram: {_program}, Id: {_id}");
    }

    public void ShowInfo(int index)
    {
        Console.WriteLine($"({index}) Navn: {_name}, Alder: {_age}, Studieprogram: {_program}, Id: {_id}");
    }

    public void ShowMenu(StudentList studentList)
    {
        Console.Clear();
        Console.WriteLine($"Velg hva du vil gjøre med {_name}.");
        Console.WriteLine("(1) Registrer ny karakter");
        Console.WriteLine("(2) Vis karakterer");
        Console.WriteLine("(3) Slett");
        var option = Helpers.AskForInt("Skriv inn et tall: ", true, 1, 3);
        switch (option)
        {
            case 1:
                AddGradePrompt();
                break;
            case 2:
                ShowGrades();
                break;
            case 3:
                studentList.RemoveStudent(this);
                break;
        }

        Helpers.ContinuePrompt();
    }
}