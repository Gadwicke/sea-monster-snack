using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path
{
    public IPathConsumer Actor;
    private Queue<Vector2> Points = new Queue<Vector2>(30);

    public bool IsEmpty
    {
        get
        {
            return Points.Count <= 0;
        }
    }

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

    public float PointProximityThreshold = 1;

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
        var actor = path.Actor;

        //Remove nodes as we reach them
        if (Vector2.Distance(actor.transform.position, path.GetNext()) < PointProximityThreshold)
        {
            path.Consume();
        }

        Vector3 target = new Vector3();

        if (path.IsEmpty)
        {
            //Attenuate velocity
            actor.CurrentSpeed -= actor.Deceleration * Time.deltaTime;
            target = transform.position + transform.forward * 5;
        }
        else
        {
            //Follow the path to the next node
            target = path.GetNext();
            var targetDir = target - actor.transform.position;
            var newDir = Vector3.RotateTowards(actor.transform.forward, targetDir, actor.TurnRate * Time.deltaTime, 0);
            actor.transform.rotation = Quaternion.LookRotation(newDir);

            //Accelerate
            if (actor.CurrentSpeed < actor.MaximumSpeed)
                actor.CurrentSpeed += actor.Acceleration * Time.deltaTime;
        }

        actor.transform.position = Vector3.MoveTowards(actor.transform.position, target, actor.CurrentSpeed * Time.deltaTime);

    }
}