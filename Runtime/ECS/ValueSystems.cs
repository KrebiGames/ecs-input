using ECS.Core;
using Friflo.Engine.ECS.Systems;
using UnityEngine;

namespace ECS.Input {
	public class InputValue2System : QuerySystem<Action, Value2> {
		protected override void OnUpdate() {
			foreach (var (actions, values, entities) in Query.Chunks)
				for (int e = 0; e < entities.Length; e++)
					values[e].Value = actions[e].Value.ReadValue<Vector2>();
		}
	}
}