using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class CharacterMovementAuthoring : MonoBehaviour
{
	[SerializeField] private float2 _Velocity = float2.zero;

	private class Baker : Baker<CharacterMovementAuthoring>
	{
		public override void Bake(CharacterMovementAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			CharacterMovement component = new() { Velocity = authoring._Velocity };
			
			AddComponent(entity, component);
		}
	}
}

public struct CharacterMovement : IComponentData
{
	public float2 Velocity;
}
