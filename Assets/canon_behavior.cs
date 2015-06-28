using UnityEngine;
using System.Collections;

public class canon_behavior : MonoBehaviour {

	[Range(0.0f, 360.0f)]
	public float start_angle = 0.0f;
	[Range(0.0f, 360.0f)]
	public float end_angle = 180.0f;

	public float duration = 5.0f;
	public float rate_of_fire = 0.1f;

	private float current_angle;
	private float end_time;
	private Quaternion current_rotation;
	private Vector3 current_direction;

	private Quaternion start_rotation;
	private Quaternion end_rotation;

	private float coolDown;
	private float oldTime;

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		current_angle = this.start_angle;
		end_time = Time.time + duration;

		start_rotation = Quaternion.Euler(0.0f, 0.0f, start_angle / 2.0f);
		Debug.Log (start_rotation);
		end_rotation = Quaternion.Euler(0.0f, 0.0f, end_angle / 2.0f);
		Debug.Log (end_rotation);

		coolDown = rate_of_fire;
		oldTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time < end_time) {
			current_rotation = Quaternion.Lerp(start_rotation, end_rotation, Time.time / duration);
			coolDown -= Time.deltaTime;
			if(coolDown <= 0){
				Debug.Log(current_rotation);
				Object.Instantiate(bullet, transform.position, current_rotation);
				coolDown = rate_of_fire;
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (transform.position, 0.5f);

		Quaternion debug_start_rotation = Quaternion.Euler(0.0f, 0.0f, start_angle);
		Quaternion debug_end_rotation = Quaternion.Euler(0.0f, 0.0f, end_angle);

		//Debug.Log (debug_start_direction);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, debug_start_rotation * new Vector3(1.0f, 0.0f, 0.0f));
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, debug_end_rotation * new Vector3(1.0f, 0.0f, 0.0f));

	}
}
