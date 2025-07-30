using Food;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class PlayerInputAuthoring : MonoBehaviour
{
	private class Baker : Baker<FoodValueAuthoring>
	{
		public override void Bake(FoodValueAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);
			PlayerInputData component = new();
			
			AddComponent(entity, component);
		}
	}
}

public struct PlayerInputData : IComponentData
{
	public float2 Direction;
}
