using UnityEngine;
using System.Collections;

public class bullet_controller : MonoBehaviour {

	public float speed = 10.0f;
	private Vector3 moveDirection;
	
	void Start () {
		moveDirection = transform.rotation * new Vector3(1.0f, 0.0f, 0.0f);
	}

	void Update () {
		transform.Translate(moveDirection * Time.deltaTime * this.speed);
	}
}
