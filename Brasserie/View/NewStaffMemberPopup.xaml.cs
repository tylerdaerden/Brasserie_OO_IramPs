using Brasserie.ViewModel;
using CommunityToolkit.Maui.Views;

namespace Brasserie.View;

public partial class NewStaffMemberPopup : Popup
{
    public NewStaffMemberPopup(StaffMembersPageViewModel staffMembersPageVM)
    {
        BindingContext = staffMembersPageVM;
        InitializeComponent();
    }
    private void buttonClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}
