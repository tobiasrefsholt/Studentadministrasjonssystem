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

    public int GetId()
    {
        return _id;
    }

    private void AddSubjectPrompt(SubjectList subjectList)
    {
        subjectList.Show(true);
        var selectedSubjectIndex = Helpers.AskForInt("Velg et fag, eller trykk enter for å avbryte: ", false, 0,
            subjectList.SubjectCount - 1);
        if (selectedSubjectIndex == null) return;

        var selectedSubject = subjectList.GetSubject((int)selectedSubjectIndex);
        if (selectedSubject == null) return;
        selectedSubject.ShowInfo();
        _subjects.Add(selectedSubject);
    }

    private void ShowSubjects(bool showIndex = false)
    {
        Console.Clear();
        Console.WriteLine("Fag: ");
        for (var index = 0; index < _subjects.Count; index++)
        {
            var subject = _subjects[index];
            if (showIndex)
            {
                subject.ShowInfo(index);
                continue;
            }

            subject.ShowInfo();
        }
        Console.WriteLine("Antall studiepoeng: " + GetTotalPoints());
    }

    private int GetTotalPoints()
    {
        var pointsArray = new int[_subjects.Count];
        for (int index = 0; index < _subjects.Count; index++)
        {
            var subject = _subjects[index];
            pointsArray[index] = subject.GetPoints();
        }
        return pointsArray.Sum();
    }

    private double GetAverageGrade()
    {
        var numbers = new int[_grades.Count];
        for (var index = 0; index < _grades.Count; index++)
        {
            var grade = _grades[index];
            var value = grade.GetValue();
            if (char.IsNumber(value))
            {
                numbers[index] = value - '0';
            }
            else
            {
                var gradeOffset = (value % 32) - 1;
                numbers[index] = 6 - gradeOffset;
            }
        }

        var sum = numbers.Sum();
        if (sum == 0) return 0;
        return (double)sum / numbers.Length;
    }

    private void ShowGrades(bool showIndex = false)
    {
        Console.Clear();
        Console.WriteLine("Karakterer: ");
        for (var index = 0; index < _grades.Count; index++)
        {
            var grade = _grades[index];
            if (showIndex)
            {
                grade.ShowInfo(index);
                continue;
            }

            grade.ShowInfo();
        }
        Console.WriteLine("\nGjennomsnitskarakter (konvertert til tall): " + GetAverageGrade());
    }

    private void AddGradePrompt()
    {
        Console.Clear();
        ShowSubjects(true);
        var selectedSubjectIndex = Helpers.AskForInt(
            "Velg et fag for å legge til en karakter: ",
            false, 0, _subjects.Count - 1
        );
        if (selectedSubjectIndex == null) return;
        var selectedSubject = _subjects[(int)selectedSubjectIndex];
        Console.Clear();
        Console.WriteLine("Legg til karakter for faget: ");
        selectedSubject.ShowInfo();
        var gradeInput = Helpers.AskForChar("Karakter: ");
        var grade = new Grade(this, selectedSubject, gradeInput);
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
                break;
            case 2:
                ShowGrades();
                break;
            case 3:
                AddSubjectPrompt(subjectList);
                break;
            case 4:
                AddGradePrompt();
                break;
            case 5:
                studentList.RemoveStudent(this);
                break;
            case 6:
                return;
        }

        Helpers.ContinuePrompt();
        ShowMenu(studentList, subjectList);
    }
}