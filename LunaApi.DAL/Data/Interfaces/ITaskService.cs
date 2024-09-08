using LunaApi.Common.Enums;
using LunaApi.Common.Models;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetTasks(Guid userId, Status? status = null, DateTime? dueDate = null, Priority? priority = null);
        Task<TaskEntity> CreateTask(Guid userId, string title, string description, DateTime? dueDate, Status status, Priority priority);
        Task<TaskEntity?> GetTaskById(Guid userId,Guid taskId);
        Task<TaskEntity?> UpdateTask(Guid userId, Guid taskId, string title, string description, DateTime? dueDate, Status status, Priority priority);
        Task<bool> DeleteTask(Guid userId, Guid taskId);
    }
}
