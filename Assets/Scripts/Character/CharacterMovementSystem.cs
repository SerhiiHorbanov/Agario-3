using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct CharacterMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> transform, RefRO<CharacterMovement> movement) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<CharacterMovement>>())
        {
            float2 deltaXY = movement.ValueRO.Velocity * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position += new float3(deltaXY, 0);
        }
    }
}
