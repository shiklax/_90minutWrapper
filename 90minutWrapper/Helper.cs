namespace _90minutWrapper
{
    class Helper
    {
        public List<string> ExtractToList(string input, string[] delimiter, bool replaceWhiteSpace)
        {
            var temp = ExtractColons(input);
            if (replaceWhiteSpace)
            {
                temp = ExtractColons(input.Replace(" ", ""));
            }
            List<string> result = new List<string>();
            string[] lines = temp.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                result.Add(line);
            }
            return result;
        }
        public List<string> ExtractToList(List<string> list)
        {
            var result = new List<string>();
            foreach (var item in list)
            {
                var temp = item.Replace("&nbsp;", "");
                result.Add(temp);
            }
            return result;
        }
        public string ExtractColons(string input)
        {
            int firstColonIndex = input.IndexOf(':');
            if (firstColonIndex >= 0)
            {
                string ExtractColonsedDate = input.Substring(firstColonIndex + 1).Trim();
                return ExtractColonsedDate;
            }
            return input;
        }
    }
}
