using Gaby.libs.tree;
using POC.Piezas.Application.Interfaces;
using POC.Piezas.Models.AssemblyAggregate;

namespace POC.Piezas.Application.Implementation
{
    public class AssemblyTraversalGPT : IAssemblyTraversal
    {
        public void LevelOrderTraversal(Assembly assembly)
        {
            GenericQueue<(Assembly Node, int Level)> queue = new GenericQueue<(Assembly, int)>();
            queue.Enqueue((assembly, 0)); // Agregamos el nodo raíz con nivel 0

            int currentLevel = 0;
            Console.WriteLine("Árbol de ensamblaje:");

            while (!queue.IsEmpty())
            {
                var (current, level) = queue.Dequeue();

                // Si es un nuevo nivel, imprimimos un salto de línea
                if (level != currentLevel)
                {
                    Console.WriteLine();
                    currentLevel = level;
                }

                // Imprimimos el nodo con indentación
                Console.Write(new string(' ', level * 4)); // Cada nivel agrega 4 espacios
                Console.WriteLine(current.GetName());

                // Encolamos los hijos con su nivel
                foreach (var child in current.GetParts())
                {
                    queue.Enqueue((child, level + 1));
                }
            }
        }

    }
}
