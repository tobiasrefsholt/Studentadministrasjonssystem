namespace Studentadministrasjonssystem;

public class Subject
{
    private string _code;
    private string _name;
    private int _points;

    public Subject(string code, string name, int points)
    {
        _code = code;
        _name = name;
        _points = points;
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"Kode {_code}, Fag: {_name}, Studiepoeng: {_points}");
    }
    
    public void ShowInfo(int index)
    {
        Console.WriteLine($"({index}) Kode {_code}, Fag: {_name}, Studiepoeng: {_points}");
    }
}