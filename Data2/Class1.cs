using System;

namespace Data
{
    [Serializable]
    public class Class1
    {
        public const int Version = 1;

        public string SomeString;
        public int SomeInt;
        public Class1 Next;
        
        public override string ToString()
        {
            return SomeString + " " + SomeInt + " | "+Next?.ToString();
        }
    }
}
