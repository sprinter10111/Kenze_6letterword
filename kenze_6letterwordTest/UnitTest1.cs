using System.Collections.Generic;
using System.Reflection;
using kenze_6letterword;

namespace kenze_6letterwordTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodReadLinesFile()
        {

            string codeBase = Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(codeBase);
            string parentPath = Directory.GetParent(appPath).FullName;
            parentPath = Directory.GetParent(parentPath).FullName;
            parentPath = Directory.GetParent(parentPath).FullName;

            var path = Path.Combine(parentPath, "testfile.txt");
            
           
            List <string> stringlistmethod = Program.ReadLinesFile(path);
            
            List<string> stringlistmanual = new List<string> { "foo", "iets", "go", "gje" };
            CollectionAssert.AreEqual(stringlistmethod, stringlistmanual);


        }
        [TestMethod]
        public void TestMethodGetCombinationsWords()
        {
            List<string> stringlistmanual = new List<string> { "foo", "bar", "go", "egje","foobar","yeet","idk","goyeet","yeetgo" };
            List<string> resultmanual= new List<string> {  "foobar", "goyeet","yeetgo" };
            List<string> result= Program.GetCombinationsWords(stringlistmanual);
            CollectionAssert.AreEqual(result, resultmanual);

        }


    }
}