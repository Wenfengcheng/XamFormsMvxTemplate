using Plugin.Settings.Abstractions;

namespace XamForms.MvxTemplate.Core.Helpers
{
    public static class SettingExtensions
    {
        public const string SuperNumberKey = "SuperNumberKey";

        public const int SuperNumberDefaultValue = 1;

        public static int GetSuperNumber(this ISettings settings)
        {
            return settings.GetValueOrDefault<int>(SuperNumberKey, 1);
        }

        public static void SetSuperNumber(this ISettings settings, int value)
        {
            settings.AddOrUpdateValue<int>(SuperNumberKey, value);
        }
    }
}
