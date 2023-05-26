namespace WinFormsApp
{
    // TODO: rename(+)

    /// <summary>
    /// Class ChangeDot.
    /// </summary>
    internal static class Tools
    {
        /// <summary>
        /// Dot are chanded to comma.
        /// </summary>
        /// <param name="str">string from textbox.</param>
        /// <returns>Correct string.</returns>
        internal static string DotToComma(this string str)
        {
            return str.Replace(".", ",");
        }
    }
}
