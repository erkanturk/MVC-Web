namespace _06_Custom_Helpers.Helpers
{
    public static class StringHelpers
    {
        //Static sınıflar static üyeler içerebilir Ve örneklenemezler sınıf adı ile erişilir
        //Compile tasında bellekte tek bir kopyası oluşturulur
        //Bir defa kullanılır ve tüm uygulama boyunca paylaşılır
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))//Boş veya null kontrolü
            {
                return input;//Eğer string boşsa veya null ise aynen geri döner
            }
            return char.ToUpper(input[0]) + input.Substring(1);//ilk Harfi büyük yapar
        }

        public static string CapitalizeWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var words = input.Split(' ');//Boşluk karakterine göre kelimelere ayırır
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CapitalizeFirstLetter(words[i]);//Her kelimenin ilk harfini büyük yapar
            }
            return string.Join(" ", words);//Kelimeleri tekrar boşluk ile birleştirir
        }
        public static string WordsLength(string input)
        {
            return input.Length.ToString();//Stringin uzunluğunu döner
        }
    }
}
