namespace Studentadministrasjonssystem;

public class Grade
{
    private int _studentId;
    private string _subjectCode;
    private char _grade;

    public Grade(int studentId, string subjectCode, char grade)
    {
        _studentId = studentId;
        _subjectCode = subjectCode;
        _grade = grade;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Student ID: {_studentId}, Kode: {_subjectCode}, Karakter: {_grade}");
    }
}