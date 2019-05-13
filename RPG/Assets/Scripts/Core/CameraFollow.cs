using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 positionDifference;
    // Start is called before the first frame update
    void Start()
    {
        var diferpositionDifferenceence = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + positionDifference;
    }
}
