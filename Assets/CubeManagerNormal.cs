using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManagerNormal : MonoBehaviour {

	public GameObject cube;

	public int x = 10;
	public int z = 10;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < x * z; ++i) {
			var entity = GameObject.Instantiate(cube, new Vector3(1.0f * (i % x), 0.0f, 1.0f * (i / x)), Quaternion.identity);
			entity.transform.SetParent(gameObject.transform);
			var mover = entity.GetComponent<CubeMoverNormal>();
			mover.x = i % x;
			mover.z = i / x;
		}
	}
}
