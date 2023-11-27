namespace Studentadministrasjonssystem;

public class Student
{
    private readonly string _name;
    private readonly int _age;
    private readonly string _program;
    private readonly int _id;

    public Student(string name, int age, string program, int id)
    {
        _name = name;
        _age = age;
        _program = program;
        _id = id;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Navn: {_name}, Alder: {_age}, Studieprogram: {_program}, Id: {_id}");
    }
}