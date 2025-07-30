using Unity.Mathematics;
using UnityEngine;

public class PlayerFollowingCamera : MonoBehaviour
{
	[SerializeField] private PlayerECSBridge _PlayerECSBridge;
	[SerializeField] private float _LerpStrength;
	
	[SerializeField] private Camera _Camera;
	[SerializeField] private float _MinCameraSize;
	private void Update()
	{
		Vector2 playerPos = _PlayerECSBridge.GetPlayerPosition();
		Vector2 cameraPos = transform.position;
		
		Vector2 newCameraPos = Vector2.Lerp(cameraPos, playerPos, _LerpStrength);
		
		transform.position = (Vector3)newCameraPos + (Vector3.forward * transform.position.z);
		
		_Camera.orthographicSize = math.max(_PlayerECSBridge.GetRadius(), _MinCameraSize);
	}
}
