using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct CharacterEatingSystem : ISystem
{
	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		
		foreach (var (eaterTransform, eaterRadius, eater) 
		         in SystemAPI.Query<RefRO<LocalTransform>, RefRW<Radius>>().WithAll<Character>().WithEntityAccess())
		{
			float2 eaterPos2D = eaterTransform.ValueRO.Position.xy;
			
			foreach (var (eatenTransform, eatenRadius, eaten) 
			         in SystemAPI.Query<RefRO<LocalTransform>, RefRO<Radius>>().WithAll<Character>().WithEntityAccess())
			{
				if (eater == eaten)
					continue;
				if (eaterRadius.ValueRO.Value < eatenRadius.ValueRO.Value)
					continue;

				
				float2 eatenPos2D = eatenTransform.ValueRO.Position.xy;
				float distanceSquared = math.distancesq(eaterPos2D, eatenPos2D);
				
				float radii = eaterRadius.ValueRO.Value + eatenRadius.ValueRO.Value;
				float radiiSquared = radii * radii;
				
				if (distanceSquared > radiiSquared)
					continue;
				
				ecb.DestroyEntity(eaten);
				eaterRadius.ValueRW.Value += eatenRadius.ValueRO.Value;
			}
		}
	}
}
