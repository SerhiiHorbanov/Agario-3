using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

partial struct AIControllerSystem : ISystem
{
	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		foreach ((RefRW<AIController> controller, RefRW<CharacterMovement> movement) in SystemAPI.Query<RefRW<AIController>, RefRW<CharacterMovement>>())
		{
			movement.ValueRW.Velocity = controller.ValueRO.Direction;
			float redirectionTime = controller.ValueRO.LastRedirectionTime + (1 / controller.ValueRO.RedirectioningFrequency);
			
			if (SystemAPI.Time.ElapsedTime < redirectionTime)
				continue;
			
			float directionAngle = UnityEngine.Random.value * math.TAU;
			float2 direction = new(math.cos(directionAngle), math.sin(directionAngle));
			
			controller.ValueRW.Direction = direction;
			movement.ValueRW.Velocity = controller.ValueRO.Direction;
			controller.ValueRW.LastRedirectionTime = (float)SystemAPI.Time.ElapsedTime;
		}
	}
}
