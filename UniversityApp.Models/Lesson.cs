using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public int CabinetId { get; set; }
        public int TeacherId { get; set; }
        public int PlanId { get; set; }
    }
}
