using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ações baseadas no jogo Lemon Cake, onde o jogador tem diversos cursos de ação para poder atender aos clientes.

public enum GameActions
{
    GET_ORDER, // Se refere à ação de anotar os pedidos dos clientes.
    GET_INGREDIENTS, // Se refere à ação de juntar os ingredientes necessários. Nem toda receita do jogo requer que você busque os ingredientes.
    PREPARE_FOOD, // Se refere ao ato de preparar a comida. Toda receita precisa passar por esse estágio.
    BAKE_FOOD, // Se refere a colocar a comida no forno, nem toda receita passa por esse estágio.
    TAKE_OUT_FOOD, // Se refere ao ato de tirar a comida do forno.
    SERVE_FOOD // Se refere ao ato de servir a comida para o cliente.
}

public class GrafoDependencia : MonoBehaviour
{
    public Dictionary<GameActions, List<GameActions>> actionsGraph = new Dictionary<GameActions, List<GameActions>>();

    void Start()
    {
        // Add dependencies
        AddDependency(GameActions.GET_ORDER, GameActions.GET_INGREDIENTS);
        AddDependency(GameActions.GET_ORDER, GameActions.PREPARE_FOOD);
        AddDependency(GameActions.GET_INGREDIENTS, GameActions.PREPARE_FOOD);
        AddDependency(GameActions.PREPARE_FOOD, GameActions.BAKE_FOOD);
        AddDependency(GameActions.PREPARE_FOOD, GameActions.SERVE_FOOD);
        AddDependency(GameActions.BAKE_FOOD, GameActions.TAKE_OUT_FOOD);
        AddDependency(GameActions.TAKE_OUT_FOOD, GameActions.SERVE_FOOD);

        Debug.Log("Possible paths from getting an order to serving the food: ");
        FindPaths(GameActions.GET_ORDER, GameActions.SERVE_FOOD);    
    }

    public void AddDependency(GameActions dependent, GameActions dependency){
        if (!actionsGraph.ContainsKey(dependent))
        {
            actionsGraph[dependent] = new List<GameActions>();
        }
        if (!actionsGraph[dependent].Contains(dependency))
        {
            actionsGraph[dependent].Add(dependency);
        }
    }

    public void FindPaths(GameActions start, GameActions end)
    {
        HashSet<GameActions> visited = new HashSet<GameActions>();
        List<GameActions> currentPath = new List<GameActions>();
        FindPathsDFS(visited, currentPath, start, end);
    }

    public void FindPathsDFS(HashSet<GameActions> visited, List<GameActions> currentPath, GameActions current, GameActions end)
    {
        visited.Add(current);
        currentPath.Add(current);

        if (current == end)
        {
            Debug.Log(string.Join(" -> ", currentPath));
        }
        else
        {
            if (actionsGraph.ContainsKey(current))
            {
                foreach (var dependency in actionsGraph[current])
                {
                    if (!visited.Contains(dependency))
                    {
                        FindPathsDFS(visited, currentPath, dependency, end); // Update the current node here
                    }
                }
            }
        }

        visited.Remove(current);
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}
