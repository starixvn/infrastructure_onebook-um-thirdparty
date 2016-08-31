namespace ONEbook.UM.ThirdParty.Services
{
    using ONEbook.UM.ThirdParty.Models;

    public interface IUMService
    {
        UnderMaintenanceTime GetUnderMaintenanceTime(int productId = 0);
    }
}