using Unity.Entities;
using UnityEngine;

class RadiusAuthoring : MonoBehaviour
{
    [SerializeField] private float _Radius = 1;
    
    private class Baker : Baker<RadiusAuthoring>
    {
        public override void Bake(RadiusAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            Radius component = new() { Value = authoring._Radius};
			
            AddComponent(entity, component);
        }
    }
}

public struct Radius : IComponentData
{
    public float Value;
}
