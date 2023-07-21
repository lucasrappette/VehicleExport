using VehicleExport.App.Models.Notifications;
using System.Threading.Tasks;

namespace VehicleExport.Web.Hubs
{
    public interface INotificationClient
    {
        Task OnAlert(AlertDTO alert);
    }
}
