using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CubeMoverHybrid : MonoBehaviour {

	public int x, z;
}

public class MoverHybridSystem : ComponentSystem {
	private struct Group {
		public Transform transform;
		public CubeMoverHybrid cubeMover;
	}

	float angle = 0.0f;

	protected override void OnUpdate() {
		angle += Time.deltaTime;

		foreach (var entity in GetEntities<Group>()) {
			var pos = entity.transform.localPosition;
			entity.transform.localPosition = new Vector3(pos.x, Mathf.Sin(angle + entity.cubeMover.x) * Mathf.Sin(angle + entity.cubeMover.z), pos.z);

		}
	}
}