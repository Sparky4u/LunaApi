using LunaApi.Common.Enums;
using LunaApi.Common.Models;
using LunaApi.DAL.Data;
using LunaApi.DAL.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LunaApi.Tests
{
    public class TaskServiceTest
    {
        private readonly LunaDbContext _context;
        private readonly TaskService _taskService;

        public TaskServiceTest()
        {
            // Використовуємо in-memory базу даних для тестування
            var options = new DbContextOptionsBuilder<LunaDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Створюємо контекст з in-memory базою
            _context = new LunaDbContext(options);

            // Ініціалізуємо TaskService з цим контекстом
            _taskService = new TaskService(_context);
        }

        [Fact]
        public async Task CreateTask_ValidTask_SavesToDatabase()
        {
            // Arrange
            var taskEntity = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                Description = "Test Description",
                DueDate = DateTime.Now,
                Status = Status.Completed,
                Priority = 0
            };

            // Act
            var result = await _taskService.CreateTask(
                taskEntity.Id,
                taskEntity.Title,
                taskEntity.Description,
                taskEntity.DueDate,
                taskEntity.Status,
                taskEntity.Priority);

            // Assert
            Assert.Equal("Test", result.Title);
            Assert.Equal("Test Description", result.Description);

            // Перевіряємо, чи збережений TaskEntity у базі даних
            var savedTask = await _context.TaskEntity.FindAsync(result.Id);
            Assert.NotNull(savedTask);
            Assert.Equal("Test", savedTask.Title);
            Assert.Equal("Test Description", savedTask.Description);
        }
    }
}
