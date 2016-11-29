using System;
using System.Linq;
using System.Collections.Generic;

namespace Anagram.Objects
{
  public class AnagramCheck
  {
    private string _primaryWord;
    private string _secondaryWord;
    private List<string> _listWords = new List<string> {};
    private static List<AnagramCheck> _instances = new List<AnagramCheck> {};

    public void AddAnagramCheck()
    {
      _instances.Add(this);
    }

    public static AnagramCheck GetAnagramCheck()
    {
      return _instances[0];
    }

    public AnagramCheck(string firstWord, string secondWord)
    {
      _primaryWord = firstWord;
      _secondaryWord = secondWord;
    }

    public void SetPrimary(string firstWord)
    {
      _primaryWord = firstWord;
    }

    public string GetPrimary()
    {
      return _primaryWord;
    }

    public List<string> GetWordList()
    {
      return _listWords;
    }

    public void AddWord(string word)
    {
      _listWords.Add(word);
    }

    public bool AnagramChecker()
    {
      string[] primaryArrays = _primaryWord.ToCharArray().Select(c => c.ToString()).ToArray();
      string[] secondaryArrays = _secondaryWord.ToCharArray().Select(c => c.ToString()).ToArray();
      Array.Sort(primaryArrays);
      Array.Sort(secondaryArrays);

      if(primaryArrays.SequenceEqual(secondaryArrays))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public List<string> AnagramLister()
    {
      List<string> anagrams = new List<string> {};

      string[] primaryArrays = _primaryWord.ToCharArray().Select(c => c.ToString()).ToArray();
      Array.Sort(primaryArrays);
      string primaryString = String.Join("", primaryArrays);
      Console.WriteLine("primary: " + primaryString);
      foreach(string word in _listWords)
      {
        string[] secondaryArrays = word.ToCharArray().Select(c => c.ToString()).ToArray();
        Array.Sort(secondaryArrays);
        string secondaryString = String.Join("", secondaryArrays);
        Console.WriteLine("secondary: " + secondaryString);

        if(primaryString.IndexOf(secondaryString, StringComparison.CurrentCultureIgnoreCase) >= 0)
        {
          anagrams.Add(word);
        }
      }
      return anagrams;
    }
  }
}
