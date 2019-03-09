using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestructShuriken : MonoBehaviour
{
	public bool OnlyDeactivate;
	
	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}
	
	IEnumerator CheckIfAlive ()
	{
		while(true)
		{	
			// 0.5초 간격으로 파티클이 살아 있는지 체크합니다.
			yield return new WaitForSeconds(0.5f);
			if(!particleSystem.IsAlive(true))
			{
				if(OnlyDeactivate)
				{
					this.gameObject.SetActive(false);
				}
				else
					GameObject.Destroy(this.gameObject);
				break;
			}
		}
	}
}
