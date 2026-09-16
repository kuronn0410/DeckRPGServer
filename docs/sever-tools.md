# SQLite 導入手順

## 目的

ASP.NET Core の `DeckRPGServer` から SQLite を利用できるようにし、
Entity Framework Core を使ってデータベースを作成する。

---

## 1. プロジェクトフォルダへ移動

```bat
cd /d "C:\YY\ゲーム制作\オンライン\DeckRPGServer"
2. SQLite 用パッケージを追加
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
役割

ASP.NET Core / Entity Framework Core から SQLite を利用するためのパッケージ。

3. ビルド確認
dotnet build

エラーが出なければ次へ進む。

4. Entity Framework Core のCLIツールを追加
dotnet tool install --global dotnet-ef
役割

以下のような dotnet ef コマンドを使用できるようにする。

dotnet ef migrations add
dotnet ef database update
5. EF Core の設計用パッケージを追加
dotnet add package Microsoft.EntityFrameworkCore.Design
役割

Migration の作成など、
Entity Framework Core の設計時処理に必要。

6. 再度ビルド確認
dotnet build
7. Migration を作成
dotnet ef migrations add InitialCreate
Migration とは

現在の C# 側のデータ構造を確認し、

「データベースにどのようなテーブルを作る必要があるか」

という変更内容を生成する仕組み。

例：

Player.cs
    ↓
DeckRPGDbContext.cs
    ↓
Migration

この時点では、まだ実際のデータベースへ反映されていない。

8. データベースへ反映
dotnet ef database update

Migration の内容を実際の SQLite データベースへ反映する。

成功すると、

deckrpg.db

などの SQLite データベースファイルが生成される。

全体の流れ
Microsoft.EntityFrameworkCore.Sqlite を追加
        ↓
dotnet build
        ↓
dotnet-ef をインストール
        ↓
Microsoft.EntityFrameworkCore.Design を追加
        ↓
dotnet build
        ↓
dotnet ef migrations add InitialCreate
        ↓
dotnet ef database update
        ↓
SQLite データベース作成
各ツール・コマンドの役割
名前	役割
Microsoft.EntityFrameworkCore.Sqlite	EF Core から SQLite を利用する
dotnet-ef	dotnet ef コマンドを利用できるようにする
Microsoft.EntityFrameworkCore.Design	Migration などの設計時処理に利用する
dotnet build	現在のコードが正常にビルドできるか確認する
dotnet ef migrations add InitialCreate	DB構造の変更内容を作成する
dotnet ef database update	Migration の内容を実際のDBへ反映する
現在の構成イメージ
DeckRPGServer/
├ Program.cs
├ DeckRPGServer.csproj
│
├ Models/
│  └ Player.cs
│
├ Data/
│  └ DeckRPGDbContext.cs
│
├ Migrations/
│  └ ...
│
└ deckrpg.db