using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public int dmg = 10;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		transform.Translate(Vector3.up * Time.deltaTime * 10f);
	}
}
