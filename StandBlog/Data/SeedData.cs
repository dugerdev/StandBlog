using Microsoft.AspNetCore.Identity;
using StandBlog.Models.Entities;

namespace StandBlog.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Seed Categories
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Technology", CreatedOn = DateTime.Now },
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Programming", CreatedOn = DateTime.Now },
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Web Development", CreatedOn = DateTime.Now },
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Mobile Development", CreatedOn = DateTime.Now },
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Data Science", CreatedOn = DateTime.Now },
                    new Category { Id = Guid.NewGuid().ToString(), Name = "Artificial Intelligence", CreatedOn = DateTime.Now }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // Seed Tags
            if (!context.Tags.Any())
            {
                var tags = new List<Tag>
                {
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "C#", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "ASP.NET Core", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Entity Framework", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "JavaScript", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "React", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Vue.js", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Angular", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Node.js", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Python", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Machine Learning", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "Database", CreatedOn = DateTime.Now },
                    new Tag { Id = Guid.NewGuid().ToString(), Name = "DevOps", CreatedOn = DateTime.Now }
                };

                await context.Tags.AddRangeAsync(tags);
                await context.SaveChangesAsync();
            }

            // Seed Blogs
            if (!context.Blogs.Any())
            {
                var categories = context.Categories.ToList();
                var tags = context.Tags.ToList();

                var blogs = new List<Blog>
                {
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Getting Started with ASP.NET Core 9.0",
                        Post = @"<p>ASP.NET Core 9.0 brings exciting new features and improvements to the .NET ecosystem. In this comprehensive guide, we'll explore the latest enhancements and how they can benefit your development workflow.</p>

                        <h3>Key Features</h3>
                        <ul>
                            <li>Enhanced performance and scalability</li>
                            <li>Improved developer experience</li>
                            <li>Better integration with modern frontend frameworks</li>
                            <li>Advanced security features</li>
                        </ul>

                        <p>Whether you're building web APIs, MVC applications, or Blazor apps, ASP.NET Core 9.0 provides the tools and flexibility you need to create modern, high-performance applications.</p>

                        <h3>Getting Started</h3>
                        <p>To get started with ASP.NET Core 9.0, you'll need to install the latest .NET SDK and create a new project using the dotnet CLI or Visual Studio.</p>",
                        CategoryId = categories.First(c => c.Name == "Web Development").Id,
                        CreatedOn = DateTime.Now.AddDays(-5)
                    },
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Mastering Entity Framework Core",
                        Post = @"<p>Entity Framework Core is Microsoft's modern object-database mapper for .NET applications. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns.</p>

                        <h3>Core Concepts</h3>
                        <p>Understanding the core concepts of Entity Framework Core is essential for building robust data access layers. This includes DbContext, DbSet, and the various mapping configurations.</p>

                        <h3>Best Practices</h3>
                        <ul>
                            <li>Use async/await for database operations</li>
                            <li>Implement proper error handling</li>
                            <li>Optimize queries to avoid N+1 problems</li>
                            <li>Use migrations for database schema changes</li>
                        </ul>",
                        CategoryId = categories.First(c => c.Name == "Programming").Id,
                        CreatedOn = DateTime.Now.AddDays(-3)
                    },
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Building Modern Web Applications with React and .NET",
                        Post = @"<p>Combining React with .NET backend creates powerful full-stack applications. This guide will walk you through setting up a complete development environment and building a modern web application.</p>

                        <h3>Architecture Overview</h3>
                        <p>We'll use React for the frontend, ASP.NET Core Web API for the backend, and Entity Framework Core for data access. This combination provides excellent performance and developer experience.</p>

                        <h3>Project Setup</h3>
                        <p>Setting up the project involves creating both frontend and backend projects, configuring CORS, and implementing authentication and authorization.</p>",
                        CategoryId = categories.First(c => c.Name == "Web Development").Id,
                        CreatedOn = DateTime.Now.AddDays(-1)
                    },
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Introduction to Machine Learning with Python",
                        Post = @"<p>Machine Learning is revolutionizing how we approach data analysis and problem-solving. This comprehensive introduction covers the fundamentals of ML using Python and popular libraries like scikit-learn and TensorFlow.</p>

                        <h3>What is Machine Learning?</h3>
                        <p>Machine Learning is a subset of artificial intelligence that enables computers to learn and make decisions from data without being explicitly programmed for every task.</p>

                        <h3>Types of Machine Learning</h3>
                        <ul>
                            <li>Supervised Learning</li>
                            <li>Unsupervised Learning</li>
                            <li>Reinforcement Learning</li>
                        </ul>",
                        CategoryId = categories.First(c => c.Name == "Data Science").Id,
                        CreatedOn = DateTime.Now.AddDays(-7)
                    },
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Mobile App Development with Xamarin",
                        Post = @"<p>Xamarin allows developers to build native mobile applications for iOS, Android, and Windows using C# and .NET. This guide covers the essentials of cross-platform mobile development.</p>

                        <h3>Benefits of Xamarin</h3>
                        <ul>
                            <li>Code sharing across platforms</li>
                            <li>Native performance</li>
                            <li>Access to platform-specific APIs</li>
                            <li>Familiar C# development experience</li>
                        </ul>

                        <p>With Xamarin, you can write your business logic once and share it across all platforms, while still delivering native user experiences.</p>",
                        CategoryId = categories.First(c => c.Name == "Mobile Development").Id,
                        CreatedOn = DateTime.Now.AddDays(-10)
                    },
                    new Blog
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "DevOps Best Practices for .NET Applications",
                        Post = @"<p>DevOps practices are essential for modern software development. This article covers best practices for deploying, monitoring, and maintaining .NET applications in production environments.</p>

                        <h3>Continuous Integration and Deployment</h3>
                        <p>Implementing CI/CD pipelines ensures consistent and reliable deployments. We'll cover setting up automated builds, testing, and deployment processes.</p>

                        <h3>Monitoring and Logging</h3>
                        <p>Proper monitoring and logging are crucial for maintaining application health and performance in production environments.</p>",
                        CategoryId = categories.First(c => c.Name == "Technology").Id,
                        CreatedOn = DateTime.Now.AddDays(-2)
                    }
                };

                await context.Blogs.AddRangeAsync(blogs);
                await context.SaveChangesAsync();

                // Add blog tags
                var blogTags = new List<BlogTag>();
                var blogList = context.Blogs.ToList();

                foreach (var blog in blogList)
                {
                    var randomTags = tags.OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                    foreach (var tag in randomTags)
                    {
                        blogTags.Add(new BlogTag
                        {
                            Id = Guid.NewGuid().ToString(),
                            BlogId = blog.Id,
                            TagId = tag.Id,
                            CreatedOn = DateTime.Now
                        });
                    }
                }

                await context.BlogTags.AddRangeAsync(blogTags);
                await context.SaveChangesAsync();
            }

            // Seed Comments
            if (!context.Comments.Any())
            {
                var blogs = context.Blogs.Take(3).ToList();
                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = Guid.NewGuid().ToString(),
                        BlogId = blogs[0].Id,
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        Message = "Great article! This really helped me understand ASP.NET Core better. Looking forward to more content like this.",
                        CreatedOn = DateTime.Now.AddDays(-2)
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid().ToString(),
                        BlogId = blogs[0].Id,
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        Message = "Excellent explanation of the new features. I've already started implementing some of these in my projects.",
                        CreatedOn = DateTime.Now.AddDays(-1)
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid().ToString(),
                        BlogId = blogs[1].Id,
                        Name = "Mike Johnson",
                        Email = "mike.johnson@example.com",
                        Message = "Entity Framework Core is such a powerful tool. Thanks for sharing these best practices!",
                        CreatedOn = DateTime.Now.AddDays(-3)
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid().ToString(),
                        BlogId = blogs[2].Id,
                        Name = "Sarah Wilson",
                        Email = "sarah.wilson@example.com",
                        Message = "The combination of React and .NET is indeed powerful. I've been using this stack for my recent projects.",
                        CreatedOn = DateTime.Now.AddDays(-1)
                    }
                };

                await context.Comments.AddRangeAsync(comments);
                await context.SaveChangesAsync();
            }

            // Seed Contacts
            if (!context.Contacts.Any())
            {
                var contacts = new List<Contact>
                {
                    new Contact
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Alice Brown",
                        Email = "alice.brown@example.com",
                        Subject = "Question about your blog",
                        Message = "Hi, I really enjoyed reading your articles. I have a question about implementing authentication in ASP.NET Core. Could you help me?",
                        CreatedOn = DateTime.Now.AddDays(-1)
                    },
                    new Contact
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Bob Davis",
                        Email = "bob.davis@example.com",
                        Subject = "Partnership opportunity",
                        Message = "Hello, I'm interested in collaborating on a project. Would you be available for a discussion?",
                        CreatedOn = DateTime.Now.AddDays(-2)
                    },
                    new Contact
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Carol White",
                        Email = "carol.white@example.com",
                        Subject = "Technical support",
                        Message = "I'm having trouble with the code examples in your latest blog post. Could you provide more details?",
                        CreatedOn = DateTime.Now.AddDays(-3)
                    }
                };

                await context.Contacts.AddRangeAsync(contacts);
                await context.SaveChangesAsync();
            }
        }
    }
}
