using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject sliderHp;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		sliderHp.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
	}
}
