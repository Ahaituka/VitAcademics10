using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace AcademicsLibrary.Helpers
{
    public class MessageDialog
    {
        public async static void ShowDialog(string message)
        {
            var dlg = new Windows.UI.Popups.MessageDialog(message);
            await dlg.ShowAsync();
        }

    }
}
