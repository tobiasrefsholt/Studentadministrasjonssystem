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

    private void AddSubjectPrompt(SubjectList subjectList)
    {
        subjectList.Show(true);
        var selectedSubjectIndex = Helpers.AskForInt("Velg et fag, eller trykk enter for å avbryte: ", false, 0,
            subjectList.SubjectCount-1);
        if (selectedSubjectIndex == null) return;
        
        var selectedSubject = subjectList.GetSubject((int)selectedSubjectIndex);
        if (selectedSubject == null) return;
        selectedSubject.ShowInfo();
        _subjects.Add(selectedSubject);
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

    private void ShowSubjects()
    {
        Console.Clear();
        Console.WriteLine("Fag: ");
        foreach (var subject in _subjects)
        {
            subject.ShowInfo();
        }
    }
    
    private void ShowGrades()
    {
        Console.Clear();
        Console.WriteLine("Karakterer: ");
        foreach (var grade in _grades)
        {
            grade.ShowInfo();
        }
    }
    
    private void AddGradePrompt(int? studentId = null)
    {
        Console.Clear();
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

    public void ShowMenu(StudentList studentList, SubjectList subjectList)
    {
        Console.Clear();
        Console.WriteLine($"Velg hva du vil gjøre med {_name}.");
        Console.WriteLine("(1) Vis fag som studenten tar");
        Console.WriteLine("(2) Vis karakterer");
        Console.WriteLine("(3) Legg til fag");
        Console.WriteLine("(4) Registrer ny karakter");
        Console.WriteLine("(5) Slett");
        Console.WriteLine("(6) Tilbake til hovedmeny");
        var option = Helpers.AskForInt("Skriv inn et tall: ", true, 1, 6);
        switch (option)
        {
            case 1:
                ShowSubjects();
                Helpers.ContinuePrompt();
                ShowMenu(studentList, subjectList);
                break;
            case 2:
                ShowGrades();
                Helpers.ContinuePrompt();
                ShowMenu(studentList, subjectList);
                break;
            case 3:
                AddSubjectPrompt(subjectList);
                ShowMenu(studentList, subjectList);
                break;
            case 4:
                AddGradePrompt();
                Helpers.ContinuePrompt();
                ShowMenu(studentList, subjectList);
                break;
            case 5:
                studentList.RemoveStudent(this);
                Helpers.ContinuePrompt();
                ShowMenu(studentList, subjectList);
                break;
            case 6:
                break;
        }
    }
}