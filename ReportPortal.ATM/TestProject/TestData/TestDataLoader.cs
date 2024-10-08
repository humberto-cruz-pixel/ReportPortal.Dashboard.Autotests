using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json;

namespace TestProject.TestData;

public static class TestDataLoaderNunit<T>
{
    public static IEnumerable<TestCaseData> LoadTestData(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");

        var jsonData = File.ReadAllText(filePath);

        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<T>>(jsonData) ??
            throw new InvalidOperationException("Failed to deserialize the JSON data.");

        foreach (var dataItem in testDataCollection)
            yield return new TestCaseData(dataItem);
    }
}
