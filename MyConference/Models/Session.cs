using CommunityToolkit.Mvvm.ComponentModel;

namespace MyConference.Models;

public partial class Session : ObservableObject
{
    // Static
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Room { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string StartTimeDisplay => $"{Start:t}";
    public string DayDisplay => $"{Start:MMM} {Start:d}";
    public Speaker Speaker { get; set; } = new Speaker
    {
        Name = "James Montemagno",
        Company = "Microsoft",
        Description = "James Montemagno is a Principal Lead Program Manager for .NET Community at Microsoft. He has been a .NET developer since 2005, working in a wide range of industries including game development, printer software, and web services. Prior to becoming a Principal Program Manager, James was a professional mobile developer and has now been crafting apps since 2011 with Xamarin. In his spare time, he is most likely cycling around Seattle or guzzling gallons of coffee at a local coffee shop.",
        Title = "Principal Lead Program Manager"
    };

    // Dynamic
    [ObservableProperty]
    bool inAgenda;
}
