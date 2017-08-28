using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour {

	const int SphereBulletFrequency = 3;
	//const int MaxshotPower = 30;
	const int RecoverySeconds = 3;
	const int BulletBox = 150;
	public int bulletbox = BulletBox;


	int sampleBulletCount;
	public int shotPower; //= MaxshotPower;
	AudioSource shotSounded;

	public GameObject bullets;
	public BulletHolder bulletHolder;

	public Camera playerCamera;
	//public Camera ZoomcCamera;
	//float speed = 50;

	//RaycastHit hit;

	//射程を設定する。
	public float range = 40;

	//Raycastの衝突情報を入力するためのもの
	public RaycastHit hit;

	void Start ()
	{
		shotSounded = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) {
			Shot ();
			Shots ();
			DebugDrawRay ();}

		RecoverPower ();
	}


	//Rayを表示するためのデバッグ機能
	void DebugDrawRay(){
		//画面中央のスクリーン座標を取得
		Vector3 cameraCenter = new Vector3 (Screen.width / 2, Screen.height / 2, 0);

		//Raycastで飛ばす光線を作成(Mainカメラの中央部分から飛ばす)
		Ray ray = playerCamera.ScreenPointToRay (cameraCenter);
		if (Physics.Raycast (ray, out hit, range)) {
			//Raycastで何かヒットしたら実行される。
			if (hit.transform.tag == "Enemy") {
				print ("hit");
				//Enemyタグの時のみ実行される。
				//Enemyタグを持つオブジェクトにDamage関数を実行する。
				hit.transform.SendMessage("Damage");
				Destroy (hit.collider.gameObject);

			}
		//Rayを表示するためのデバッグ機能（Gameビューには表示されない）
		Debug.DrawRay (ray.origin, ray.direction * range);

		Debug.Log (hit.point);
		Debug.DrawRay (ray.origin, ray.direction, Color.red, 3.0f);
	}
	}

	//攻撃(Raycast発射処理
	void Shots(){
		//画面中央のスクリーン座標を取得
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);

		//Raycastで飛ばす光線を作成(Mainカメラの中央部分から飛ばす)
		Ray ray = playerCamera.ScreenPointToRay(cameraCenter);

		//Raycastを上記で設定した光線でrange分の距離だけ飛ばす。
		if(Physics.Raycast(ray,out hit, range)){
		//Raycastで何かヒットしたら実行される。
			if(hit.transform.tag == "Enemy"){
				//Enemyタグの時のみ実行される。
				//Enemyタグを持つオブジェクトにDamage関数を実行する。
				//hit.transform.SendMessage("Damage");
				Destroy(hit.collider.gameObject);

		}
	


		/*bulletHolder.ConsumeBullet ();
		ConsumePower ();

		shotSound.Play ();*/
	}
	}
		

		

	/*void Damage(){
		HP -= 1;
		print (HP);
	}*/




	void Shot ()
	{
		if (bulletHolder.GetBulletAmount () <= 0)
			return;
		/*if (shotPower <= 0)
			return;*/
		/*Ray ray = new Ray(transform.position, transform.forward);
		if (Physics.Raycast (transform.position, Vector3.forward, out hit)) {

			Debug.Log (hit.point);
			Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
		}

		GameObject effectObj = Resources.Load<GameObject> ("Effects/shotEffect");
		GameObject effect = Instantiate(effectObj, gameObject.transform.position, effectObj.transform.rotation);
		effect.transform.parent = gameObject.transform;

		GameObject bullet2 = (GameObject)Instantiate (bullets,playerCamera.transform.position, Quaternion.identity);
		    Ray rayOrigin = playerCamera.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2, 0));
			Vector3 direction = rayOrigin.direction; 
			//掛けている20はBulletのスピードなので好きな数値を入力
	        bullet2.GetComponent<Rigidbody> ().velocity = direction * speed; */


		/*Vector3 cameraCenter = new Vector3 (Screen.width / 2, Screen.height / 2, 0);

		//Raycastで飛ばす光線を作成(Mainカメラの中央部分から飛ばす)
		Ray ray = playerCamera.ScreenPointToRay (cameraCenter);

		//Raycastを上記で設定した光線でrange分の距離だけ飛ばす。
		if (Physics.Raycast (ray, out hit, range)) {
			//Raycastで何かヒットしたら実行される。
			if (hit.transform.tag == "Enemy") {
				//Enemyタグの時のみ実行される。
				//Enemyタグを持つオブジェクトにDamage関数を実行する。
				//hit.transform.SendMessage("Damage");
				Destroy (hit.collider.gameObject);

			}*/
		bulletHolder.ConsumeBullet ();
		ConsumePower ();

		shotSounded.Play ();
			
	}

	

		

	void OnGUI ()
	{
		GUI.color = Color.red;

		string label = "BulletBox:" + bulletbox;


		GUI.Label (new Rect (850, 395, 150, 80), label);
	}

	void ConsumePower ()
	{
		shotPower++;
	}

	void RecoverPower ()
	{
		if (Input.GetKey (KeyCode.R)) {

			if (bulletbox >= shotPower) {
				bulletbox = bulletbox - shotPower;
				shotPower = 0;
			} else if (bulletbox < shotPower) {
				bulletbox = 0;
				shotPower = 0;
			} 
	}
}
}
