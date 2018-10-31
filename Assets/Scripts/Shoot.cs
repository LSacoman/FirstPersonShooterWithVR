using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bulletSpawn;
    private bool isShooting;

	void Start () {
        isShooting= false;
	}
	
	void Update () {
        RaycastHit hit;
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.transform.forward, Color.green);

        if(Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hit, 100)){
            if (hit.collider.name.Contains("zombie")){
                if (!isShooting){
                    StartCoroutine("Fire");
                }
            }
        }
    }

    IEnumerator Fire(){
        isShooting = true;
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        bullet.transform.position = bulletSpawn.transform.position;
        bullet.transform.rotation = bulletSpawn.transform.rotation;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.transform.forward * 500f);
        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Play();

        Destroy(bullet, 1f);

        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
}
