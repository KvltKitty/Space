using UnityEngine;
using System.Collections;

public class bullet_controller : MonoBehaviour {

	public float speed = 10.0f;
	public Camera camera;
	private Vector3 moveDirection;

	void Start () {
		moveDirection = transform.rotation * new Vector3(1.0f, 0.0f, 0.0f);
	}

	void Update () {

		Vector3 pos = this.camera.WorldToViewportPoint(transform.position);

		transform.Translate(moveDirection * Time.deltaTime * this.speed);

		if (pos.x < 0.0f || pos.x > Screen.width || pos.y < 0.0f || pos.y > Screen.height) {
			Destroy(gameObject);
		}
	}
}
