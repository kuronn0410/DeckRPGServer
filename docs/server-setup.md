ローカルサーバー作成〜exe化まで
1. .NET SDKが入っているか確認

コマンドプロンプトを開いて、

dotnet --version

今回の環境では、

10.0.401

と表示されたのでOK。

2. サーバープロジェクトを作る

作成したい場所へ移動してから、

dotnet new web -n DeckRPGServer

を実行する。

今回は最初に、

C:\Users\24rd179\DeckRPGServer

へ作成された。

生成される主なものは、

DeckRPGServer/
├ Program.cs
├ DeckRPGServer.csproj
├ Properties/
└ appsettings.json
3. プロジェクトフォルダへ移動
cd DeckRPGServer

現在地を確認したい場合は、

cd

を使う。

4. 開発用サーバーを起動
dotnet run

成功すると、

Now listening on: http://localhost:5082
Application started.

のように表示される。

この、

http://localhost:5082

がサーバーのアクセス先。

ブラウザから開いて Hello World! が表示されれば成功。

5. サーバーを停止する

サーバーを起動しているコマンドプロンプトで、

Ctrl + C

を押す。

これでサーバーが停止する。

6. 提出用にpublishする

プロジェクトフォルダ、

C:\Users\24rd179\DeckRPGServer

で、

dotnet publish -c Release -r win-x64 --self-contained true

を実行する。

それぞれ、

-c Release
→ 配布用のReleaseビルド

-r win-x64
→ Windows 64bit向け

--self-contained true
→ .NETが入っていないPCでも動かせるようにする

という意味。

7. publishフォルダを確認

今回なら、だいたいここに生成される。

C:\Users\24rd179\DeckRPGServer
└ bin
   └ Release
      └ net10.0
         └ win-x64
            └ publish

中には、

publish/
├ DeckRPGServer.exe
├ DeckRPGServer.dll
├ appsettings.json
├ 各種DLL
└ その他必要ファイル

が入っている。

重要

基本的には、

DeckRPGServer.exe

だけではなく、publishフォルダ全体をサーバーの実行ファイル一式として扱う。

8. publishだけ別の場所へ移す

今回は、

C:\YY\ゲーム制作\オンライン\DeckRPGServer\publish

へ移動した。

その中の、

DeckRPGServer.exe

を起動。

成功すると、

Now listening on: http://localhost:5000
Hosting environment: Production
Content root path:
C:\YY\ゲーム制作\オンライン\DeckRPGServer\publish

と表示された。

これで、

元のVisual Studio/.NETプロジェクト
        ↓ 切り離しても
publishフォルダだけで起動できる

ことを確認できた。

今回起きたエラー

一度、移動後のexeが起動しなかった。

原因は、別のサーバーがすでに、

localhost:5000

を使っていた可能性が高かった。

つまり、

サーバーA
→ 5000番ポート使用中

サーバーB
→ 5000番を使おうとする
→ Bind失敗

という状態。

前のサーバーを終了してから再度起動したら正常に動いた。

開発時と提出時の違い

今後はここが重要。

【開発元】

C:\Users\24rd179\DeckRPGServer

Program.csを編集
      ↓
dotnet run
      ↓
動作確認

機能が完成したら、

dotnet publish
      ↓
publishフォルダ生成
      ↓
提出用へコピー

という流れ。

publishフォルダの中のProgram.csを編集するわけではない。

最終的な提出イメージ
DeckRPG/
│
├ Game/
│  └ DeckRPG.exe
│
├ Server/
│  ├ DeckRPGServer.exe
│  ├ 各種DLL
│  ├ appsettings.json
│  └ ...
│
└ README.txt

READMEには例えば、

1. Server/DeckRPGServer.exe を起動してください。
2. サーバーを起動した状態でDeckRPGを起動してください。
3. ゲーム終了までサーバー画面を閉じないでください。