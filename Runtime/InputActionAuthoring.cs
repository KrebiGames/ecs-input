using Friflo.Engine.ECS;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Friflo.Engine.Unity;

namespace ECS.Input {
	[RequireComponent(typeof(PlayerInput))]
	public class InputActionAuthoring : MonoBehaviour {
		[SerializeField]
		[GUIColor("@inputAction == null ? Color.red : Color.white")]
		private InputActionReference inputAction;

		[SerializeReference]
		[GUIColor("@valueComponent == null ? new Color(1f, 0.3f, 0.3f) : Color.white")]
		[ShowIf("@inputAction != null && actionType != UnityEngine.InputSystem.InputActionType.Button")]
		private IComponent valueComponent;

		[SerializeReference]
		[GUIColor("@buttonComponent == null ? new Color(1f, 0.3f, 0.3f) : Color.white")]
		[ShowIf("@inputAction != null && actionType == UnityEngine.InputSystem.InputActionType.Button")]
		private ITag buttonComponent;

		[SerializeField, HideInInspector]
		private InputActionType actionType;

		private void OnValidate() {
			if (inputAction != null && inputAction.action != null)
				actionType = inputAction.action.type;
		}

		private void Start() {
			var playerInput = GetComponent<PlayerInput>();

			if (inputAction == null || inputAction.action == null)
				return;

			var action = playerInput.actions[inputAction.action.name];

			var entity = Input.Store.CreateEntity(
				new PlayerId { Value = playerInput.playerIndex },
				new Action { Value = action });

			if (actionType == InputActionType.Button) {
				if (buttonComponent != null && action.type == InputActionType.Button) {
					entity.AddTag(buttonComponent);
					entity.AddTag<ButtonAction>();
				}
			} else {
				if (valueComponent != null)
					entity.AddComponent(valueComponent);
			}

			Destroy(this);
		}
	}
}