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
        return View["primary_confirmation.cshtml", newAnagram];
      };
      Get["/anagram/add_word"] = _ => {
        return View["add_word.cshtml", newAnagram];
      };
      // Post["/anagram/add_word"] = _ => {
      //   string secondaryWord = Request.Form["secondary-word"];
      //   newAnagram.AddWord(secondaryWord);
      //   return View["add_word.cshtml", newAnagram];
      // };
    }
  }
}
