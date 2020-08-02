using Markdig;

namespace Evlog.Core.Internal.Extensions
{
    internal static class StringMarkdownExtensions
    {
        public static string RenderMarkdownAsHtml(this string markdown) =>
            Markdown.ToHtml(markdown);
    }
}
