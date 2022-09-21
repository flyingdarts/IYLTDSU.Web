using IYLTDSU.WebApp.Models;

namespace IYLTDSU.WebApp.Views.Home;

public class HomePageViewModel
{
    public string Tokens { get; set; } = "";
    public bool AcceptedTOSPP { get; set; } = false;
    public DateTime? DateConfirmed { get; set; } = null;
    public string Code { get; set; } = "";
}
