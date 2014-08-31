using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour {
	public float MaximumSpeed = 1;
	public float Acceleration = 0.01f;
	public float Deceleration = 0.5f;
	public float TurnRate = 0.2f;
	private float CurrentSpeed = 0;

	private Queue<Vector3> Path = new Queue<Vector3>();

	public void AddNode(Vector3 Node)
	{
		Path.Enqueue(Node);
	}

	private void ConsumeNode()
	{
		Path.Dequeue();
	}

	private void Update()
	{
		//Remove nodes as we reach them
		if (transform.position == Path.Peek())
		{
			ConsumeNode();
		}

		Vector3 target = new Vector3();

		if (Path.Count == 0)
		{
			//Attenuate velocity
			CurrentSpeed -= Deceleration * Time.deltaTime;
			target = transform.position + transform.forward * 5;
		}
		else
		{
			//Follow the path to the next node
			target = Path.Peek();
			var targetDir = target - transform.position;
			var newDir = Vector3.RotateTowards(transform.forward, targetDir, TurnRate * Time.deltaTime, 0);
			transform.rotation = Quaternion.LookRotation(newDir);

			//Accelerate
			if (CurrentSpeed < MaximumSpeed)
				CurrentSpeed += Acceleration * Time.deltaTime;
		}

		transform.position = Vector3.MoveTowards(transform.position, target, CurrentSpeed * Time.deltaTime);
	}
}
