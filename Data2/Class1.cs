using System;

namespace Data
{
    [Serializable]
    public class Class1
    {
        public const int Version = 2;

        public string SomeString;
        public Class1 Next;
        
        public override string ToString()
        {
            return SomeString + " " + "" + " | "+Next?.ToString();
        }
    }
}
