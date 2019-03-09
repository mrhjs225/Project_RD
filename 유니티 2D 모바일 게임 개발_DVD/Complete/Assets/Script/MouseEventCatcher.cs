using UnityEngine;
using System.Collections;

public class MouseEventCatcher : MonoBehaviour {

	// 메시지를 받을 게임오브젝트
	public GameObject mReceiver;
	// 실행할 메소드 명 
	public string mMethodName;
	public string mParams;
	
	void OnMouseDown()
	{
		mReceiver.SendMessage(mMethodName, mParams);	
	}
}
