using System.Drawing;

namespace DevToolz.Library.Extensions;

public static class ColorExtension
{
    public static bool IsTransparent( this Color color )
        => color == Color.Transparent;
}