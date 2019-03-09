﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AutoSound : MonoBehaviour {
	
	public bool OnlyDeactivate;
	
	IEnumerator Start()
	{
		while(true)
		{
			// 0.5초 간격으로 오디오가 플레이 중인지 확인합니다.
			yield return new WaitForSeconds(0.5f);
			if(!audio.isPlaying)
			{
				// 오디오가 플레이 중이 아니라면 조건에 따라 비활성화 하거나 파괴합니다.
				if(OnlyDeactivate)
					gameObject.SetActive(false);
				else 
					Destroy(gameObject);
			}
		}
	}
}
