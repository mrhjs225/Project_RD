using UnityEngine;
using System.Collections;

public class BackgroundControl : MonoBehaviour {
	
	// Background와 Foreground의 Animator를 등록시킬 변수
	// public으로 선언된 변수는 인스펙터 뷰(Inspector View)에서 접근과 수정이 가능합니다.
	public Animator[] mBackgrounds;
	
	void Start()
	{	
		// 객채가 활성화 되고 1번 호출 됨.
		FlowControl(0);	
	}
	
	public void FlowControl(float speed)
	{
		// 등록된 모든 애니메이터들의 speed를 조정
		foreach(Animator bg in mBackgrounds)
			bg.speed = speed;
	}
}