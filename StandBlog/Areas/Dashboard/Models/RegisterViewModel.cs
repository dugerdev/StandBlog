namespace StandBlog.Areas.Dashboard.Models;

public record RegisterViewModel(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Email,
    string Password,
    string ConfirmPassword
    );
