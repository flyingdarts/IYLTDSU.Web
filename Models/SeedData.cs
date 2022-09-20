using IYLTDSU.WebApp.Models.Lobby;

namespace IYLTDSU.WebApp.Models;

public class SeedData
{
    public static SidebarViewModel LobbyViewModel => new()
    {
        CurrentUser = new SidebarPlayerViewModel
        {
            ImageUrl = "icon-male.png",
            UserName = "Mike Pattyn",
            UserStatus = "Mkkkaay, idk"
        },
        PartySettings = new PartySettings { IsOpen = true, SpotsLeft = 8 },
        Friends = new List<SidebarPlayerViewModel>
        {
            new() { UserName = "Timmy", UserStatus = "Wazaaa", ImageUrl = "icon-female.png", LastLogin = DateTime.UtcNow },
            new() { UserName = "Eric", UserStatus = "Ah yeet", ImageUrl = "icon-male.png" }
        }
    };
}
