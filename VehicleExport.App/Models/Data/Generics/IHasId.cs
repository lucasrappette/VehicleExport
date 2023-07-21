namespace VehicleExport.App.Models.Data
{
    public interface IHasId<TIdType>
    {
        TIdType GetId();
    }
}
