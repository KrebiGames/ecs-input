using Friflo.Engine.ECS;
using UnityEngine.InputSystem;

namespace ECS.Input {
	public static class InputExtensions {
		public static void BindButtonAction(this InputAction action, Entity entity) {
			SetTag<WasPressedThisFrame>(entity, action.WasPressedThisFrame());
			SetTag<IsPressed>(entity, action.IsPressed());
			SetTag<WasReleasedThisFrame>(entity, action.WasReleasedThisFrame());
		}

		static void SetTag<T>(Entity entity, bool state)
			where T : struct, ITag {
			if (state) {
				if (!entity.Tags.Has<T>())
					entity.AddTag<T>();
			} else {
				if (entity.Tags.Has<T>())
					entity.RemoveTag<T>();
			}
		}
	}
}