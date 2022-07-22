using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovePath:MonoBehaviour
    {
        public enum PathType
        {
            linear,
            loop
        }
        public PathType _pathType;
        public int _moveTo = 0;
        public int _moveDirection;
        public Transform[] _pathElements;
        public void OnDrawGizmos()
        {
            if (_pathElements == null || _pathElements.Length < 2)
                return;
            for (int i = 1; i < _pathElements.Length; i++)
                Gizmos.DrawLine(_pathElements[i - 1].position, _pathElements[i].position);
            if(_pathType == PathType.loop)
                Gizmos.DrawLine(_pathElements[0].position, _pathElements[_pathElements.Length - 1].position);

        }
        public IEnumerator<Transform> GetNextPathPoint()
        {
            if (_pathElements == null || _pathElements.Length < 1)
                yield break;
            while (true)
            {
                yield return _pathElements[_moveTo];
                if (_pathElements.Length == 1)
                    continue;
                if(_pathType == PathType.linear)
                {
                    if (_moveTo <= 0)
                        _moveDirection = 1;
                    else if (_moveTo >= _pathElements.Length - 1)
                        _moveDirection = -1;
                }
                _moveTo = _moveTo + _moveDirection;
                if (_pathType == PathType.loop)
                {
                    if (_moveTo >= _pathElements.Length)
                        _moveTo = 0;
                    else if (_moveTo < 0)
                        _moveTo = _pathElements.Length - 1;
                }
            }
        }
    }
}
