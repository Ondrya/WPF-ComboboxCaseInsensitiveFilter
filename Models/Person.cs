namespace ComboboxCaseInsensitiveFilter.Models
{
    public class Person
    {
        public string Name { get; set; }
        public short Age { get; set; }

        public Person() { }
        public Person(string name, short age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
