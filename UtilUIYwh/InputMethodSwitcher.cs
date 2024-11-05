using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UtilUIYwh
{
    public class InputMethodSwitcher
    {
        /// <summary>
        /// 获取当前输入法
        /// </summary>
        /// <returns></returns>
        private string GetCultureType()
        {
            var currentInputLanguage = InputLanguage.CurrentInputLanguage;
            var cultureInfo = currentInputLanguage.Culture;
            //同 cultureInfo.IetfLanguageTag;
            return cultureInfo.Name;
        }

        /// <summary>
        /// 切换输入法
        /// </summary>
        /// <param name="cultureType">语言项，如zh-CN，en-US</param>
        private void SwitchToLanguageMode(string cultureType)
        {
            var installedInputLanguages = InputLanguage.InstalledInputLanguages;

            if (installedInputLanguages.Cast<InputLanguage>().Any(i => i.Culture.Name == cultureType))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo(cultureType));
               // CurrentLanguage = cultureType;
            }
        }

        /// <summary>
        /// 切换输入法
        /// </summary>
        /// <param name="cultureType">语言项，如zh-CN，en-US</param>
        public static void Set_En_US_LanguageMode()
        {
            string englishInput = "en-US";
            var installedInputLanguages = InputLanguage.InstalledInputLanguages;
            var currentLanguage = InputLanguage.CurrentInputLanguage;
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(CultureInfo.GetCultureInfo("en-US"));

         
            if (installedInputLanguages.Cast<InputLanguage>().Any(i => i.Culture.Name == englishInput))
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo(englishInput));
                // CurrentLanguage = cultureType;
            }
        }
    }

    // 使用方法：
    // InputMethodSwitcher.SwitchToEnglishInputMethod();
}
