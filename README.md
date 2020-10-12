# UnityShooting
## 基本操作
* A/Dか左右キーで移動
* スペースキーで弾を発射
* Qで爆弾を発動

## ルール
* 落ちてくる敵を破壊する
* 破壊するとポイント加算
* 敵と接触するとHPが減る
* ○○○○するとゲームオーバー（未実装，仕様を考え中）
## そのほか
~~* 輝く爆弾を撃つと画面内の敵を一掃~~* 爆弾は当たることで最大3つまで取得できる
* 暫定的にHPの表現は徐々に背景に同化していく表現をしている
## シーン遷移
タイトル画面  
　　↓  
ゲーム画面 → ポーズ画面 → ゲーム終了  
　　↓  
ゲームオーバー画面 → リトライ → ゲーム画面  
~~↓　リトライ(No)~~
~~ゲーム画面~~ ゲーム終了    

~~※リトライ機能は未実装です~~  
2020/10/12 一部機能変更  
* 爆弾の仕様の変更を行いました
* ポーズ画面からゲーム終了を行うようにしました
