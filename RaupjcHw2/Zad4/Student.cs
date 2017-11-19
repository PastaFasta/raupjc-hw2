namespace Zad4
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            return Jmbag == (obj as Student)?.Jmbag;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (!firstStudent.Equals(null) && !firstStudent.Equals(secondStudent))
                return true;
            return false;
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (!firstStudent.Equals(null) && firstStudent.Equals(secondStudent))
                return true;
            return false;
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
