# IceMap
スパジャム道場 2023

## 環境
* 2022.3.4f1
  * [x] Android Build Support
    * [x] Open JDK
    * [x] Android SDK & NDK Tools
  * [x] iOS Build Support

## 環境構築
* 本プロジェクトをクローンします。
* [環境](#環境) を参考に環境をインストールします。
* [Firebase 追加](https://firebase.google.com/docs/unity/setup?hl=ja#add-sdks) を参考に Firebase Unity SDK をインストールします。
  * [直リンク](https://firebase.google.com/download/unity?hl=ja)
  * `FirebaseAnalytics.unitypackage`
  * `FirebaseAuth.unitypackage`
  * `FirebaseFirestore.unitypackage`

## 開発のルール
コーディングするときのルール

1. Issues に自分がやることの最小単位を書きます。

Issue の書き方
```
Title: GPS を取得できるようにします (例)
Description: 参考 URL とか説明があれば
```

2. branch を切ります
参考は下
https://qiita.com/c6tower/items/fe2aa4ecb78bef69928f
```
追加機能を作る場合
feature/#1_get_gps
```
