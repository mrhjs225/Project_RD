using UnityEngine;
using System.Collections;

public class RotateSimple : MonoBehaviour {
	// 각 축으로 회전될 스피드 값
	public float rotationSpeedX = 0;
	public float rotationSpeedY = 0;
	public float rotationSpeedZ = 0;
	
	void Update () {
		// 매 프레임 rotationSpeedX, rotationSpeedY, rotationSpeedZ 축으로 회전시킵니다.
		transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
	}
}
