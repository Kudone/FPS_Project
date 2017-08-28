using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : RayController
{
    //const int DefaultBulletAmount = 30;
	const int RecoveryBullet = 10;

	int bullet = 30;//DefaultBulletAmount;
	int bulletDown = 0;
	int bulletCount = 0;

	AudioSource ReroadSound;

	void Start ()
	{
		ReroadSound = GetComponent<AudioSource> ();
	}

	public void ConsumeBullet ()
	{
		if (bullet > 0)
			bullet--;
		bulletDown++;

		if (bulletDown > 150) {
			bulletCount++;
		}
	}

	public int GetBulletAmount ()
	{
		return bullet;
	}

	public void AddBullet (int amount)
	{
		bullet += amount;
	}

	void OnGUI ()
	{
		GUI.color = Color.red;
		string label = "Bullet : " + bullet  + "/30";
		GUI.Label (new Rect (850, 410, 150, 80), label);

	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.R)) {
			if (bullet < 30) {
				if (bulletDown <= 150 && bulletbox >= 1) {
					ReroadSound.Play ();
					bulletbox = 30;
					bullet = bulletbox;
				} else if (bulletDown > 150 && bulletbox >= 1) {
					ReroadSound.Play ();
					bullet = 30 - bulletCount;
				} else if (bulletDown >= 180 && bulletbox == 0) {
					bullet = 0;
				}
				
			}
		}
	}
}


