# CSharp_BinarySerialization
Showing binary serialization

have you ever seen this error?


```
Unhandled Exception: System.Runtime.Serialization.SerializationException: Unable to load type Data.Class1 required for deserialization.
   at System.Runtime.Serialization.ObjectManager.DoFixups()
   at System.Runtime.Serialization.Formatters.Binary.ObjectReader.Deserialize(HeaderHandler handler, __BinaryParser serParser, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
   at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream, HeaderHandler handler, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
   at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream)
   at BinarySerialization2.SerializeHelper`1.Deserialize(Byte[] bytes) in c:\users\kasper.graversen\source\repos\BinarySerialization2\BinarySerialization2\Program.cs:line 41
   at BinarySerialization2.Program.Main(String[] args) in c:\users\kasper.graversen\source\repos\BinarySerialization2\BinarySerialization2\Program.cs:line 20
```

This is an error you typically get when you choose to persist and later rehydrate a binary serialized object-graph 

https://docs.microsoft.com/en-us/dotnet/standard/serialization/serialization-concepts

- no change namespace 
- no move to a different assembly - despite the same namespace
+ move file around in the assembly
+ Add fields
+ remove fields
+ change assembly information version - both up and down
+ change a simple type to a larger type - eg. int -> long
- change simple types to same size int -> uint



moved to a different assembly

Unhandled Exception: System.Runtime.Serialization.SerializationException: Unable to load type Data.Class1 required for deserialization.
   at System.Runtime.Serialization.ObjectManager.DoFixups()
   at System.Runtime.Serialization.Formatters.Binary.ObjectReader.Deserialize(HeaderHandler handler, __BinaryParser serParser, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
   at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream, HeaderHandler handler, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
   at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream)
   at BinarySerialization2.SerializeHelper`1.Deserialize(Byte[] bytes) in c:\users\kasper.graversen\source\repos\BinarySerialization2\BinarySerialization2\Program.cs:line 41
   at BinarySerialization2.Program.Main(String[] args) in c:\users\kasper.graversen\source\repos\BinarySerialization2\BinarySerialization2\Program.cs:line 20

   
## .Net Core

for .net core there are a lot of other possibilities and caveats, eg 

from https://docs.microsoft.com/en-us/dotnet/standard/serialization/binary-serialization `The state of a UTF-8 or UTF-7 encoded object is not preserved if the object is serialized and deserialized using different .NET Framework versions`

