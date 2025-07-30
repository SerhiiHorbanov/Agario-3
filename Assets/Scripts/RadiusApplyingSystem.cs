using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct RadiusApplyingSystem : ISystem
{
	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		foreach ((RefRW<LocalTransform> transform, RefRO<Radius> radius) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Radius>>())
		{
			transform.ValueRW.Scale = radius.ValueRO.Value * 2;
		}
	}
}
