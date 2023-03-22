using Microsoft.VisualBasic.FileIO;
using System.Text;

StringDelegate del = new StringDelegate(ConcatWords);

Char firstChar = "potato".First(c => c == 't');

Console.WriteLine(del("Potato", 50));

del = TruncateWord;

Console.WriteLine(del("Potato", 3));





string ConcatWords(string word, int repetitions)
{
    StringBuilder stringBuilder= new StringBuilder();

    for(int i = 0; i < repetitions; i++)
    {
        stringBuilder.Append(word);
    }

    return stringBuilder.ToString();
}

string TruncateWord(string word, int charsTruncated)
{
    // potato, 3
    //      
    if(word.Length >= charsTruncated)
    {
        return word.Substring(0, word.Length - (charsTruncated + 1));
    }
    else
    {
        return "";
    }
}

delegate string StringDelegate(string wordArg, int numArg);