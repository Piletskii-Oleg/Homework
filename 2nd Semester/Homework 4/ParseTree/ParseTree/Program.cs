// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ParseTree.INode tree = ParseTree.Tree.CreateTree("( + ( * 3 4) ( + 1 ( * 4 5)))");
Console.WriteLine(ParseTree.Tree.CalculateValue(tree));
ParseTree.Tree.PrintTree(tree);