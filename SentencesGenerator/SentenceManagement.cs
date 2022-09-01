using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SentencesGenerator
{
    public static class SentenceManagement
    {
        public static string RemoveSpecialChars(string book)
        {
            book = Regex.Replace(book, "[^a-zA-Z0-9% .,’:?—]", string.Empty);

            return book;
        }
        public static List<string> SeparateIntoSentences(string book)
        {
            var originalWordList = BookManagement.ReturnOriginalWordList();
            book = RemoveSpecialChars(book);

            List<string> senteces = new List<string>();


            for (int i = 0; i < originalWordList.Length; i++)
            {               
                int startingIndex = 0;
                int endingIndex = 0;


                for (int j = book.IndexOf(originalWordList[i]); j != -1; j++)
                {                  
                    //check final index
                    if (book[j] == ',' || book[j] == '.' || book[j] == ':' || book[j] == '?' || book[j] == '—')
                    {                       
                        endingIndex = j;
                        j = -1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                for (int j = book.IndexOf(originalWordList[i]); j != -1; j--)
                {
                    
                    if (book[j] == ',' || book[j] == '.' || book[j] == ':' || book[j] == '?' || book[j] == '—')
                    {                       
                        startingIndex = j;
                        j = -1;
                        break;
                    }
                    else
                    {

                        continue;
                    }
                }
                string finalString = book.Substring(startingIndex +1 , endingIndex - startingIndex);
                senteces.Add(finalString.Trim());
                                                                  
            }
            return senteces;

        }
    }
}
