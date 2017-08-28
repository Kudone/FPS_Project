using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	//射程を設定する。
	public float range = 40;

	//Raycastの衝突情報を入力するためのもの
	RaycastHit hit;

	public GameObject BulletPrefab;//弾丸のプレハブ

	public float speed = 50;
	// Update is called once per frame
	void Update () {


		//マウスをクリックした時一度だけ実行される。
		if(Input.GetMouseButtonDown(0)){
			//Raycastを発射する。
			Shots();
			DebugDrawRay();
		}
	}

	//Rayを表示するためのデバッグ機能
	void DebugDrawRay(){
		//画面中央のスクリーン座標を取得
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);

		//Raycastで飛ばす光線を作成(Mainカメラの中央部分から飛ばす)
		Ray ray = Camera.main.ScreenPointToRay(cameraCenter);

		//Rayを表示するためのデバッグ機能（Gameビューには表示されない）
		Debug.DrawRay(ray.origin, ray.direction*range);
		Debug.Log (hit.point);
		Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);

	}

	//攻撃(Raycast発射処理
	void Shots(){
		//画面中央のスクリーン座標を取得
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);

		//Raycastで飛ばす光線を作成(Mainカメラの中央部分から飛ばす)
		Ray ray = Camera.main.ScreenPointToRay(cameraCenter);

		//Raycastを上記で設定した光線でrange分の距離だけ飛ばす。
		if(Physics.Raycast(ray,out hit, range)){
			//Raycastで何かヒットしたら実行される。
			if(hit.transform.tag == "Enemy"){
				//Enemyタグの時のみ実行される。
				//Enemyタグを持つオブジェクトにDamage関数を実行する。
				hit.transform.SendMessage("Damage");
			}
		}
		GameObject effectObj = Resources.Load<GameObject> ("Effects/shotEffect");
		GameObject effect = Instantiate(effectObj, gameObject.transform.position, effectObj.transform.rotation);
		effect.transform.parent = gameObject.transform;

	}







  /* void Update(){
	//もしもクリックボタンが押されたら
	if(Input.GetMouseButtonDown(0)){
		Ray ray = new Ray (transform.position + Vector3(0,0,1.0), transform.forward);
		//RaycastHit hit;//ヒットした座標
		//銃の発射口のオブジェクトを変数に入れる
		var muzzle = transform.Find("muzzle");
		GameObject bul = Instantiate(BulletPrefab,muzzle.transform.position,transform.rotation); //弾を銃口の座標に生成
			bul.GetComponent<Rigidbody> ().velocity = ray * speed;
		if(Physics.Raycast(ray,hit,100.0)){//レイを飛ばしヒットしたら
			//ヒット座標に向かって弾を飛ばす
			bul.rigidbody.velocity = (hit.point - bul.transform.position).normalized * 50.0;
		}
		else{ //レイにヒットしなければ
			//射程距離の地点に向かって弾を飛ばす
			bul.rigidbody.velocity = (ray.GetPoint(100.0) - bul.transform.position).normalized * 50.0;
		}
	}
}*/
}
