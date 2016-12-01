namespace ONEbook.UM.ThirdParty.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    public class UMClientConfiguration : ConfigurationSection
    {
        private const string SiteIdName = "SiteId";
        private const string ServiceUrisName = "ServiceUris";
        private const string EnableCheckUMName = "EnableCheckUM";
        private const string EnableUnscheduledUMName = "EnableUnscheduledUM";
        private const string UMFromName = "UMFrom";
        private const string UMToName = "UMTo";
        private const string SecretKeyName = "SecretKey";
        private const string UMPageUrlName = "UMPageUrl";
        private const string UMResultCacheDurationName = "UMResultCacheDuration";
        private const string ProductsName = "Products";

        private static UMClientConfiguration settings;

        public static UMClientConfiguration Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = ConfigurationManager.GetSection("ONEbook.UM.ThirdParty") as UMClientConfiguration;
                }

                return settings;
            }
        }

        [ConfigurationProperty(ServiceUrisName, IsRequired = true)]
        public string ServiceUris
        {
            get { return (string)this[ServiceUrisName]; }
            set { this[ServiceUrisName] = value; }
        }

        [ConfigurationProperty(EnableCheckUMName, IsRequired = false, DefaultValue = true)]
        public bool EnableCheckUM
        {
            get { return (bool)this[EnableCheckUMName]; }
            set { this[EnableCheckUMName] = value; }
        }

        [ConfigurationProperty(SecretKeyName, IsRequired = false, DefaultValue = "8oNnvDGiozPj6HVqV7tZZm2mLv+1hguGUQkljwzO59s=")]
        public string SecretKey
        {
            get { return (string)this[SecretKeyName]; }
            set { this[SecretKeyName] = value; }
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

        [ConfigurationProperty(UMPageUrlName, IsRequired = false, DefaultValue = "~/UserLogin/Common/Offline")]
        public string UMPageUrl
        {
            get { return (string)this[UMPageUrlName]; }
            set { this[UMPageUrlName] = value; }
        }

        [ConfigurationProperty(SiteIdName, IsRequired = false, DefaultValue = 4120)]
        public int SiteId
        {
            get { return (int)this[SiteIdName]; }
            set { this[SiteIdName] = value; }
        }

        [ConfigurationProperty(UMResultCacheDurationName, IsRequired = false, DefaultValue = 60)]
        public int ResultCacheDuration
        {
            get { return (int)this[UMResultCacheDurationName]; }
            set { this[UMResultCacheDurationName] = value; }
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