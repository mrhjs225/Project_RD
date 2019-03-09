﻿using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour {
	
	private MonsterControl mMonster;
	public BoxCollider mCollider;
	void Start()
	{
		// Arrow오브젝트의 Box Collider를 가져옵니다.
		mCollider = gameObject.GetComponent<BoxCollider>();	
	}
	public void Shoot(MonsterControl monster)
	{
		mMonster = monster;
		Vector2 randomPos = Random.insideUnitCircle * 0.2f;
		iTween.MoveTo(gameObject, iTween.Hash("position", monster.transform.position + new Vector3(randomPos.x, randomPos.y, 0), 
												"easetype", iTween.EaseType.easeOutCubic, "time", 0.3f));
	}
	
	void OnTriggerEnter(Collider other)
	{
		// 몬스터 충돌체(Collider)와 충돌 시 충돌 정보가 전달 됩니다.
		if(other.name == "monster")
		{
			mCollider.enabled = false;
			mMonster.Hit(transform.position);

			// 화살 오브젝트를 0.07초 후 파괴합니다.
			Destroy(gameObject, 0.07f);
		}
	}
}
