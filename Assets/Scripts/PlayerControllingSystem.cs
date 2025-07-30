using Unity.Burst;
using Unity.Entities;

partial struct PlayerControllingSystem : ISystem
{
	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		foreach (var (inputData, movement) in SystemAPI.Query<RefRO<PlayerInputData>, RefRW<CharacterMovement>>())
		{
			movement.ValueRW.Velocity = inputData.ValueRO.Direction;
		}
	}
}
