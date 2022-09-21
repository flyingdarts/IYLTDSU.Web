namespace IYLTDSU.WebApp.Models.Lobby;

public class SidebarViewModel
{
    public SidebarPlayerViewModel CurrentUser { get; set; }
    public PartySettings PartySettings { get; set; }
    public List<SidebarPlayerViewModel> Friends { get; set; }
}
