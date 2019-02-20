using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public float speed;
	public bool IsMoving = false;
	public bool isMoveKiri;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			// Vector3 move = transform.position;
			// move.x = Mathf.Clamp(move.x - speed, -16f, 16f);
			// transform.position = move;
			Move(true);
        }
		else if(Input.GetKey(KeyCode.D)){
            // Vector3 move = transform.position;
            // move.x = Mathf.Clamp(move.x + speed, -16f, 16f);
            // transform.position = move;
			Move(false);
		}
		if(!Application.isMobilePlatform && IsMoving) Move(isMoveKiri);
	}
	public void Move(bool kiri){
		isMoveKiri = kiri;
        Vector3 move = transform.position;
		if(kiri){
            move.x = Mathf.Clamp(move.x - speed, -16f, 16f);
		} else {
            move.x = Mathf.Clamp(move.x + speed, -16f, 16f);
		}
        transform.position = move;
	}
	public void SetMove(bool status){
		IsMoving= status;
	}
}
