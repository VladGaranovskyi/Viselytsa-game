using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    string[] words = new string[20] {"king", "history", "apple", "restaurant", "money", "game", "cringe", "programmer", "smart", "people", "room", "street", "district", "matrix", "vector", "rotation", "transformation", "high", "low", "price"};
    Random rnd = new Random();
    string givenWord = words[rnd.Next(0, 19)];
    string currentWord = "";
    for(int i = 0; i < givenWord.Length; i++) currentWord += "_";
    int guesses = 10;
    while(true){
      Console.WriteLine(currentWord);
      Console.WriteLine("Enter the key");
      char letter = Console.ReadKey().KeyChar;
      List<int> right_indexes = GetLetterInWord(letter, givenWord); 
      if(right_indexes.Count == 0){
        Console.WriteLine();
        Console.WriteLine($"{--guesses} - guesses remain");
        Console.WriteLine("You are wrong");
        if(guesses <= 0){
          Console.WriteLine("You have lost!((((((");
          break;
        }
        Console.WriteLine();
        continue;
      }
      else{
        char[] char_arr = currentWord.ToCharArray();
        for(int i = 0; i < right_indexes.Count; i++){
          char_arr[right_indexes[i]] = letter;
        }
        currentWord = new string(char_arr);
        Console.WriteLine();
        if(currentWord == givenWord){
          Console.WriteLine("You have won");
          Console.WriteLine(givenWord);
          break;
        }
        continue;
      }
    }
  }

  private static List<int> GetLetterInWord(char letter, string givenWord){
    char[] arr = givenWord.ToCharArray();
    List<int> indexes = new List<int>();
    for(int i = 0; i < givenWord.Length; i++){
      if(letter == arr[i]) indexes.Add(i);
    }
    return indexes;
  }
}