using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ProyectoSO.Localization
{
    public static class ProyectoSOLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ProyectoSOConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ProyectoSOLocalizationConfigurer).GetAssembly(),
                        "ProyectoSO.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
