using System.Text;

// Demo
var factory = new ThemeTrackingFactory();

var theme1 = factory.CreateTheme(true);
var theme2 = factory.CreateTheme(true);
var theme3 = factory.CreateTheme(false);
var theme4 = factory.CreateTheme(false);

Console.WriteLine(factory.Info);

// Factory que permite object tracking
public class ThemeTrackingFactory
{
    // Lista das implementações de ITheme criadas pela factory
    private readonly List<WeakReference<ITheme>> _themes = new();

    // Retorna todos IThemes
    public string Info 
    {
        get
        {
            var result = new StringBuilder();
            
            foreach (var @ref in _themes)
            {
                if (@ref.TryGetTarget(out var theme))
                    result.AppendLine(theme.ToString());
            }

            return result.ToString();
        }
    }

    public ITheme CreateTheme(bool isDark)
    {
        ITheme theme = isDark  ? new DarkTheme() : new LightTheme();
        
        _themes.Add(new WeakReference<ITheme>(theme));

        return theme;
    }
}

// Classes a serem criadas
public class LightTheme : ITheme
{
    public string TextColor => "black";
    public string BackgroundColor => "white";

    public override string ToString()
    {
        return $"{nameof(TextColor)}: {TextColor}, {nameof(BackgroundColor)}: {BackgroundColor}";
    }
}

public class DarkTheme : ITheme
{
    public string TextColor => "white";
    public string BackgroundColor => "gray";

    public override string ToString()
    {
        return $"{nameof(TextColor)}: {TextColor}, {nameof(BackgroundColor)}: {BackgroundColor}";
    }
}

// Contrato das classes a serem criadas
public interface ITheme
{
    public string TextColor { get; }

    public string BackgroundColor { get; }
}