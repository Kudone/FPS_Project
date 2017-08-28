#pragma strict

public var BulletPrefab : GameObject;//弾丸のプレハブ

function Update(){
//もしもクリックボタンが押されたら
if(Input.GetMouseButtonDown(0)){
var ray = new Ray (transform.position + Vector3(0,0,1.0), transform.forward);
var hit: RaycastHit;//ヒットした座標
//銃の発射口のオブジェクトを変数に入れる
var muzzle = transform.Find("muzzle");
var bul : GameObject = Instantiate(BulletPrefab,muzzle.transform.position,transform.rotation); //弾を銃口の座標に生成

if(Physics.Raycast(ray,hit,100.0)){//レイを飛ばしヒットしたら
//ヒット座標に向かって弾を飛ばす
bul.GetComponent.<Rigidbody>().velocity = (hit.point - bul.transform.position).normalized * 50.0;
}
else{ //レイにヒットしなければ
//射程距離の地点に向かって弾を飛ばす
bul.GetComponent.<Rigidbody>().velocity = (ray.GetPoint(100.0) - bul.transform.position).normalized * 50.0;
}
}
}
