using UnityEngine;
using System.Collections;

public interface IPathConsumer {
    Transform transform { get; }

    //Navigation properties
    float MaximumSpeed { get; }
    float Acceleration { get; }
    float Deceleration { get; }
    float TurnRate { get; }
    float CurrentSpeed { get; set; }
}
