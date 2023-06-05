using System.Reflection;

namespace kenze_6letterword
{
    public class Program
    {
        static void Main(string[] args)
        {

            string codeBase = Assembly.GetExecutingAssembly().Location;
            string appPath = Path.GetDirectoryName(codeBase);
            string parentPath = Directory.GetParent(appPath).FullName;
            parentPath = Directory.GetParent(parentPath).FullName;
            parentPath = Directory.GetParent(parentPath).FullName;
            
            var path = Path.Combine(parentPath, "input.txt");

            List<string> words = ReadLinesFile(path);
            GetCombinationsWords(words);



        }

        public static List<string> ReadLinesFile(string filePath)
        {
            List<string> words = new List<string>();           
            string[] lines = File.ReadAllLines(filePath);
            words.AddRange(lines);
            return words;
        }


        public static List<string> GetCombinationsWords(List<string> words)
        {
            List<string> WordCombination = new List<string> { };
            int wordlenght = 6;
            for (int i = 0; i < words.Count; i++)
            {

                for (int j = i; j < words.Count; j++)//j=i omdat er anders meerdere dezelfde woorden met elkaar vergeleken worden
                {

                    if (words[i].Count() + words[j].Count() == wordlenght)
                    {
                        string combinedword1= words[i] + words[j];
                        string combinedword2 = words[j] + words[i];
                        //te samen is het woord dus 6 letters lang
                        if ( words.Contains(combinedword1)&& !WordCombination.Contains(combinedword1))//zo zijn er geen duplicate woorden in de WordCombination 
                        {
                            //het woord bestaat in de array
                            WordCombination.Add(words[i] + words[j]);
                            Console.WriteLine(words[i] + "+" + words[j] + "=" + combinedword1);
                        }
                        if (words.Contains(combinedword2) && !WordCombination.Contains(combinedword2))//zo zijn er geen duplicate woorden in de WordCombination 
                        {
                            //het woord bestaat in de array maar met een andere vollegorde
                            WordCombination.Add(words[j]+ words[i] );
                            Console.WriteLine(words[j]+"+"+ words[i]+"="+ combinedword2);
                        }                        
                       }
                    }
                }
            return WordCombination;
        }

            

        }
    }
