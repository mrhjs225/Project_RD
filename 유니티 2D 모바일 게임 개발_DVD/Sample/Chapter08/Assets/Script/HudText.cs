using UnityEngine;
using System.Collections;

public class HudText : MonoBehaviour {
	
	public TextMesh mLabel;
	public TextOutline mOutline;
	public void SetHudText(string text, Color32 color, int size)
	{
		// 텍스트와 컬러 사이즈 값을 받아 텍스트 메쉬에 설정합니다.
		mLabel.text = text;
		mLabel.color = color;
		mLabel.fontSize = size;
	}
	
	private void invisible()
	{
		// TextOutline 컴포넌트의 dead함수를 호출하여 아웃라인을 제거합니다.
		mOutline.dead();	
	}
	
	private void dead()
	{
		// 이 게임오브젝트는 파괴됩니다.
		Destroy(gameObject);	
	}
}
