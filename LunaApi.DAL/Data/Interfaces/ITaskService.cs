using LunaApi.Common.Models;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetUserTasks(Guid userId);
        Task<TaskEntity> CreateTask(Guid userId, TaskEntity task);
        Task<TaskEntity> UpdateTask(Guid userId, TaskEntity updatedTask);
        Task DeleteTask(Guid userId, Guid taskId);
    }
}
