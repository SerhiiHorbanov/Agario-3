using Food;
using Unity.Entities;
using UnityEngine;

class CharacterAuthoring : MonoBehaviour
{
	private class Baker : Baker<FoodValueAuthoring>
	{
		public override void Bake(FoodValueAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);
			AddComponent(entity, new Character());
		}
	}
}

public struct Character : IComponentData
{ }
