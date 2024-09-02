using LunaApi.Common.Models;
using LunaApi.DAL.Data;
using LunaApi.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunaApi.DAL.Services
{
    public class TaskService : ITaskService
    {
        private readonly LunaDbContext _context;

        public TaskService(LunaDbContext context)
        {
            _context = context;
        }

        public async Task<TaskEntity> CreateTask(Guid userId, TaskEntity taskEntity)
        {
            taskEntity.UserId = userId;
            _context.TaskEntity.Add(taskEntity);
            await _context.SaveChangesAsync();
            return taskEntity;
        }

        public async Task DeleteTask(Guid userId, Guid taskId)
        {
            var taskEntity = await _context.TaskEntity.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);

            if (taskEntity == null) throw new UnauthorizedAccessException("You can only delete your own tasks.");

            _context.TaskEntity.Remove(taskEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetUserTasks(Guid userId)
        {
            return await _context.TaskEntity.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<TaskEntity> UpdateTask(Guid userId, TaskEntity updatedTask)
        {
            var taskEntity = await _context.TaskEntity.FirstOrDefaultAsync(t => t.Id == updatedTask.Id && t.UserId == userId);

            if (taskEntity == null) throw new UnauthorizedAccessException("You can only uptated your own task");

            taskEntity.Title = updatedTask.Title;
            taskEntity.Description = updatedTask.Description;
            taskEntity.DueDate = updatedTask.DueDate;
            taskEntity.Status = updatedTask.Status;
            taskEntity.Priority = updatedTask.Priority;
            taskEntity.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return taskEntity;
        }
    }
}
