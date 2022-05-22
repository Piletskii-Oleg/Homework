//var list = new SkipList.SkipList<int>();
//list.Add(30);
//list.Add(40);
//list.Add(50);
//list.Add(60);
//list.Add(70);
//list.Add(55);
//list.Add(65);
//list.Add(75);
//list.Add(80);
//list.Print();
//Console.WriteLine();
var newList = new SkipList.SkipList<int>(new List<int> { 6, 5, 4, 3, 2, 1 });

Console.WriteLine(newList.Count);
Console.WriteLine($"{newList.Contains(3)}, {newList.Contains(1)}, {newList.Contains(9)}");

newList.Print();
