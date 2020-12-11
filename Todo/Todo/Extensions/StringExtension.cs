namespace Todo.Extensions
{
    public static class StringExtension
    {
        public static bool HasContent(this string content) =>
            content?.Trim().Length > 0;
    }
}
