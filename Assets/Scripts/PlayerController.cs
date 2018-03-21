using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public Slider sliderHp;

	void Start ()
	{
		if(!isLocalPlayer)
			enabled = false;
	}
	
	void Update ()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
		var v = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

		transform.Rotate(0, x, 0);
		transform.Translate(Vector3.forward * v);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			CmdShot();
		}
	}

	[Command]
	void CmdShot()
	{
		Debug.Log("Shot");

		GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		NetworkServer.Spawn(bullet);

		Destroy(bullet, 4f);
	}
}
