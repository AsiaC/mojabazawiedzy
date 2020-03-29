namespace _1_Listy
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname  { get; set; }
        public int AlbumNumber { get; set; }
        public int MyProperty { get; set; }
        public string Phone { get; set; }
        public Student()
        {

        }
        public Student(string Name, string Surname, int AlbumNumber, string Phone)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.AlbumNumber = AlbumNumber;
            this.Phone = Phone;
        }
    }
}