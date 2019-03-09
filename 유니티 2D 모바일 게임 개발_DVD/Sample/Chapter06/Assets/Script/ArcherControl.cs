using UnityEngine;
using System.Collections;

public class ArcherControl : MonoBehaviour {
	
	// 아처의 Animator를 등록할 변수
	private Animator mAnimator; 
	
	// 배경들을 컨트롤할 BackgroundControl 스크립트를 등록할 변수
	private BackgroundControl mBackgrounds; 
	private BackgroundControl mForegrounds;
	
	// 화살이 발사되는 지점.
	[HideInInspector]
	private Transform mAttackSpot;
	
	// 아처의 체력, 공격력, 공격속도에 사용할 변수
	public int mOrinHp;
	[HideInInspector]
	public int mHp;
	
	public int mOrinAttack;
	[HideInInspector]
	public int mAttack;
	
	public float mAttackSpeed;
	
	// 화살 프리팹을 참조합니다.
	public Object mArrowPrefab;
	
	// 아처의 상태(대기, 달림, 공격, 사망)
	public enum Status
	{
		Idle,
		Run,
		Attack,
		Dead
	}
	// public으로 선언되었지만 인스펙터 뷰(Inspector View)에 노출되지 않기를 원할 경우 HideInInspector를 선언
	[HideInInspector]	
	public Status mStatus = Status.Idle; // 아처의 Default 상태를 Idle로 설정
	
	void Start () {
		mHp = mOrinHp;
		mAttack = mOrinAttack;
		// Archer의 Animator 컴포넌트 레퍼런스를 가져옵니다.
		mAnimator = gameObject.GetComponent<Animator>();
		// 계층 뷰(Hierache View)에 있는 게임 오브젝트의 컴포넌트 중 BackgroundControl 타입의 컴포넌트를 모두 가져옵니다.
		
		BackgroundControl[] component  = GameObject.FindObjectsOfType<BackgroundControl>();
		mBackgrounds = component[0];
		mForegrounds = component[1];
		
		// 자식(child) 게임 오브젝트 중 spot 이라는 이름의 오브젝트를 찾아 transform 컴포넌트의 레퍼런스를 반환합니다.
		mAttackSpot = transform.FindChild("spot");
	}
	
	// Update함수는 매 프레임 호출 됩니다.
	void Update () {
		// 키보드의 좌,우 화살표(혹은 A,D키)의 값을 가져옵니다.
		float speed = Mathf.Abs(Input.GetAxis("Horizontal"));
		SetStatus(Status.Run, speed);
		mBackgrounds.FlowControl(speed);
		mForegrounds.FlowControl(speed);
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			SetStatus(Status.Attack, 0);
		}
		else if(Input.GetKeyDown(KeyCode.F))
		{
			SetStatus(Status.Dead, 0);
		}
		else if(Input.GetKeyDown(KeyCode.I))
		{
			SetStatus(Status.Idle, 0);
		}
	}
	
	// 아처의 상태를 컨트롤 합니다.
	public void SetStatus(Status status, float param)
	{

		// 애니메이터에서 만든 상태간 전이(Transition)들을 상황에 맞게 호출합니다.
		switch(status)
		{
		case Status.Idle:
			mAnimator.SetFloat("Speed", 0);
			mBackgrounds.FlowControl(0);
			mForegrounds.FlowControl(0);
			break;
		case Status.Run:
			mBackgrounds.FlowControl(1);
			mForegrounds.FlowControl(1);
			mAnimator.SetFloat("Speed", param);		
			break;
		case Status.Attack:
			mAnimator.SetTrigger("Shoot");
			break;
		case Status.Dead:
			mAnimator.SetTrigger("Die");
			break;
		}

	}
	
	private void ShootArrow()
	{	
		// 화살 프리팹을 인스턴스화 합니다.
		GameObject arrow = Instantiate(mArrowPrefab, mAttackSpot.position, Quaternion.identity) as GameObject;
		// 화살 게임오브젝트의 컴포넌트에서 Shoot 함수를 호출합니다.
		arrow.SendMessage("Shoot");
	}
}
