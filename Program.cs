// See https://aka.ms/new-console-template for more information
using DataStructures;

Console.WriteLine("Hello, World!");

LinkedArrayList<int> list = new LinkedArrayList<int>() {
    0, 1, 2, 3, 4, 5
};

// for (int i = 0; i < 200; i++) {
//     list.Add(i);
// }

foreach (int i in list) {
    Console.WriteLine(i);
}