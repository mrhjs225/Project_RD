using UnityEngine;
using System.Collections;
//using UnityEditorInternal;
//using System.Reflection;
//using System.IO;

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
	/*
	public string[] GetSortingLayerNames() {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        return (string[])sortingLayersProperty.GetValue(null, new object[0]);
    }
	 */
	
}
