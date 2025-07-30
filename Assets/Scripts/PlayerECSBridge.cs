using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerECSBridge : MonoBehaviour
{
	private Entity _playerEntity;
	
	private void Start()
	{
		var world = World.DefaultGameObjectInjectionWorld;
		var entityManager = world.EntityManager;
		NativeArray<Entity> entityArray = entityManager.CreateEntityQuery(typeof(PlayerInputData)).ToEntityArray(Allocator.Temp);
		_playerEntity = entityArray[0];
		entityArray.Dispose();
	}

	public void SetInputData(PlayerInputData playerInputData)
	{
		World world = World.DefaultGameObjectInjectionWorld;
		EntityManager entityManager = world.EntityManager;
		
		entityManager.SetComponentData(_playerEntity, playerInputData);
	}

	public Vector2 GetPlayerPosition()
		=> GetPlayerComponent<LocalTransform>().Position.xy;

	public float GetRadius()
		=> GetPlayerComponent<Radius>().Value;

	private T GetPlayerComponent<T>() where T : unmanaged, IComponentData
	{
		World world = World.DefaultGameObjectInjectionWorld;
		EntityManager entityManager = world.EntityManager;

		return entityManager.GetComponentData<T>(_playerEntity);
	}
}