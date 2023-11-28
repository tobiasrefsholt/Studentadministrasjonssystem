namespace Studentadministrasjonssystem;

public class StudentList
{
    public List<Student> Students = new List<Student>() { };

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }
    
    public void Show()
    {
        Console.WriteLine("Studenter: ");
        for (var index = 0; index < Students.Count; index++)
        {
            var student = Students[index];
            student.ShowInfo(index);
        }

        var selectedIndex = Helpers.AskForInt("Velg student, eller trykk enter for å fortsette: ", false, 0,
            Students.Count - 1);
        if (selectedIndex == null) return;
        var selectedStudent = Students[(int)selectedIndex];
        selectedStudent.ShowMenu(this);
    }
    
    public void AddPrompt()
    {
        var name = Helpers.AskForString("Navn: ", true);
        var age = (int)Helpers.AskForInt("Alder: ", true)!;
        var program = Helpers.AskForString("Studieprogram: ", true);
        var id = (int)Helpers.AskForInt("StudentID: ", true)!;
        var student = new Student(name, age, program, id);
        student.ShowInfo();
        if (Helpers.AskForBool("Legg til student?"))
            AddStudent(student);
    }
}