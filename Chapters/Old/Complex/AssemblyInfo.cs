using System.Reflection;
using System.Runtime.CompilerServices;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("Mathematic Library")]
[assembly: AssemblyDescription("数学ライブラリ(複素数型サンプルのみ)")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Iwanaga Nobuyuki")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		

//
// アセンブリのバージョン情報は、以下の 4 つの属性で構成されます :
//
//      メジャー バージョン
//      マイナ バージョン 
//      ビルド番号
//      リビジョン
//
// 下にあるように、'*' を使って、すべての値を指定するか、 
// ビルドおよびリビジョン番号を既定値にすることができます :

[assembly: AssemblyVersion("1.0.*")]

//
// アセンブリに署名するには、使用するキーを指定しなければなりません。アセンブリ署名に関する 
// 詳細については、Microsoft .NET Framework ドキュメントを参照してください。
//
// 下の属性を使って、署名に使うキーを制御します。
//
// メモ : 
//   (*) キーが指定されないと、アセンブリは署名されません。
//   (*) KeyName は、コンピュータにインストールされている暗号サービス プロバイダ (CSP) を
//       表します。KeyFile は、キーを含む
//       ファイルです。
//   (*) KeyFile および KeyName の値が共に指定されている場合は、 
//       次の処置が取られます :
//       (1) KeyName が CSP に見つかった場合、そのキーが使われます。
//       (2) KeyName が存在せず、KeyFile が存在する場合、
//           KeyFile にあるキーが CSP にインストールされ、使われます。
//   (*) KeyFile を作成するには、sn.exe (Strong Name) ユーティリティを使ってください。
//       KeyFile を指定するとき、KeyFile の場所は、
//       プロジェクト出力 ディレクトリへの相対パスでなければなりません。パスは、
//       %Project Directory%\obj\<configuration> です。たとえば、KeyFile がプロジェクト ディレクトリにある場合、
//       AssemblyKeyFile 属性を 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")] として指定します。
//   (*) 遅延署名は高度なオプションです。詳細については Microsoft .NET Framework
//       ドキュメントを参照してください。
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
