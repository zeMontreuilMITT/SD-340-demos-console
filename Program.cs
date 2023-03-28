// verbatim string literal
using System.Xml.Serialization;

string path = @"C:\Users\zacharie.montreuil\source\repos\Fall2022\AdvancedC#\SD-340-demos-console\mySoapFile.dll";
// serialize into a Dynamic Link Library (DLL) file

XmlSerializer serializer = new XmlSerializer(typeof(MySerializedObject));

MySerializedObject obj = new MySerializedObject();

using(StreamWriter writer = new StreamWriter(path))
{
    serializer.Serialize(writer, obj);
}

public class MySerializedObject
{
    public string Name = "Object";
    public int Age = 50;
}



/* BINARY 
// 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

MySerializedObject obj = new MySerializedObject();
MySerializedObject second = new MySerializedObject();
second.Name = "Second Object";

// verbatim string literal
string path = @"C:\Users\zacharie.montreuil\source\repos\Fall2022\AdvancedC#\SD-340-demos-console\myFile2.bin";

IFormatter formatter = new BinaryFormatter();

// creating a scope for a service
using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
{
    formatter.Serialize(stream, second);
}

using(Stream deStream = new FileStream(path, FileMode.Open, FileAccess.Read))
{
    MySerializedObject deSerealized = (MySerializedObject)formatter.Deserialize(deStream);

    Console.WriteLine(deSerealized.Name);
}


    [Serializable]
    public class MySerializedObject
{
    public string Name = "Object";
    public int Age = 50;
}

*/

// SOAP vs REST
// Simple Object Access Protocol (eXstensible Markup Language)
// Used to transmit HTML (used in HTTP)
// SMTP (Simple Mail Transfer Protocol)
// More rigid than REST, generally slower, larger, higher over, legacy system
// Popular with large enterprise systems because of builtin security

/* <ul>
    <li>
    </li>
   </ul>

"ConnectionStrings": {
 "MyContextConnection": "localhost\etc"
}

<ConnectionStrings>
 <MyContextConnection>
   "Source=localhost/etc"
 </MyContextConnection>
</ConnectionStrings>

REpresentational State Transfer (JavaScript Object Notation)
*/

