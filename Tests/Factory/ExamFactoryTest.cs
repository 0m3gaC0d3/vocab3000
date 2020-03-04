using NUnit.Framework;
using Vocab3000.Factory;
using Vocab3000.Exam.Settings;
using System;

namespace Tests.Factory
{
    public class ExamFactoryTest
    {
        [TestCase(ExamSettingsFactory.SettingTypes.Default, typeof(DefaultSettings))]
        public void DefaultEnumRetursnDefaultSettings(ExamSettingsFactory.SettingTypes setting, Type expectedType)
        {
            var settings = ExamSettingsFactory.Build(setting);
            Assert.AreEqual(expectedType, settings.GetType());
        }

        [Test]
        public void InvalidTypeThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ExamSettingsFactory.Build((ExamSettingsFactory.SettingTypes)(-1));
            });
        }
    }
}