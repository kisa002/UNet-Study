using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthController : NetworkBehaviour
{
	const int maxHp = 100;

	[SyncVar(hook="SliderHpRefresh")]
	public int currentHp = 100;

	[SyncVar]
	public int value = 1000;

	[SerializeField]
	private Slider sliderHp;

	void Start ()
	{
		currentHp = maxHp;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			CmdChangeValue();
		}
	}

	[Command]
	public void CmdChangeValue()
	{
		value += 50;
		Debug.Log(value);
	}

	[Command]
	void CmdChangeHp(int ammount)
	{
		if(!isServer)
			return;
		
		currentHp += ammount;
		
		if(currentHp <= 0)
			Destroy(this.gameObject);
	}

	void SliderHpRefresh(int hp)
	{
		sliderHp.value = hp;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Bullet")
		{
			int dmg = - other.GetComponent<BulletController>().dmg;
			CmdChangeHp(dmg);

			Destroy(other.gameObject);
		}

		Debug.Log("HIT");
	}
}
