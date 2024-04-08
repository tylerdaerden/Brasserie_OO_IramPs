using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.Interfaces
{
    public interface IAlertService
    {
        // show alert with just a title and a message
        Task ShowAlert(string title, string message);
        //show confirmation message style Yes No
        Task<bool> ShowConfirmation(string title, string message);
        //show alert with a pop up display with a list of buttons(multiple choices)
        Task<string> ShowQuestion(string title, params string[] buttons);
    }
}
