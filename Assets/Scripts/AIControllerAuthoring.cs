using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class AIControllerAuthoring : MonoBehaviour
{
	[SerializeField] private float _RedirectioningFrequency;

	private class Baker : Baker<AIControllerAuthoring>
	{
		public override void Bake(AIControllerAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			AIController component = new() { RedirectioningFrequency = authoring._RedirectioningFrequency };
			
			AddComponent(entity, component);
		}
	}
}

public struct AIController : IComponentData
{
	public float2 Direction;
	public float LastRedirectionTime;
	public float RedirectioningFrequency;
}