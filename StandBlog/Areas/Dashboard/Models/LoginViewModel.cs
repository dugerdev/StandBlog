namespace StandBlog.Areas.Dashboard.Models;

public record LoginViewModel(
    string Email,
    string Password,
    bool RememberMe
    );
