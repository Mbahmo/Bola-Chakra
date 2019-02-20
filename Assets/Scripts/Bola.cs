using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

	public Rigidbody rb;
	public bool sudahmantul;
	public Vector3 forcePower;
	// Use this for initialization
	void Start () {
        // rb.AddForce(new Vector3(500f, 500f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && !sudahmantul){
				forcePower.x = Random.Range(100, 200);
            	forcePower.y = Random.Range(100, 300);
				rb.AddForce(forcePower);
				sudahmantul = true;
		}
	}

	private void OnCollisionEnter(Collision collision){
		if(collision.transform.CompareTag("Brick")){
			Destroy(collision.gameObject);
			GameManager.instance.OnBrickDestroyed();
		}
	}
	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("DeadZone")){
			Respawn();
			GameManager.instance.OnBallDestroy();
		}
	}
	public void Respawn(){
		transform.position = new Vector3(1.26f, -11.16f, -2.64f);
        rb.velocity = Vector3.zero;//agar tidak jalan pas respawn
        sudahmantul = false;
	}
}
