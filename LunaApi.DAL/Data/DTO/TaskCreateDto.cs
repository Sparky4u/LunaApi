using LunaApi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.DTO
{
    public class TaskCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }

}
