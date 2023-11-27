namespace Studentadministrasjonssystem;

public class Assessment
{
    public int StudentId { get; private set; }
    private string _subjectCode;
    private char _grade;

    public Assessment(int studentId, string subjectCode, char grade)
    {
        StudentId = studentId;
        _subjectCode = subjectCode;
        _grade = grade;
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"Student ID: {StudentId}, Kode: {_subjectCode}, Karakter: {_grade}");
    }
}