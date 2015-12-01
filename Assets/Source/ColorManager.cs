using UnityEngine;
using System.Collections.Generic;

public class ColorManager
{

    public static readonly List<Color> PresetColors = new List<Color>(){
        GetColorFromString("#F44336"),
        GetColorFromString("#E91E63"),
        GetColorFromString("#9C27B0"),
        GetColorFromString("#673AB7"),

        GetColorFromString("#3F51B5"),
        GetColorFromString("#2196F3"),
        GetColorFromString("#00BCD4"),
        GetColorFromString("#009688"),

        GetColorFromString("#4CAF50"),
        GetColorFromString("#8BC34A"),
        GetColorFromString("#FF9800"),

    };

    private List<Color> colors = new List<Color>();

    public void AddRandomColor()
    {
        if (colors.Count == PresetColors.Count) return;
        var addedColor = false;
        while (!addedColor)
            addedColor = AddColor(GetRandomPresetColor());
    }

    private static Color GetRandomPresetColor()
    {
        return PresetColors[Random.Range(0, PresetColors.Count)];
    }

    public Color GetRandomPresetColorNotAdded()
    {
        if (colors.Count == PresetColors.Count) return Color.clear;
        var addedColor = false;
        var color = Color.clear;
        while (!addedColor)
        {
            color = GetRandomPresetColor();
            addedColor = !colors.Contains(color);
        }
        return color;
    }

    public bool AddColor(Color color)
    {
        if (colors.Contains(color)) return false;
        GameController.Instance.CreateCatchZone(color);
        colors.Add(color);
        return true;
    }

    public Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    public static Color GetColorFromString(string colorString)
    {
        //remove the # at the front
        colorString = colorString.Replace("#", "");

        byte a = 255;
        byte r = 255;
        byte g = 255;
        byte b = 255;

        int start = 0;

        //handle ARGB strings (8 characters long)
        if (colorString.Length == 8)
        {
            a = byte.Parse(colorString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            start = 2;
        }

        //convert RGB characters to bytes
        r = byte.Parse(colorString.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
        g = byte.Parse(colorString.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
        b = byte.Parse(colorString.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }
}
