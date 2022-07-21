using System;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public MovePath _path;
    [SerializeField] float speed;
    [SerializeField] float _maxDistance = .1f;
    private IEnumerator<Transform> _pointInPath;
    // Update is called once per frame
    private void Start()
    {
        _pointInPath = _path.GetNextPathPoint();
        _pointInPath.MoveNext();
        transform.position = _pointInPath.Current.position;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointInPath.Current.position, Time.deltaTime * speed);
        var distSquare = (transform.position - _pointInPath.Current.position).sqrMagnitude;
        if (distSquare < _maxDistance * _maxDistance)
            _pointInPath.MoveNext();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision other)
    {
        other.transform.SetParent(null);
    }
}
