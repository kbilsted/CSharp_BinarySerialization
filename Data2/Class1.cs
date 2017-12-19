using System;

namespace Data
{
    [Serializable]
    public class Class1
    {
        public const int Version = 4;

        public string SomeString;
        public int SomeInt;
        public bool? MoreBool;
        public Class1 Next;
        
        public override string ToString()
        {
            return SomeString + " " + SomeInt + MoreBool.HasValue + " | "+Next?.ToString();
        }
    }
}
