using Anagram.Objects;
using System.Collections.Generic;
using System.Linq;
using System;
using Nancy;

namespace Anagram
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Post["/anagram"] = _ => {
        string primaryWord = Request.Form["primary-word"];
        AnagramCheck newAnagram = new AnagramCheck(primaryWord, "");
        newAnagram.AddAnagramCheck();
        return View["primary_confirmation.cshtml", newAnagram];
      };
      Get["/anagram/add_word"] = _ => {
        AnagramCheck selectedAnagram = AnagramCheck.GetAnagramCheck();
        return View["add_word.cshtml", selectedAnagram];
      };
      Post["/anagram/add_word"] = _ => {
        string secondaryWord = Request.Form["secondary-word"];
        AnagramCheck selectedAnagram = AnagramCheck.GetAnagramCheck();
        selectedAnagram.AddWord(secondaryWord);
        return View["add_word.cshtml", selectedAnagram];
      };
      Post["/anagram/check"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        AnagramCheck selectedAnagram = AnagramCheck.GetAnagramCheck();
        string primaryWord = selectedAnagram.GetPrimary();
        List<string> results = selectedAnagram.AnagramLister();

        model.Add("primary", primaryWord);
        model.Add("results", results);
        return View["checked_anagrams.cshtml", model];
      };
    }
  }
}
