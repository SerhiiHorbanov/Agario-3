using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerECSBridge _PlayerECSBridge;

	private ActionMaps _actionMaps;
	
	private void Start()
	{
		_actionMaps = new();
		_actionMaps.Gameplay.Enable();
	}

	private void Update()
	{
		Vector2 dir = _actionMaps.Gameplay.MovementDirection.ReadValue<Vector2>();
		
		PlayerInputData playerInputData = new()
		{
			Direction = dir,
		};
		
		_PlayerECSBridge.SetInputData(playerInputData);
	}
}
