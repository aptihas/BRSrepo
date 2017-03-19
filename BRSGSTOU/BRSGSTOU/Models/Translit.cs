using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRSGSTOU
{
    public class Translit
    {
        // объявляем и заполняем словарь с заменами
        // при желании можно исправить словать или дополнить
        Dictionary<string, string> dictionaryChar = new Dictionary<string, string>()
            {
                {"а","a"},
                {"б","b"},
                {"в","v"},
                {"г","g"},
                {"д","d"},
                {"е","e"},
                {"ё","yo"},
                {"ж","zh"},
                {"з","z"},
                {"и","i"},
                {"й","y"},
                {"к","k"},
                {"л","l"},
                {"м","m"},
                {"н","n"},
                {"о","o"},
                {"п","p"},
                {"р","r"},
                {"с","s"},
                {"т","t"},
                {"у","u"},
                {"ф","f"},
                {"х","h"},
                {"ц","ts"},
                {"ч","ch"},
                {"ш","sh"},
                {"щ","sch"},
                {"ъ",""},
                {"ы","yi"},
                {"ь",""},
                {"э","e"},
                {"ю","yu"},
                {"я","ya"},
                {".",""},
                {" ",""}
            };
        /// <summary>
        /// метод делает транслит на латиницу
        /// </summary>
        /// 
        Dictionary<string, string> dictionaryPassword = new Dictionary<string, string>()
            {
                {"а","1h"},
                {"б","2h"},
                {"в","3l"},
                {"г","4b"},
                {"д","5b"},
                {"е","6c"},
                {"ё","7n"},
                {"ж","8o"},
                {"з","9f"},
                {"и","10n"},
                {"й","11n"},
                {"к","12m"},
                {"л","13a"},
                {"м","14s"},
                {"н","15p"},
                {"о","16s"},
                {"п","17c"},
                {"р","18a"},
                {"с","19k"},
                {"т","20c"},
                {"у","21s"},
                {"ф","22t"},
                {"х","23v"},
                {"ц","24c"},
                {"ч","25m"},
                {"ш","26f"},
                {"щ","27c"},
                {"ъ","28n"},
                {"ы","29c"},
                {"ь","30z"},
                {"э","31g"},
                {"ю","32g"},
                {"я","33a"},
                {".","34s"},
                {" ","34b"}
            };
        /// <param name="source"> это входная строка для транслитерации </param>
        /// <returns>получаем строку после транслитерации</returns>
        public string TranslitFileName(string source)
        {
            var result = "";
            source = source.ToLower();
            // проход по строке для поиска символов подлежащих замене которые находятся в словаре dictionaryChar
            foreach (var ch in source)
            {
                var ss = "";
                // берём каждый символ строки и проверяем его на нахождение его в словаре для замены,
                // если в словаре есть ключ с таким значением то получаем true 
                // и добавляем значение из словаря соответствующее ключу
                if (dictionaryChar.TryGetValue(ch.ToString(), out ss))
                {
                    result += ss;
                }
                // иначе добавляем тот же символ
                else result += ch;
            }
            return result;
        }

        public string GenPassword(string source)
        {
            var result = "";
            source = source.ToLower();
            // проход по строке для поиска символов подлежащих замене которые находятся в словаре dictionaryChar
            foreach (var ch in source)
            {
                var ss = "";
                // берём каждый символ строки и проверяем его на нахождение его в словаре для замены,
                // если в словаре есть ключ с таким значением то получаем true 
                // и добавляем значение из словаря соответствующее ключу
                if (dictionaryPassword.TryGetValue(ch.ToString(), out ss))
                {
                    result += ss;
                }
                // иначе добавляем тот же символ
                else result += ch;
            }
            return result;
        }
    }
}
