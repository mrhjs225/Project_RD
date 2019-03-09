using UnityEngine;
using System.Collections;

public class LayerSort : MonoBehaviour {
	public enum Layers
	{
		Background,
		Foreground,
		Effect,
		UI
	}
	public Layers mLayerName;
	public int mOrderNumber = 0;
	void Start () {
		
		renderer.sortingLayerName = mLayerName.ToString();
		renderer.sortingOrder = mOrderNumber;
	}
}
