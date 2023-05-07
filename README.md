# Wenli.IEM
这是一个简单C#版中文输入法，支持五笔输入、拼音输入。

测试的时候，请关闭360等相关安全软件或加为可信


<h3>拼音输入</h3>

<img src="https://github.com/yswenli/Wenli.IEM/blob/master/1.png?raw=true"/>


<h3>五笔输入</h3>

<img src="https://github.com/yswenli/Wenli.IEM/blob/master/2.png?raw=true"/>

## copy0401 備註

可利用 

Wenli.IEM.Helper.Generate.GenerateFile()

將路徑 Application.StartupPath + "\\汉字拼音对照表.txt" 

的文件轉換為   Application.StartupPath + "\\Win32\\pinyin.dll"

汉字拼音对照表.txt 內容格式為  中文字串+空格+編碼

例如:

對 a

寸 aa

丶 aa

丶 aav

<img src="https://github.com/copy0401/Wenli.IEM/blob/master/3.png?raw=true"/>

目前當 pinyin.dll 不存在時

會由 汉字拼音对照表.txt 的內容

產生 pinyin.dll 