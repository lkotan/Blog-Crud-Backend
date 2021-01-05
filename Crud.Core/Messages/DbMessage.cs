using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Messages
{
    public class DbMessage
    {
        public static string DataInserted => "Kayıt Eklendi";
        public static string DataNotFound => "Kayıt bulunamadı";
        public static string DataUpdated => "Güncellendi";
        public static string DataRemoved => "Silindi";
    }
}
