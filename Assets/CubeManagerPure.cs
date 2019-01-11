using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class CubeManagerPure : MonoBehaviour {

	public int x = 10;
	public int z = 10;

	private static EntityManager entityManager;
	private static EntityArchetype cubeArchetype;
	private static MeshInstanceRenderer cubeRenderer;

	// Use this for initialization
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Initialize () {
		entityManager = World.Active.GetOrCreateManager<EntityManager>();
		cubeArchetype = entityManager.CreateArchetype(typeof(Position), typeof(CubeMoverPure), typeof(Prefab));
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void InitializeWithScene() {
		var renderer = GameObject.FindObjectOfType<MeshInstanceRendererComponent>();
		if (renderer != null)
			cubeRenderer = renderer.Value;
	}

	void Start() {
		Entity cubeEntity = entityManager.CreateEntity(cubeArchetype);
		entityManager.AddSharedComponentData(cubeEntity, cubeRenderer);

		for (int i = 0; i < x * z; ++i) {
			var instance = entityManager.Instantiate(cubeEntity);

			entityManager.SetComponentData(instance, new Position { Value = new Vector3(1.0f * (i % x), 0.0f, 1.0f * (i / x)) });
			entityManager.SetComponentData(instance, new CubeMoverPure { x = (i % x), z = (i / x)});
		}
	}
}
