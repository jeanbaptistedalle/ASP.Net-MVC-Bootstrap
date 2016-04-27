using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace TestApp2
{
    public static class DateTimeHelper
    {

        /// <summary>
        /// Renvoie la date sous forme d'une string de la forme "dd/MM/yyyy"
        /// </summary>
        public static string ToDDMMYYYY(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Renvoie le debut du jour de la date donnée (ex: 12/06/2015 10:20 => 12/06/2015 00:00)
        /// </summary>
        public static DateTime GetStartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        /// <summary>
        /// Renvoie la fin du jour de la date donnée (ex: 12/06/2015 10:20 => 12/06/2015 23:59)
        /// </summary>
        public static DateTime GetEndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
    }
}