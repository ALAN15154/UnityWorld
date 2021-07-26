using System.Collections;
using UnityEngine;
namespace Valve.VR.InteractionSystem.Sample;

public class ButtonCoconut : MonoBehavior
{
	public HoverButton hoverButton;

	public GameObject prefab;

	public void Start()
	{ hoverButton.onButtonDown.AddListener(OnButtonDown);

	
}
	private void OnButtonDown(Hand hand)
    {
		GameObject Coconut = GameObject.Instantiate<GameObject>(prefab);
		Coconut.transform.position = this.transform.position;
		Coconut.transform.rotation = Quaternion.identity;
    }
}
