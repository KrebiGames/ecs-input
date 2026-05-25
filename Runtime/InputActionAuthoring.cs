using Friflo.Engine.ECS;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Friflo.Engine.Unity;

namespace ECS.Input {
	[RequireComponent(typeof(PlayerInput))]
	public class InputActionAuthoring : MonoBehaviour {
		[SerializeField, GUIColor("@inputAction == null ? Color.red : Color.white")]
		private InputActionReference inputAction;

		[SerializeReference, HideIf("IsButton"), GUIColor("@valueTag == null ? new Color(1f, 0.3f, 0.3f) : Color.white")]
		private ITag valueTag;
		[SerializeReference, HideIf("IsButton"), GUIColor("@valueComponent == null ? new Color(1f, 0.3f, 0.3f) : Color.white")]
		private IComponent valueComponent;

		[SerializeReference, ShowIf("IsButton"), GUIColor("@buttonTag == null ? new Color(1f, 0.3f, 0.3f) : Color.white")]
		private ITag buttonTag;


		private bool IsButton()
			=> inputAction != null && inputAction.action != null && inputAction.action.type == InputActionType.Button;


		private void Start() {
			var playerInput = GetComponent<PlayerInput>();

			if (inputAction == null || inputAction.action == null) {
				Debug.LogError($"No InputAction assigned for '{name}'", this);
				return;
			}

			var action = playerInput.actions[inputAction.action.name];

			var entity = Input.Store.CreateEntity(
				new PlayerId { Value = playerInput.playerIndex },
				new Action { Value = action });

			if (IsButton()) {
				if (buttonTag == null) Debug.LogError($"No Button Tag assigned for '{name}'", this);
				else {
					entity.AddTag<Button>();
					entity.AddTag(buttonTag);
				}
			} else {
				if (valueTag == null || valueComponent == null) {
					Debug.LogError($"No Value Tag or Value Component assigned for '{name}'", this);
					return;
				}
				entity.AddTag(valueTag);
				entity.AddComponent(valueComponent);
			}

			Destroy(this);
		}
	}
}