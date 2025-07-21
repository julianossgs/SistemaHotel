using System.Windows.Forms;

namespace SistemaHotel.Services
{
    internal class EnableHelper
    {
        public static void SetEnabled(bool enabled, params Control[] controls)
        {
            foreach (var ctrl in controls)
            {
                ctrl.Enabled = enabled;
            }
        }
    }
}
