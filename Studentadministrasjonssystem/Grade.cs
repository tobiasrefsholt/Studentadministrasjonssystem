namespace Studentadministrasjonssystem;

public class Grade
{
    private Student _student;
    private Subject _subject;
    private char _grade;

    public Grade(Student student, Subject subject, char grade)
    {
        _student = student;
        _subject = subject;
        _grade = grade;
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"Student ID: {_student.GetId()}, Kode: {_subject.GetCode()}, Karakter: {_grade}");
    }

    public void ShowInfo(int index)
    {
        Console.WriteLine($"{index}Student ID: {_student.GetId()}, Kode: {_subject.GetCode()}, Karakter: {_grade}");
    }
}