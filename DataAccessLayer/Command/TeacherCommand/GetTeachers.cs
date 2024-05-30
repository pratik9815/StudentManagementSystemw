namespace DataAccessLayer.Command.TeacherCommand
{
    public class GetTeachers
    {
        public int Teacher_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Email { get; set; }
    }
    public class GetTeacher
    {
        public int Teacher_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Email { get; set; }
        public int Department_Id { get; set; }
    }
}
