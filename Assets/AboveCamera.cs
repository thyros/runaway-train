using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveCamera : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	[Range (0.1f, 5)]
	public float followSpeed = 5;

	void Start() {
		transform.position = target.position + offset;
		transform.LookAt(target, Vector3.forward);
	}

	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
		transform.LookAt(target, Vector3.forward);
	}
}
