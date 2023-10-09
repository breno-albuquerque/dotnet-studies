Console.WriteLine("World");

public class TreeType
{
    public string Name { get; set; }

    public string Color { get; set; }

    public string Texture { get; set; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Draw(int x, int y, Canvas onCanvas)
    {
       // Desenha o bitmap em uma tela nas coordenadas X e Y 
    }
}

public static class TreeFactory
{
    private static readonly List<TreeType> _treeTypes = new();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        var treeType = _treeTypes.Find(treeType =>
            treeType.Name == name 
            && treeType.Color == color 
            && treeType.Texture == texture)
                ?? new TreeType(name, color, texture);

        return treeType;
    }
}

public class Tree
{
    public int X { get; set; }
    public int Y { get; set; }
    public TreeType TreeType { get; set; }

    public Tree(int x, TreeType treeType)
    {
        X = x;
        TreeType = treeType;
    }

    public void Draw(Canvas onCanvas)
    {
        TreeType.Draw(X, Y, onCanvas);
    }
}

public class Canvas
{
}