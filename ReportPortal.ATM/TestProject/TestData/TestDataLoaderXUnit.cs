using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class TestDataLoaderXUnit<T>
{
    public static IEnumerable<object[]> LoadTestData(string filePath)
    {
        var dataList = LoadDataFromJsonFile(filePath);
        foreach (var data in dataList)
        {
            yield return new object[] { data };
        }
    }

    private static List<T> LoadDataFromJsonFile(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<T>>(jsonString);
    }
}