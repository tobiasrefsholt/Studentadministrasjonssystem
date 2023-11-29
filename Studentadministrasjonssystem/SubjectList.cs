namespace Studentadministrasjonssystem;

public class SubjectList
{
    private List<Subject> _subjects = new();
    public int SubjectCount => _subjects.Count();

    public void AddData()
    {
        _subjects.Add(new Subject("ITEVU4330", "Robusthet i store og komplekse software systemer", 10));
        _subjects.Add(new Subject("ITLED4340", "Utvikling og vedlikehold av komplekse softwaresystemer ", 10));
        _subjects.Add(new Subject("ITEVU4261", "IT-arkitektur", 10));
        _subjects.Add(new Subject("ITLED4350", "Moderne systemutviklingsprosesser", 10));
        _subjects.Add(new Subject("ITEVU4360", "IT-arkitektur og Digital innovasjon", 10));
        _subjects.Add(new Subject("ITLED4390", "IT-arkitektur prosjektoppgave", 10));
        _subjects.Add(new Subject("STK-IN4300", "Statistiske læringsmetoder i Data Science", 10));
        _subjects.Add(new Subject("IN-STK5000", "Adaptive metoder for data-baserte beslutninger", 10));
        _subjects.Add(new Subject("IN4020", "Databasesystemer", 10));
        _subjects.Add(new Subject("STK4021", "Anvendt Bayesiansk analyse", 10));
        _subjects.Add(new Subject("STK4051", "Numeriske metoder for statistikk", 10));
        _subjects.Add(new Subject("IN4070", "Logikk", 10));
    }

    public void Show(bool showIndex = false)
    {
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
    }
    
    public void AddPrompt()
    {
        var code = Helpers.AskForString("Fagkode: ", true);
        var name = Helpers.AskForString("Fagnavn: ", true);
        var points = (int)Helpers.AskForInt("Studiepoeng: ", true)!;
        var subject = new Subject(code, name, points);
        subject.ShowInfo();
        if (Helpers.AskForBool("Legg til fag?"))
            _subjects.Add(subject);
    }
    
    public Subject? GetSubject(int selectedSubjectIndex)
    {
        if (selectedSubjectIndex >= _subjects.Count || selectedSubjectIndex < 0) return null;
        return _subjects[selectedSubjectIndex];
    }
}