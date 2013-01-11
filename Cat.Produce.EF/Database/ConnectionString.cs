using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Diagnostics;
using System.Globalization;
namespace Cat.Produce.EF
{
    using Jiuzh.CoreBase.Infrastructure;
    public class ConnectionString : IConnectionString
    {
        private const string _demMetadataFormat = "{0}\\{1}.csdl|{0}\\{2}.ssdl|{0}\\{3}.msl";

        private const string _csdlFileName = "_Produce";
        private const string _mslFileName = "_Produce";
        private const string _ssdlFileName = "_Produce";
        private const string _demFilesPath = "|DataDirectory|";

        private readonly EntityConnectionStringBuilder _entityBuilder;

        public ConnectionString(IConfigurationManager configuration, string name)
            : this(configuration, name, null, null, null, null)
        {

        }

        public ConnectionString(IConfigurationManager configuration, string name, string edmFilesPath)
            : this(configuration, name, edmFilesPath, null, null, null)
        {
        }

        public ConnectionString(IConfigurationManager configuration, string name, string edmFilesPath, string ssdlFileName)
            : this(configuration, name, edmFilesPath, ssdlFileName, null, null)
        {
        }

        public ConnectionString(IConfigurationManager configuration, string name, string edmFilesPath,
            string ssdlFileName, string csdlFileName, string mslFileName)
        {
            if(String.IsNullOrEmpty(edmFilesPath))
            {
                edmFilesPath=_demFilesPath;
            }

            if(String.IsNullOrEmpty(ssdlFileName))
            {
                ssdlFileName=_ssdlFileName;
            }

            if(String.IsNullOrEmpty(csdlFileName))
            {
                csdlFileName=_csdlFileName;
            }
            if(String.IsNullOrEmpty(mslFileName))
            {
                mslFileName=_mslFileName;
            }

            string providerConnectionString=configuration.GetConnectionString(name);
            string providerName=configuration.GetProviderName(name);
            string metadata = String.Format(CultureInfo.InvariantCulture,
                _demMetadataFormat, edmFilesPath, csdlFileName, ssdlFileName, mslFileName);
            _entityBuilder = new EntityConnectionStringBuilder
            {
                ProviderConnectionString = providerConnectionString,
                Provider = providerName,
                Metadata = metadata
            };
        }

        public string Value
        {
            ////[DebuggerStepThrough]
            get
            {
                return _entityBuilder.ConnectionString;
            }
        }

        public string ProviderName
        {
            get
            {
                return _entityBuilder.Provider;
            }
        }
    }
}
