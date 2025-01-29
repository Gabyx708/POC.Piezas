using Gaby.libs.tree;
using POC.Piezas.Application.Interfaces;
using POC.Piezas.Models.AssemblyAggregate;

namespace POC.Piezas.Application.Implementation
{
    public class AssemblyTraversal : IAssemblyTraversal
    {
        public void LevelOrderTraversal(Assembly assembly)
        {
            GenericQueue<Assembly> queue = new GenericQueue<Assembly>(); 


            queue.Enqueue(assembly);

            int level = 0;

            while (!queue.IsEmpty())
            {

                int levelSize = queue.GetData().Count;

                Console.WriteLine($"\nLEVEL {level}:");


                for (int i = 0; i < levelSize; i++)
                {
                    Assembly current = queue.Dequeue();  

                    Console.WriteLine(current.GetName());  

                    // Encolar los hijos de la parte
                    foreach (var child in current.GetParts())
                    {
                        queue.Enqueue(child);
                    }
                }

                level++;
            }
        }

    }
}
