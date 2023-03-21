using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset = 10f;
    public float offsetSmoothing = 1;
    private Vector3 playerPosition;
    public LBController lb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + offsetSmoothing, transform.position.z);
        if(playerPosition.x >= -9 && playerPosition.x <= 98){
            if (player.transform.localScale.x > 0f){
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
            else{
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
    }

}
