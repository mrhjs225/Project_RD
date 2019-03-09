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
