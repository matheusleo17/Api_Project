using System.Diagnostics.CodeAnalysis;

namespace serverT2.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool NotEmpty([NotNullWhen(true)]this string? value) => string.IsNullOrEmpty(value).IsFalse();


    }
}
