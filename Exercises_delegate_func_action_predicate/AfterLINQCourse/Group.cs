namespace AfterLINQCourse
{
    partial class AfterLINQ
    {
        public class Group
        {
            public int GroupNumber { get; set; } 
            public string DepartmentName { get; set;}

            public Group (int GrNumber, string Depart)
            {
                this.GroupNumber = GrNumber;
                this.DepartmentName = Depart;
            }
        }
    }
}
