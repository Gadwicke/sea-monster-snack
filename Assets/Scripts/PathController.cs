using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path
{
    public IPathConsumer Actor;
    private Queue<Vector2> Points = new Queue<Vector2>(30);

    public Vector2 GetNext()
    {
        return Points.Peek();
    }

    public Vector2 Consume()
    {
        return Points.Dequeue();
    }
}

public class PathController : MonoBehaviour {

    private List<Path> Paths = new List<Path>();

    public void Update()
    {
        for (int i = 0; i < Paths.Count; i++)
        {
            MoveAlong(Paths[i]);
        }
    }

    private void MoveAlong(Path path)
    {
        //Move the Actor for the path toward the next point if one exists
        //Accelerate/decelerate as appropriate
    }
}
