using SentencesGenerator;
using System.Collections.Generic;


// See https://aka.ms/new-console-template for more information




var sentences = SentenceManagement.SeparateIntoSentences(BookManagement.TxtToString());


sentences.RemoveAll(x => string.IsNullOrEmpty(x));

foreach(var sent in sentences)
{
    Console.WriteLine(sent);
}

File.WriteAllLines("D:\\Projects\\Books\\sentences.txt", sentences);
