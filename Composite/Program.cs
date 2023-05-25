using System.Threading.Channels;

Console.Title = "Composite";


var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.Directory("toplevel.txt", 100);
var topLevelDirectory1 = new Composite.Directory("topleveldirectory1", 4);
var topLevelDirectory2 = new Composite.Directory("topleveldirectory2", 4);

root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

var subLevelFile1 = new Composite.Directory("sublevel1.txt", 200);
var subLevelFile2 = new Composite.Directory("sublevel2.txt", 150);

topLevelDirectory2.Add(subLevelFile1);
topLevelDirectory2.Add(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");