using Unity.Entities;
using UnityEngine;

namespace Food
{
	class FoodValueAuthoring : MonoBehaviour
	{
		[SerializeField] private float _FoodValue;
	
		private class Baker : Baker<FoodValueAuthoring>
		{
			public override void Bake(FoodValueAuthoring authoring)
			{
				Entity entity = GetEntity(TransformUsageFlags.None);
				FoodValue component = new() { Value = authoring._FoodValue };
			
				AddComponent(entity, component);
			}
		}
	}

	public struct FoodValue : IComponentData
	{
		public float Value;
	}
}