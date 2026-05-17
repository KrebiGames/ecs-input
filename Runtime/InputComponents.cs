using Friflo.Engine.ECS;
using UnityEngine.InputSystem;

namespace ECS.Input {
	public struct PlayerId : IComponent { public int Value; }

	public struct Action : IComponent { public InputAction Value; }

	public struct ButtonAction : ITag { }

	public struct WasPressedThisFrame : ITag { }
	public struct IsPressed : ITag { }
	public struct WasReleasedThisFrame : ITag { }
}