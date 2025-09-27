# StandBlog

A modern ASP.NET Core MVC blog application. A full-featured blog platform where users can create blog posts, categorize them, and tag them.

## 🚀 Features

### General Features
- **Modern Blog System**: User-friendly interface for blog posts
- **Category Management**: Organize blog posts into categories
- **Tag System**: Organize blog posts with tags
- **Comment System**: Readers can comment on blog posts
- **Contact Form**: Visitors can contact the site owner
- **Responsive Design**: Mobile and desktop compatible modern interface

### Admin Panel (Dashboard)
- **Admin Panel**: Manage blog content
- **Blog Management**: Create, edit, delete blog posts
- **Category Management**: Manage categories
- **Tag Management**: Manage tags
- **Comment Management**: Moderate comments
- **Contact Messages**: View incoming contact messages
- **User Management**: User registration and login operations

## 🛠️ Technologies

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core MVC**: Web application framework
- **Entity Framework Core**: ORM (Object-Relational Mapping)
- **SQL Server**: Database
- **ASP.NET Core Identity**: User authentication and authorization
- **FluentValidation**: Model validation
- **Bootstrap**: Frontend CSS framework
- **jQuery**: JavaScript library

## 📁 Project Structure

```
StandBlog/
├── Areas/
│   └── Dashboard/                 # Admin panel
│       ├── Controllers/          # Dashboard controllers
│       ├── Models/              # View models
│       ├── Validators/          # View model validators
│       └── Views/               # Dashboard views
├── Controllers/                  # Main page controllers
├── Data/
│   └── ApplicationDbContext.cs  # Entity Framework DbContext
├── Models/
│   ├── Entities/                # Database entities
│   ├── Mappings/                # Entity configurations
│   └── Validators/              # Entity validators
├── Migrations/                   # Entity Framework migrations
├── ViewComponents/              # Reusable view components
├── Views/                       # Main page views
└── wwwroot/                     # Static files (CSS, JS, images)
```

## 🗄️ Database Structure

### Main Entities
- **Blog**: Blog posts
- **Category**: Categories
- **Tag**: Tags
- **Comment**: Comments
- **Contact**: Contact messages
- **ApplicationUser**: Users (ASP.NET Identity)

### Relationships
- Blog → Category (Many-to-One)
- Blog → Comments (One-to-Many)
- Blog → BlogTags (One-to-Many)
- BlogTag → Tag (Many-to-One)

## 🚀 Installation

### Requirements
- .NET 9.0 SDK
- SQL Server (LocalDB or SQL Server)
- Visual Studio 2022 or VS Code

### Steps

1. **Clone the project**
   ```bash
   git clone [repository-url]
   cd StandBlog
   ```

2. **Configure database connection string**
   Update the `DefaultConnection` string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StandBlogDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Run migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   ```
   https://localhost:5001
   ```

## 👤 Default Users

Roles automatically created during system setup:
- **Admin**: Full permissions
- **User**: Limited permissions

## 📝 Usage

### General Users
- View blog posts on the homepage
- Filter by category and tags
- Comment on blog posts
- Send messages via contact form

### Admin Users
- Access admin panel from `/Dashboard`
- Manage blog posts, categories, tags
- Moderate comments
- View contact messages

## 🎨 Customization

### Theme Changes
- Edit CSS files in `wwwroot/assets/css/` folder
- Customize main layout from `Views/Shared/_Layout.cshtml`

### Adding New Features
- Add new entities to `Models/Entities/` folder
- Add controllers to `Controllers/` or `Areas/Dashboard/Controllers/` folder
- Add views to relevant folders

## 🔧 Development

### Creating Migrations
```bash
dotnet ef migrations add MigrationName
```

### Updating Database
```bash
dotnet ef database update
```

### Adding Validators
You can add new validators using FluentValidation:
```csharp
public class MyModelValidator : AbstractValidator<MyModel>
{
    public MyModelValidator()
    {
        RuleFor(x => x.Property).NotEmpty();
    }
}
```

## 📄 License

This project is licensed under the MIT License.

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📞 Contact

You can use the contact form or create an issue for questions about the project.

---

**StandBlog** - Modern, user-friendly blog platform 🚀