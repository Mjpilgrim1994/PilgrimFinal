using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        // Generating the List
        List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>()
{
    new KeyValuePair<string, string>("doge", "coin"),
    new KeyValuePair<string, string>("abc", "frqscn"),
    new KeyValuePair<string, string>("abc", "qrs"),
    new KeyValuePair<string, string>("doge", "coin"),
    new KeyValuePair<string, string>("farmnadc", "qrescs"),
    new KeyValuePair<string, string>("gqers", "ddsqerd"),
    new KeyValuePair<string, string>("abc", "mndsa"),
    new KeyValuePair<string, string>("doge", "Jetta TDI"),
    new KeyValuePair<string, string>("doge", "coin"),
    new KeyValuePair<string, string>("doge", "frqscn")
};

        Dictionary<string, string> mainDictionary = new Dictionary<string, string>();
        Dictionary<string, int> countDictionary = new Dictionary<string, int>();

        // Stepping though kvp list
        foreach (KeyValuePair<string, string> pair in list)
        {
            // Searching for duplicate values in the list
            if (mainDictionary.ContainsKey(pair.Key))
            {
                // 
                if (!countDictionary.ContainsKey(pair.Key))
                {
                    int value = 2;
                    countDictionary.Add(pair.Key, value);
                }
                // 
                else
                {
                    countDictionary.TryGetValue(pair.Key, out int value);
                    int count = value;

                    countDictionary[pair.Key] = ++count;
                }
            }
            // Add each unique list item to the main dictionary
            else
            {
                mainDictionary.Add(pair.Key, pair.Value);
            }
        }

        // Printing the keys and their values from main dictionary
        Console.WriteLine("--- Writing unique values ---");
        foreach (var kvp in mainDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key} with Value: {kvp.Value}");
        }

        // Printing each kvp that are duplicates and their counts
        Console.WriteLine("--- Writing count details ---");
        foreach (var kvp in countDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key} with Count: {kvp.Value}");
        }
    }
}