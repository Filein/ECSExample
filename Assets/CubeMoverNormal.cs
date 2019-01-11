using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoverNormal : MonoBehaviour {

	public int x, z;

	float angle;

	// Update is called once per frame
	void Update () {
		angle += Time.deltaTime;

		var pos = transform.localPosition;
		transform.localPosition = new Vector3(pos.x, Mathf.Sin(angle + x) * Mathf.Sin(angle + z), pos.z);
	}
}
