using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Range(1, 10)]
    public float _smoothFactor;
    public Transform _target;
    public Vector3 _offset;
    public Vector3 _minValues, _maxValues;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 _targetPosition = _target.position + _offset;
        
        Vector3 _boundPosition = new Vector3(
            Mathf.Clamp(_targetPosition.x,_minValues.x,_maxValues.x),
            Mathf.Clamp(_targetPosition.y, _minValues.y, _maxValues.y),
            Mathf.Clamp(_targetPosition.z, _minValues.z, _maxValues.z));
        
        Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _boundPosition, _smoothFactor*Time.fixedDeltaTime);
        transform.position = _smoothedPosition;
    }
}
