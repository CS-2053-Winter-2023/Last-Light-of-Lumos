using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaneScript : MonoBehaviour
{   
    public LBController lbS;
     public GameObject lb;
      public GameObject bullet;
      bool canFire;
      public int reloadTime;
    // Start is called before the first frame update
    void Start()
    {   canFire=true;
        lbS= lb.GetComponent<LBController>();
    }

    // Update is called once per frame
    void Update()
    {   float dist= Vector3.Distance(transform.position, lb.transform.position);
        if(dist<22&&canFire){
            GameObject b= Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
            Vector3 dirVec= transform.position- lb.transform.position;
            b.GetComponent<BulletController>().InitPosition(transform.position, new Vector3(dirVec.x, dirVec.y, 0f));
            
            canFire=false;
            StartCoroutine(FireAgain());
        }
    }

   public IEnumerator FireAgain(){
       
        yield return new WaitForSeconds(reloadTime);
        canFire=true;
       
    }

}
