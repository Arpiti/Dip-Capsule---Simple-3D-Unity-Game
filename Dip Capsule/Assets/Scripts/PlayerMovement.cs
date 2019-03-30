using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float maxSpeed = 8f;
    private Vector3 input;
    private Vector3 spawn;
    public GameObject deathParticleSystem;



	// Use this for initialization
	void Start () {
        spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }

        if (transform.position.y < -1)
        {
            Die();
        }
       
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TightSpot")
            // Make sound and credits
            print("Reached Goal");
    }

    void Die()
    {
        Instantiate(deathParticleSystem, transform.position, Quaternion.Euler(270,0,0));

        transform.position = spawn;
    }

}