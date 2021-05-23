using System;
using System.Collections.Generic;

namespace APMAN.Core
{
    public static class ApmanCommonExtensions
    {
        /// <summary>
        /// string geçerlilik kontrolü
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsEmptyString(this string item)
        {
            if (string.IsNullOrEmpty(item))
                return true;
            else
                return false;
        }

        /// <summary>
        /// listelerin null veya 0 elemana sahip olma durumu kontrolü
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsNullOrZeroCount<T>(this List<T> item)
        {
            if (item == null || item.Count < 1)
                return true;
            else
                return false;

        }

    }
}
