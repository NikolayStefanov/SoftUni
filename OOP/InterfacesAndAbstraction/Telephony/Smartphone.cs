using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Telephony
{
    public class Smartphone : ICallable, IBrowserable
    {
        public string Browsing(string webSite)
        {
            if (IsBrowseValid(webSite))
            {
                return $"Browsing: {webSite}!";
            }
            return "Invalid URL!";
        }

        private bool IsBrowseValid(string webSite)
        {
            bool isValid = true;
            for (int i = 0; i < webSite.Length; i++)
            {
                if (char.IsDigit(webSite[i]))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        public string Calling(string phoneNum)
        {
            if (NumberValidate(phoneNum))
            {
                return $"Calling... {phoneNum}";
            }
            return "Invalid number!";
        }

        private bool NumberValidate(string phoneNum)
        {
            var isValid = true;
            for (int i = 0; i < phoneNum.Length; i++)
            {
                if (!char.IsDigit(phoneNum[i]))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }
    }
}
