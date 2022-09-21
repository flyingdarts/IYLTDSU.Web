namespace IYLTDSU.WebApp.Models.Lobby;

public class SidebarPlayerViewModel
{
    public string ImageUrl { get; set; }
    public string UserName { get; set; }
    public string UserStatus { get; set; }
    public DateTime? LastLogin { get; set; }

    public bool IsLoggedIn => LastLogin != null && LastLogin!.Value.AddMinutes(15) >= DateTime.UtcNow;
}
