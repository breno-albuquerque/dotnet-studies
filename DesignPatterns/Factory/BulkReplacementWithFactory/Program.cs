// Demo
var factory = new ThemeReplacebleFactory();

var theme1 = factory.CreateThemeRef(false);
var theme2 = factory.CreateThemeRef(false);
var theme3 = factory.CreateThemeRef(true);
var theme4 = factory.CreateThemeRef(true);
var themes = new Ref<ITheme>[4] { theme1, theme2, theme3, theme4 };

Console.WriteLine("Before bulk change:");
foreach (var themeRef in themes)
    Console.WriteLine(themeRef.Value);

factory.ReplaceAllThemes(true);

Console.WriteLine("After bulk change:");
foreach (var themeRef in themes)
    Console.WriteLine(themeRef.Value);

// Factory que permite object tracking e bulk replacement
public class ThemeReplacebleFactory
{
    // Lista das implementações de Ref<ITheme> criadas pela factory
    private readonly List<WeakReference<Ref<ITheme>>> _themes = new();
    
    public Ref<ITheme> CreateThemeRef(bool isDark)
    {
        var themeRef = new Ref<ITheme>(CreateTheme(isDark));
        _themes.Add(new WeakReference<Ref<ITheme>>(themeRef));

        return themeRef;
    }

    // Substitui o Value de todos Ref<ITheme> salvos
    public void ReplaceAllThemes(bool isDark)
    {
        foreach (var @ref in _themes)
        {
            if (@ref.TryGetTarget(out var themeRef))
                themeRef.Value = CreateTheme(isDark);
        }
    }
    
    private ITheme CreateTheme(bool isDark)
    {
        return isDark ? new DarkTheme() : new LightTheme();
    }
}

// Classe "wrapper"
public class Ref<T>
{
    public T Value { get; set; }
    
    public Ref(T value)
    {
        Value = value;
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