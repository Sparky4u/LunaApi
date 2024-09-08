using LunaApi.Common.Enums;
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

        public async Task<TaskEntity> CreateTask(Guid userId, string title, string description, DateTime? dueDate, Status status, Priority priority)
        {
            var task = new TaskEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = status,
                Priority = priority,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            _context.TaskEntity.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(Guid userId, Guid taskId)
        {
            var task = await _context.TaskEntity.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);

            if (task == null)
            {
                return false;
            }

            _context.TaskEntity.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TaskEntity?> GetTaskById(Guid userId, Guid taskId)
        {
            return await _context.TaskEntity
                .FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
        }

        public async Task<List<TaskEntity>> GetTasks(Guid userId, Status? status = null, DateTime? dueDate = null, Priority? priority = null)
        {
            var query = _context.TaskEntity
                .Where(t => t.UserId == userId)
                .AsQueryable();

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }

            if (dueDate.HasValue)
            {
                query = query.Where(t => t.DueDate == dueDate.Value);
            }
            if (priority.HasValue)
            {
                query = query.Where(t => t.Priority == priority.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<TaskEntity?> UpdateTask(Guid userId, Guid taskId, string title, string description, DateTime? dueDate, Status status, Priority priority)
        {
            var task = await _context.TaskEntity.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);

            if (task == null)
            {
                return null;
            }

            task.Title = title;
            task.Description = description;
            task.DueDate = dueDate;
            task.DueDate = dueDate;
            task.Status = status;
            task.Priority = priority;
            task.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return task;
        }
    }
}
