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
    
    public void ShowInfo(int index)
    {
        Console.WriteLine($"({index}) Navn: {_name}, Alder: {_age}, Studieprogram: {_program}, Id: {_id}");
    }

    public void ShowMenu(Data data)
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
                data.AddAssessmentPrompt(_id);
                break;
            case 2:
                data.ShowAssessments(_id);
                break;
            case 3:
                data.RemoveStudent(this);
                break;
        }
        Helpers.ContinuePrompt();
    }
}