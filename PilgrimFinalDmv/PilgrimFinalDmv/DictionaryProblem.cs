internal class DictionaryProblem
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> mainDictionary = new Dictionary<string, string>();
        mainDictionary.Add("a", "abs");
        mainDictionary.Add("b", "basic");
        mainDictionary.Add("v", "venus");
        mainDictionary.Add("d", "dentist");


        foreach (KeyValuePair<string, string> kvp in mainDictionary)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
    }
}