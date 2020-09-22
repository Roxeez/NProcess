using System;

namespace NProcess.Module
{
    public sealed class Pattern : IEquatable<Pattern>
    {
        public string Content { get; }
        public int Offset { get; }
        
        public Pattern(string content, int offset = 0)
        {
            Content = content;
            Offset = offset;
        }
        
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
                return ((Content != null ? Content.GetHashCode() : 0) * 397) ^ Offset;
            }
        }
    }
}