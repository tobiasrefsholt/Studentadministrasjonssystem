namespace Studentadministrasjonssystem;

public class Data
{
    public List<Student> Students = new List<Student>() { };
    public List<Subject> Subjects = new List<Subject>();
    public List<Assessment> Assessments = new List<Assessment>();

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void AddSubject(Subject subject)
    {
        Subjects.Add(subject);
    }

    public void AddAssessment(Assessment assessment)
    {
        Assessments.Add(assessment);
    }
    
    public void AddTestData()
    {
        AddStudent(new Student("Torgeir Granskau", 18, "IT-arkitektur", 1469));
        AddStudent(new Student("Geir Mykvare", 21, "Data Science", 1235));

        AddSubject(new Subject("ITEVU4330", "Robusthet i store og komplekse software systemer", 10));
        AddSubject(new Subject("ITLED4340", "Utvikling og vedlikehold av komplekse softwaresystemer ", 10));
        AddSubject(new Subject("ITEVU4261", "IT-arkitektur", 10));
        AddSubject(new Subject("ITLED4350", "Moderne systemutviklingsprosesser", 10));
        AddSubject(new Subject("ITEVU4360", "IT-arkitektur og Digital innovasjon", 10));
        AddSubject(new Subject("ITLED4390", "IT-arkitektur prosjektoppgave", 10));

        AddSubject(new Subject("STK-IN4300", "Statistiske læringsmetoder i Data Science", 10));
        AddSubject(new Subject("IN-STK5000", "Adaptive metoder for data-baserte beslutninger", 10));
        AddSubject(new Subject("IN4020", "Databasesystemer", 10));
        AddSubject(new Subject("STK4021", "Anvendt Bayesiansk analyse", 10));
        AddSubject(new Subject("STK4051", "Numeriske metoder for statistikk", 10));
        AddSubject(new Subject("IN4070", "Logikk", 10));

        AddAssessment(new Assessment(1469, "ITEVU4330", 'B'));
        AddAssessment(new Assessment(1235, "ITEVU4330", 'F'));
    }
    
    public void ShowAll()
    {
        ShowStudents();
        Console.WriteLine();
        ShowSubjects();
        Console.WriteLine();
        ShowAssessments();
    }

    public void ShowAssessments()
    {
        Console.WriteLine("Karakterer: ");
        foreach (var assessment in Assessments)
        {
            assessment.ShowInfo();
        }
    }

    public void ShowSubjects()
    {
        Console.WriteLine("Fag: ");
        foreach (var subject in Subjects)
        {
            subject.ShowInfo();
        }
    }

    public void ShowStudents()
    {
        Console.WriteLine("Studenter: ");
        foreach (var student in Students)
        {
            student.ShowInfo();
        }
    }
}