using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform follow;
    public float followspeed = 1f;

    private void Update()
    {
        if (follow == null)
            return;

        Vector3 newPos = Vector3.Lerp(transform.position, follow.position, followspeed * Time.deltaTime);


        transform.position = newPos;
    }

    
}
