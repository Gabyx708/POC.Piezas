// See https://aka.ms/new-console-template for more information
using POC.Piezas.Application.Implementation;
using POC.Piezas.Application.Interfaces;
using POC.Piezas.Infrastructure.Repositories;
using POC.Piezas.Models.BomAggregate;

Console.WriteLine("Hello, World!");

IBomItemRepository repositoy = new BomItemRepository();

Console.WriteLine("ingresa la ruta del fichero: ");
string filePath = @"C:\Users\Gabriel\Desktop\602 - Salchichera A.xlsx";

List<BomItem> listaBomItems = repositoy.GetItemsFromFile(filePath).ToList();

foreach (var item in listaBomItems)
{
    Console.WriteLine(item + "\n");
    Console.WriteLine($"\n TOTAL ELEMENTOS: {listaBomItems.Count}");
}

Console.WriteLine("\n------------------------\n");


IAssemblyFactory factory = new AssemblyFactory();

var assemblyTree = factory.CreateAssembly(listaBomItems);

IAssemblyTraversal traversal = new AssemblyTraversalGPT();

Console.WriteLine("\n------------------------\n");
Console.WriteLine("\n------------------------\n");


traversal.LevelOrderTraversal(assemblyTree);


Console.WriteLine("\n------------------------\n");
Console.WriteLine("\n------------------------\n");
