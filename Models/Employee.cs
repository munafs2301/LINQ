namespace LINQs.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmpEmail { get; set; }
        public int TeamCode { get; set; }
        public Employee(int id, string fullname, string empemail, int teamcode)
        {
            id = Id;
            fullname = FullName;
            empemail = EmpEmail;
            teamcode = TeamCode;
        }
    }
}
