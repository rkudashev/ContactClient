# Contact Management System

Современное веб-приложение для управления списком контактов, построенное на стеке .NET 9 и React.

## 🚀 Стек технологий

*   **Backend:** C# 10+, **.NET 9.0**, ASP.NET Core Web API.
*   **Database:** SQLite + Entity Framework Core 9.
*   **Frontend:** React, Bootstrap (пагинация и формы).
*   **Библиотеки:** 
    *   `Bogus`: Генерация реалистичных тестовых данных.
    *   `Microsoft.AspNetCore.OpenApi`: Интеграция Swagger/OpenAPI.

## 📂 Структура Backend (C#)

*   **`Controllers/`**: `ContactManagementController` наследуется от `BaseController`.
*   **`Model/`**: Модель данных `Contact`.
*   **`ModelDto/`**: Объекты для передачи данных (Data Transfer Objects).
*   **`DataContext/`**: Контекст базы данных SQLite через EF Core.
*   **`Seed/`**: Первичная инициализация базы данных.
*   **`Storage/`**: Логика работы с БД.


## 📝 API Endpoints

Согласно спецификации Swagger (v1):


| Метод | Путь | Описание |
| :--- | :--- | :--- |
| **GET** | `/api/ContactManagement/contacts` | Получить все контакты |
| **GET** | `/api/ContactManagement/contacts/{id}` | Получить контакт по ID |
| **POST** | `/api/ContactManagement/contacts` | Создать новый контакт |
| **PUT** | `/api/ContactManagement/contacts/{id}` | Обновить данные контакта |
| **DELETE** | `/api/ContactManagement/contacts/{id}` | Удалить контакт |

---
*Проект разработан в демонстрационных целях для работы с современным стеком .NET 9.0.*