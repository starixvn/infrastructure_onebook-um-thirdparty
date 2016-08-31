namespace ONEbook.UM.ThirdParty.Api.Services.Impl
{
    using Configurations;
    using Models;
    using Sunplus.UMControllerLibrary;

    public class UMControlAdapter : IUMControlAdapter
    {
        public UnderMaintenanceTime GetUnderMaintenanceTime(int siteId, int productId = 0)
        {
            if (UnderMaintenanceApiConfiguration.Settings.EnableUnscheduledUM)
            {
                return new UnderMaintenanceTime(true, UnderMaintenanceApiConfiguration.Settings.UMFrom, UnderMaintenanceApiConfiguration.Settings.UMTo);
            }

            if (UnderMaintenanceApiConfiguration.Settings.EnableCheckUM
                && productId > 0)
            {
                foreach (ProductElement product in UnderMaintenanceApiConfiguration.Settings.Products)
                {
                    if (product.Id == productId
                        && product.IsUM)
                    {
                        return new UnderMaintenanceTime(true, product.UMFrom, product.UMTo);
                    }
                }
            }

            return new UnderMaintenanceTime(false, "0:00", "0:00");
        }
    }
}