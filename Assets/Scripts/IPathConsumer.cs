using UnityEngine;
using System.Collections;

public interface IPathConsumer {

    //Navigation properties
    float MaximumSpeed { get; }
    float Acceleration { get; }
    float Deceleration { get; }
    float TurnRate { get; }
    float CurrentSpeed { get; }
}
