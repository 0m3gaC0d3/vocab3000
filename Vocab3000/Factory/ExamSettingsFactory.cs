using System;
using Vocab3000.Exam.Settings;

namespace Vocab3000.Factory
{
    public class ExamSettingsFactory
    {

        public enum SettingTypes
        {
            Default = 1,
            Test = 2,
            Free = 3
        };

        public static ISettings Build(SettingTypes settingType)
        {
            switch (settingType)
            {
                case SettingTypes.Default:
                    return new DefaultSettings();
                case SettingTypes.Test:
                    return new TestSettings();
                case SettingTypes.Free:
                    return new FreeSettings();
                default:
                    throw new ArgumentOutOfRangeException(settingType.ToString() + " is not a valid settings type");
            }
        }
    }
}