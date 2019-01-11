using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Entities.Properties;
using Unity.Entities.Serialization;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Burst;

public struct CubeMoverPure : IComponentData {

	public int x, z;
}

public class MoverPureSystem : JobComponentSystem {
	float angle = 0.0f;

	[BurstCompile]
	private struct MoverJob : IJobProcessComponentData<CubeMoverPure, Position>{

		readonly float angle;

		public MoverJob(float angle) {
			this.angle = angle;
		}

		public void Execute(ref CubeMoverPure cube, ref Position position) {
			position.Value.y = math.sin(angle + cube.x) * math.sin(angle + cube.z);
		}
	}

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		var job = new MoverJob(angle += Time.deltaTime);
		return job.Schedule(this, inputDeps);
	}
}