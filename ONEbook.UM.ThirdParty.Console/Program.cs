namespace ONEbook.UM.ThirdParty.Console
{
    using ONEbook.UM.ThirdParty.Services.Impl;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var uminfo = (new UMService()).GetUnderMaintenanceTime(23);
        }
    }
}