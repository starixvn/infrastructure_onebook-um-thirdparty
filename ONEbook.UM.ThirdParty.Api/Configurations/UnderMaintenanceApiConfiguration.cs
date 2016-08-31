namespace ONEbook.UM.ThirdParty.Api.Configurations
{
    using System.Configuration;

    public class UnderMaintenanceApiConfiguration : ConfigurationSection
    {
        private const string EnableUnscheduledUMName = "EnableUnscheduledUM";
        private const string UMFromName = "UMFrom";
        private const string UMToName = "UMTo";
        private const string SecretKeyName = "SecretKey";
        private const string EnableCheckUMName = "EnableCheckUM";
        private const string UMAddressName = "UMAddress";
        private const string ProductsName = "Products";

        private static UnderMaintenanceApiConfiguration settings
            = ConfigurationManager.GetSection("ONEbook.UM.ThirdParty.Api") as UnderMaintenanceApiConfiguration;

        public static UnderMaintenanceApiConfiguration Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty(SecretKeyName, IsRequired = false, DefaultValue = "8oNnvDGiozPj6HVqV7tZZm2mLv+1hguGUQkljwzO59s=")]
        public string SecretKey
        {
            get { return (string)this[SecretKeyName]; }
            set { this[SecretKeyName] = value; }
        }

        [ConfigurationProperty(EnableCheckUMName, IsRequired = false, DefaultValue = true)]
        public bool EnableCheckUM
        {
            get { return (bool)this[EnableCheckUMName]; }
            set { this[EnableCheckUMName] = value; }
        }

        [ConfigurationProperty(EnableUnscheduledUMName, IsRequired = false, DefaultValue = false)]
        public bool EnableUnscheduledUM
        {
            get { return (bool)this[EnableUnscheduledUMName]; }
            set { this[EnableUnscheduledUMName] = value; }
        }

        [ConfigurationProperty(UMFromName, IsRequired = false)]
        public string UMFrom
        {
            get { return (string)this[UMFromName]; }
            set { this[UMFromName] = value; }
        }

        [ConfigurationProperty(UMToName, IsRequired = false)]
        public string UMTo
        {
            get { return (string)this[UMToName]; }
            set { this[UMToName] = value; }
        }

        [ConfigurationProperty(UMAddressName, IsRequired = false)]
        public string UMAddress
        {
            get { return (string)this[UMAddressName]; }
            set { this[UMAddressName] = value; }
        }

        [ConfigurationProperty(ProductsName, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ProductCollection), AddItemName = "add")]
        internal ProductCollection Products
        {
            get
            {
                var products = (ProductCollection)base[ProductsName];

                return products;
            }
        }
    }
}