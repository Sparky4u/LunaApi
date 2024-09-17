using LunaApi.Common.Enums;

namespace LunaApi.DAL.Data.DTO
{
    public class TaskUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}
