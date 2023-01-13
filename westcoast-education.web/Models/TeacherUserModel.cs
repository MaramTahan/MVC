

using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.Models;

    public class TeacherUserModel
    {
        [Key]
        public int userId{ get; set; }
        public string userName { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string coursesTaught { get; set; } = "";
        public string phoneNumber { get; set; } = "";
        public string address { get; set; } = "";
    }
