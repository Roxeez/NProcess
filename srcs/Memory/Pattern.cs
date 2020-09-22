using System;

namespace NProcess.Memory
{
    /// <summary>
    ///     Represent a memory pattern
    /// </summary>
    public sealed class Pattern : IEquatable<Pattern>
    {
        /// <summary>
        ///     Create a new pattern
        /// </summary>
        /// <param name="content">Content of the pattern (format: A1 B7 ?? ?? ?? ?? B0 7E etc...)</param>
        /// <param name="offset">Offset of this pattern</param>
        public Pattern(string content, int offset = 0)
        {
            Content = content;
            Offset = offset;
        }

        public string Content { get; }
        public int Offset { get; }

        public bool Equals(Pattern other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Content == other.Content && Offset == other.Offset;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Pattern other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Content != null ? Content.GetHashCode() : 0) * 397 ^ Offset;
            }
        }
    }
}