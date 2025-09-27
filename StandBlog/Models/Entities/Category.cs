﻿namespace StandBlog.Models.Entities;

public class Category
    : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Blog>? Blogs { get; set; }
}
