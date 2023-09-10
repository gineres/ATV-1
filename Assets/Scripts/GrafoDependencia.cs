using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameActions
{
    GET_ORDER,
    GET_INGREDIENTS,
    PREPARE_FOOD,
    BAKE_FOOD,
    TAKE_OUT_FOOD,
    SERVE_FOOD
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
