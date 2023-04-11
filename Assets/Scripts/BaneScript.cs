using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaneScript : MonoBehaviour
{   
    public LBController lbS;
    public GameObject bullet;
    bool canFire;
    public int reloadTime;
    public AudioSource shootSound;
    // Start is called before the first frame update

    void Start()
    {   canFire=true;
        shootSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   
        if (lbS.death == 0){
            float dist= Vector3.Distance(transform.position, lbS.transform.position);
            if(dist<22 && canFire){
                shootSound.Play();
                GameObject b= Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
                Vector3 dirVec= transform.position- lbS.transform.position;
                b.GetComponent<BulletController>().InitPosition(transform.position, new Vector3(dirVec.x, dirVec.y, 0f));
            
                canFire=false;
                StartCoroutine(FireAgain());
            }
        }

    }

   public IEnumerator FireAgain(){
       
        yield return new WaitForSeconds(reloadTime);
        canFire=true;
       
    }

}
