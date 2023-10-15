using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 1f;
    public float width = 1f;
    private void Start()
    {
        startPosition = transform.position;
    }


    private void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * width;
        
        transform.position = new Vector3(x, 0, 0) + startPosition;
        
    }
}
