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
	// 레이어 이름
	public Layers mLayerName;
	// 레이어 오더
	public int mOrderNumber = 0;
	void Start () {
		renderer.sortingLayerName = mLayerName.ToString();
		renderer.sortingOrder = mOrderNumber;
	}
}
