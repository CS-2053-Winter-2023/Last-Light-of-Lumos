using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector2 posOffset;
    public Vector3 startPos;
    public Vector3 endPos;
    public float leftLimit, rightLimit, topLimit, bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        startPos = transform.position;
        endPos = player.transform.position;
            endPos.x += posOffset.x;
            endPos.y += posOffset.y;
            endPos.z = transform.position.z;

            transform.position = Vector3.Lerp(startPos,endPos, timeOffset * Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), 
                                             Mathf.Clamp(transform.position.y, bottomLimit, topLimit), 
                                             transform.position.z);
    }
}
