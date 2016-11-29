using Xunit;
using Anagram.Objects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Anagram
{
  public class AnagramTest
  {
    [Fact]
    public void IsAnagram_SecondWordIsAnagramOfFirst_true()
    {
      string firstWord = "bread";
      string secondWord = "beard";

      AnagramCheck newAnagram = new AnagramCheck(firstWord, secondWord);
      Assert.Equal(true, newAnagram.AnagramChecker());
    }

    [Fact]
    public void IsAnagram_SecondWordIsAnagramOfFirst_false()
    {
      string firstWord = "bread";
      string secondWord = "board";

      AnagramCheck newAnagram = new AnagramCheck(firstWord, secondWord);
      Assert.Equal(false, newAnagram.AnagramChecker());
    }

    [Fact]
    public void IsAnagram_ListOfWords_ReturnListOfAnagrams()
    {
      string mainWord = "bread";
      List<string> listOfWords = new List<string> { "beard", "bears", "drabe", "dearb", "dear", "pear", "brade" };

      AnagramCheck newAnagram = new AnagramCheck(mainWord, "");

      foreach(string word in listOfWords)
      {
        newAnagram.AddWord(word);
      }

      List<string> correctLists = new List<string> { "beard", "dearb", "drabe", "brade" };
      List<string> results = newAnagram.AnagramLister();
      correctLists.Sort();
      results.Sort();

      Assert.Equal(true, correctLists.SequenceEqual(results));
    }
    [Fact]
    public void IsAnagram_ListOfWordsWithWeirdCaps_ReturnListOfAnagrams()
    {
      string mainWord = "bread";
      List<string> listOfWords = new List<string> { "BeARd", "bEARs", "DRabe", "DEaRb", "DEAR", "pEAr", "brADe" };

      AnagramCheck newAnagram = new AnagramCheck(mainWord, "");

      foreach(string word in listOfWords)
      {
        newAnagram.AddWord(word);
      }

      List<string> correctLists = new List<string> { "BeARd", "DEaRb", "DRabe", "brADe" };
      List<string> results = newAnagram.AnagramLister();
      correctLists.Sort();
      results.Sort();

      Assert.Equal(true, correctLists.SequenceEqual(results));
    }
    // [Fact]
    // public void IsAnagram_ListOfWordsWithPartials_ReturnListOfAnagramsWithPartials()
    // {
    //   string mainWord = "bread";
    //   List<string> listOfWords = new List<string> { "BeARd", "bEARs", "DRabe", "DEaRb", "DEAR", "pEAr", "brADe" };
    //
    //   AnagramCheck newAnagram = new AnagramCheck(mainWord, "");
    //
    //   foreach(string word in listOfWords)
    //   {
    //     newAnagram.AddWord(word);
    //   }
    //
    //   List<string> correctLists = new List<string> { "BeARd", "DEaRb", "DRabe", "brADe", "DEAR" };
    //   List<string> results = newAnagram.AnagramLister();
    //   correctLists.Sort();
    //   results.Sort();
    //
    //   foreach(string anagram in results)
    //   {
    //     Console.WriteLine("anagrams: " + anagram);
    //   }
    //   Assert.Equal(true, correctLists.SequenceEqual(results));
    // }
  }
}
