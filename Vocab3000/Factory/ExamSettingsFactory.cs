using System;
using Vocab3000.Exam.Settings;

namespace Vocab3000.Factory
{
    public class ExamSettingsFactory
    {

        public enum SettingTypes {
            Default = 1
        };

        public static ISettings Build(SettingTypes settingType)
        {
            switch (settingType) {
                case SettingTypes.Default:
                    return new DefaultSettings();
                default:
                    throw new ArgumentOutOfRangeException(settingType.ToString()+" is not a valid settings type");
            }
        }
    }
}