namespace ONEbook.UM.ThirdParty.Api.Services
{
    using Models;

    public interface IUMControlAdapter
    {
        UnderMaintenanceTime GetUnderMaintenanceTime(int siteId, int productId = 0);
    }
}