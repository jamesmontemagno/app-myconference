using MyConference.ViewModels;

namespace MyConference.Pages;

public partial class AgendaPage : ContentPage
{
    public AgendaPage()
    {
        InitializeComponent();
    }
}

public partial class AgendaDay1Page : AgendaPage
{
    public AgendaDay1Page() : base()
    {
        Title = "MyAgenda - Day 1";
    }
}
public partial class AgendaDay2Page : AgendaPage
{
    public AgendaDay2Page() : base()
    {
        Title = "MyAgenda - Day 2";
    }
}