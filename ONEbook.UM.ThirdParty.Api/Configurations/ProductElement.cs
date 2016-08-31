namespace ONEbook.UM.ThirdParty.Api.Configurations
{
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    public class ProductElement : ConfigurationElement
    {
        private const string IdName = "Id";
        private const string IsUMName = "IsUM";
        private const string UMFromName = "UMFrom";
        private const string UMToName = "UMTo";

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed!"),
        ConfigurationProperty(IdName, IsRequired = false)]
        public int Id
        {
            get
            {
                return (int)this[IdName];
            }

            set
            {
                this[IdName] = value;
            }
        }

        [ConfigurationProperty(IsUMName, IsRequired = false)]
        public bool IsUM
        {
            get
            {
                return (bool)this[IsUMName];
            }

            set
            {
                this[IsUMName] = value;
            }
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
    }
}