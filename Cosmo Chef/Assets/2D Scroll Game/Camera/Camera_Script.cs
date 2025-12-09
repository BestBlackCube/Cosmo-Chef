using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, offset, 0.5f * 5f * Time.deltaTime);
    }
}
