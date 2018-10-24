using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieWalk : MonoBehaviour {

    private Transform target;
    private NavMeshAgent agent;

	void Start () {
        target = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        GetComponent<Animation>().Play("walk");		
	}
	

    void OnTriggerEnter(Collider other)
    {
        GetComponent<SphereCollider>().enabled = false;
        Destroy(other.gameObject);

        agent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("back_fall");
        Destroy(gameObject, 6f);
        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;
        float randomX = UnityEngine.Random.Range(-12, 12);
        float randomZ = UnityEngine.Random.Range(-12, 12);

        zombie.transform.position = new Vector3(randomX, 0.1f, randomZ);

        while(Vector3.Distance(zombie.transform.position, target.position) <= 3)
        {
            randomX = UnityEngine.Random.Range(-12, 12);
            randomZ = UnityEngine.Random.Range(-12, 12);

            zombie.transform.position = new Vector3(randomX, 0.1f, randomZ);
        }
    }
}
