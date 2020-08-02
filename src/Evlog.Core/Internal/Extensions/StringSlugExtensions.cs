using Slugify;
using System;

namespace Evlog.Core.Internal.Extensions
{
    internal static class StringSlugExtensions
    {
        private static readonly SlugHelper Slugifier = new SlugHelper();

        public static string Slugify(this string str)
        {
            if(str is null)
            {
                str = $"untitled-{Guid.NewGuid()}";
            }

            return Slugifier.GenerateSlug(str);
        }            
    }
}
