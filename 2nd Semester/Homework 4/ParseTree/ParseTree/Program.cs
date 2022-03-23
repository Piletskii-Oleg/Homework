// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ParseTree.Node tree = ParseTree.Tree.CreateTree("(*(+ 1 2 ) 3 )");
ParseTree.Tree.PrintTree(tree);