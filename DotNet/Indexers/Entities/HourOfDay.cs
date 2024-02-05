using Indexers.Contracts;

namespace Indexers.Entities;

public class HourOfDay : IHourOfDay
{
    private readonly string[] _hours = new string[24]
    {
        "0:00am", "1:00am", "2:00am", "3:00am", "4:00am", "5:00am",
        "6:00am", "7:00am", "8:00am", "9:00am", "10:00am", "11:00am",
        "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm",
        "6:00pm", "7:00pm", "8:00pm", "9:00pm", "10:00pm", "11:00pm", 
    };
    
    public string this[int i]
    {
        get => _hours[i];
    }

    public int GetHourIndex(string hour)
    {
        for (var i = 0; i < _hours.Length; i += 1)
            if (_hours[i] == hour)
                return i;

        throw new ArgumentException("Hour not found");
    }
}