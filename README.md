# LunaApi

## Опис проєкту

Luna API — це API для управління завданнями, з реалізованою аутентифікацією на основі JWT (JSON Web Token). API дозволяє користувачам реєструватися, входити в систему та керувати своїми завданнями.

## Інструкції по налаштуванню проєкту локально

### 1. Вимоги

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

### 2. Клонування репозиторію
git clone <https://github.com/Sparky4u/LunaApi.git>

3. Налаштування бази даних
Створіть нову базу даних в SQL Server.
Налаштуйте підключення в файлі appsettings.json

4. Виконання міграцій бази даних
Після налаштування підключення виконайте міграції для створення структури бази даних:
dotnet ef database update
5. Запуск API
Щоб запустити API локально, використайте команду:
dotnet run --project <шлях до вашого .csproj файлу>


Документація API
Аутентифікація
POST /api/User/register

Реєстрація нового користувача.

Запит:
{
  "userName": "example",
  "email": "example@example.com",
  "password": "yourpassword"
}


/api/User/login
Вхід користувача. Повертає JWT токен.

Запит:
{
  "email": "example@example.com",
  "password": "yourpassword"
}
Відповідь:
{
  "token": "your_jwt_token"
}

Завдання
GET /api/task

Отримання всіх завдань користувача. Потрібна аутентифікація (додайте JWT токен у заголовок Authorization).

POST /api/task

Створення нового завдання.

Запит:
{
  "title": "New Task",
  "description": "Task description",
  "dueDate": "2024-09-01T12:00:00Z",
  "status": 1,
  "priority": 2
}
Відповідь:
{
  "id": "new-task-id",
  "title": "New Task",
  "description": "Task description",
  "dueDate": "2024-09-01T12:00:00Z",
  "status": 1,
  "priority": 2,
  "createdAt": "2024-08-01T12:00:00Z",
  "updatedAt": "2024-08-01T12:00:00Z"
}

Архітектура і дизайн
1. Технології
ASP.NET Core: використовується для побудови API.
Entity Framework Core: для роботи з базою даних.
JWT аутентифікація: для забезпечення безпечного доступу до API.
2. Структура проєкту
Controllers: містять API контролери для обробки запитів від клієнтів.
Services: бізнес-логіка для обробки даних і взаємодії між контролерами і репозиторіями.
Repositories: клас для взаємодії з базою даних через Entity Framework Core.
3. JWT Аутентифікація
API використовує JWT токени для аутентифікації. Кожен запит до захищених ресурсів повинен містити токен у заголовку Authorization.
Authorization: Bearer <your_jwt_token>



