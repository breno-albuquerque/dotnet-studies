// Demo
var useCase = new UseCase(new XmlToJsonAdapter(new XmlData()));
useCase.printData();

// UseCase example (only accepts IJsonData)
public class UseCase
{
    private readonly IJsonData _jsonData;
    
    public UseCase(IJsonData jsonData)
    {
        _jsonData = jsonData;
    }

    public void printData()
    {
        var data = _jsonData.GetJsonData();
        Console.WriteLine(data);
    }
}

// Contract used by our code
public interface IJsonData
{
    string GetJsonData();
}

// Adaptee (External code)
class XmlData
{
    public string GetXmlData()
    {
        return "String in XML format";
    }
}

// Adapter implementation
class XmlToJsonAdapter : IJsonData
{
    private readonly XmlData _xmlData;

    public XmlToJsonAdapter(XmlData xmlData)
    {
        _xmlData = xmlData;
    }

    public string GetJsonData()
    {
        var xmlData = _xmlData.GetXmlData();

        var jsonData = ConverToJson(xmlData);

        return jsonData;
    }

    private string ConverToJson(string xml)
    {
        // Logic to convert to json ...

        return "XML converted to JSON";
    }
}