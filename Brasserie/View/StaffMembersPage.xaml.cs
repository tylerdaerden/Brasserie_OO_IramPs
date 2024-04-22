using Brasserie.ViewModel;

namespace Brasserie.View;

public partial class StaffMembersPage : ContentPage
{
    public StaffMembersPage(StaffMembersPageViewModel staffMembersPageVM)
    {
        BindingContext = staffMembersPageVM;
        InitializeComponent();
    }
}