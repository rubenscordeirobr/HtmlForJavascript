using System.Windows.Media;
using EnvDTE80;
using Microsoft.VisualStudio.PlatformUI;

namespace HtmlForJavascript
{
    internal static class ThemeColorHelper
    {
        public static bool IsLightTheme => ColorTheme == ColorTheme.Light;
        public static Color TextColor
        {
            get
            {
                System.Drawing.Color textColor = VSColorTheme.GetThemedColor(EnvironmentColors.ToolWindowTextColorKey);
                return Color.FromArgb(textColor.A, textColor.R, textColor.G, textColor.B);
            }
        }

        internal static ColorTheme ColorTheme
        {
            get
            {
                System.Drawing.Color bgColor = VSColorTheme.GetThemedColor(EnvironmentColors.ToolWindowBackgroundColorKey);
                var luminance = (bgColor.R * 0.2126) + (bgColor.G * 0.7152) + (bgColor.B * 0.0722);
                if (luminance > (255 / 2))
                {
                    return ColorTheme.Light;
                }
                return ColorTheme.Dark;
            }
        }
    }

    internal enum ColorTheme
    {
        Light,
        Dark
    }
}