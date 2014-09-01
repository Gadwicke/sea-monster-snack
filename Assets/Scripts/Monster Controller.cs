using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour, IPathConsumer {

    new public Transform transform
    {
        get { return transform; }
    }

    [SerializeField]
    private float _maximumSpeed;
    public float MaximumSpeed
    {
        get { return _maximumSpeed; }
    }

    [SerializeField]
    private float _acceleration;
    public float Acceleration
    {
        get { return _acceleration; }
    }

    [SerializeField]
    private float _deceleration;
    public float Deceleration
    {
        get { return _deceleration; }
    }

    [SerializeField]
    private float _turnRate;
    public float TurnRate
    {
        get { return _turnRate; }
    }

    [SerializeField]
    private float _currentSpeed;
    public float CurrentSpeed
    {
        get
        {
            return _currentSpeed;
        }
        set
        {
            _currentSpeed = value;
        }
    }
}
