![](imgs/GeneralUpdate_h2.png)



# GeneralUpdate #

GeneralUpdate是一款基于.NET Standard2.0 MIT协议开源的跨平台应用程序自动升级组件。</br>

不依赖任何UI框架，减少更新产生的资源消耗，一键启动示例启动帮助您快捷为您的应用程序实现自动升级。

[English introduction](https://github.com/JusterZhu/GeneralUpdate/blob/master/README_en.md)

<!-- SHIELD GROUP -->

![](https://img.shields.io/github/license/JusterZhu/GeneralUpdate?color=blue)

![](https://img.shields.io/github/contributors/GeneralLibrary/GeneralUpdate)

![](https://img.shields.io/github/languages/top/GeneralLibrary/GeneralUpdate)

![](https://img.shields.io/badge/build-passing-brightgreen)

![](https://img.shields.io/badge/platform-linux%20%7C%20macos%20%7C%20windows-success.svg)

![](https://img.shields.io/badge/documentation-ready-brightgreen.svg)

![](https://img.shields.io/badge/sustainability-yes-brightgreen.svg)

![](https://img.shields.io/badge/contributions-welcome-brightgreen.svg)

![](https://img.shields.io/github/stars/GeneralLibrary/GeneralUpdate?style=social)

![](https://img.shields.io/github/forks/GeneralLibrary/GeneralUpdate)

**Share GeneralUpdate Repository**

[![Share on X](https://img.shields.io/badge/share%20on-X-1DA1F2.svg?style=social)](https://x.com/intent/post?hashtags=GeneralUpdate&text=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.&url=https://github.com/GeneralLibrary/GeneralUpdate)
[![Share on Telegram](https://img.shields.io/badge/share%20on-telegram-0088cc.svg?style=social)](https://telegram.me/share/url?url=https://github.com/GeneralLibrary/GeneralUpdate&text=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.)
[![Share on WhatsApp](https://img.shields.io/badge/share%20on-whatsapp-25D366.svg?style=social)](https://api.whatsapp.com/send?text=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.%20https://github.com/GeneralLibrary/GeneralUpdate)
[![Share on Reddit](https://img.shields.io/badge/share%20on-reddit-FF4500.svg?style=social)](https://www.reddit.com/submit?url=https://github.com/GeneralLibrary/GeneralUpdate&title=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.)
[![Share on Weibo](https://img.shields.io/badge/share%20on-weibo-EF4E39.svg?style=social)](https://service.weibo.com/share/share.php?url=https://github.com/GeneralLibrary/GeneralUpdate&title=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.)
[![Share on Mastodon](https://img.shields.io/badge/share%20on-mastodon-7857A4.svg?style=social)](https://mastodon.social/share/?text=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.&url=https://github.com/GeneralLibrary/GeneralUpdate)
[![Share on LinkedIn](https://img.shields.io/badge/share%20on-linkedin-0077B5.svg?style=social)](https://www.linkedin.com/sharing/share-offsite/?url=https://github.com/GeneralLibrary/GeneralUpdate&title=Share%20an%20open-source%20project%20that%20supports%20cross-platform%20and%20automatic%20client%20upgrades%20for%20any%20.NET%20UI%20technology.)

<sup>Unlimited Updates, Boundless Upgrades.</sup>

![](imgs\ui.png)

## 1.组件介绍 ##

**更新无限，升级无界。**

| 仓库                  | 说明                 | 地址                                                         |
| --------------------- | -------------------- | ------------------------------------------------------------ |
| GeneralUpdate         | 自动更新             | https://github.com/GeneralLibrary/GeneralUpdate<br />https://gitee.com/GeneralLibrary/GeneralUpdate<br />https://gitcode.com/GeneralLibrary/GeneralUpdate |
| GeneralUpdate.Maui    | Maui自动更新（安卓） | https://github.com/GeneralLibrary/GeneralUpdate.Maui<br />https://gitcode.com/GeneralLibrary/GeneralUpdate-Maui |
| GeneralUpdate.Tools   | 更新补丁包制作工具   | https://github.com/GeneralLibrary/GeneralUpdate.Tools<br />https://gitee.com/GeneralLibrary/GeneralUpdate.Tools<br />https://gitcode.com/GeneralLibrary/GeneralUpdate-Tools |
| GeneralUpdate-Samples | 使用示例             | https://github.com/GeneralLibrary/GeneralUpdate-Samples<br />https://gitee.com/GeneralLibrary/GeneralUpdate-Samples<br />https://gitcode.com/GeneralLibrary/GeneralUpdate-Samples |

帮助文档

- 官方网站： https://www.justerzhu.cn/
- 使用教程视频：https://www.bilibili.com/video/BV1c8iyYZE7P



功能介绍：

| 功能           | 是否支持 | 备注                                                         |
| -------------- | -------- | ------------------------------------------------------------ |
| 断点续传       | 支持     | 单次更新失败时，下次一次启动时继续上一次更新下载更新包内容。（引用组件默认生效） |
| 逐版本更新     | 支持     | 客户端当前版本如果与服务器相差多个版本，则根据多个版本的发布日期逐个更新。（引用组件默认生效） |
| 二进制差分更新 | 支持     | 对比新老版本通过差分算法生成补丁文件。（引用组件默认生效）   |
| 增量更新功能   | 支持     | 相比上一个版本只更新当前修改过的文件，并且删除当前版本不存在的文件。（引用组件默认生效） |
| 强制更新       | 支持     | 打开客户端之后直接强制更新。                                 |
| 多分支更新     | 支持     | 当一个产品有多个分支时，需要根据不同的分支更新对应的内容。   |
| 最新版本推送   | 支持     | 基于Signal R实现，推送当前最新版本。                         |
| 多语言         | 待验证   | 也可将本组件编写为控制台程序，作为更新“脚本”。更新其他语言的应用程序。 |
| 跳过更新       | 支持     | 支持注入弹窗让用户决定是否更新本次发布，服务端决定强制时更新不生效。 |
| 相互升级       | 支持     | 主程序可更新升级程序，升级程序可更新主程序。                 |
| 黑名单         | 支持     | 在更新过程中会跳过黑名单中的文件列表和文件扩展名列表。       |
| OSS            | 支持     | 极简化更新，是一套独立的更新机制。只需要在文件服务器中放置version.json的版本配置文件。组件会根据配置文件中的版本信息进行更新下载。 |
| 回滚、备份     | 支持     | 更新之前会将客户端本地文件备份，如果客户端启动失败或崩溃则回滚覆盖。 |
| 驱动更新       | 待验证   | 更新之前会将驱动备份到本地，如果客户端启动失败或崩溃则回滚覆盖。 |
| 自定义方法列表 | 支持     | 注入一个自定义方法集合，该集合会在更新启动前执行。执行自定义方法列表如果出现任何异常，将通过异常订阅通知。（推荐在更新之前检查当前软件环境） |
| AOT            | 支持     | 支持AOT编译发布。                                            |



## 2.支持框架

| .NET框架名称               | 是否支持 |
| -------------------------- | -------- |
| .NET Core 2.0              | 支持     |
| .NET 5 ... to last version | 支持     |
| .NET Framework 4.6.1       | 支持     |

| UI框架名称 | 是否支持              |
| ---------- | --------------------- |
| WPF        | 支持                  |
| UWP        | 商店模式下不可更新    |
| MAUI       | 目前仅支持Android平台 |
| Avalonia   | 支持                  |
| WinUI      | 支持                  |
| Console    | 支持                  |
| WinForms   | 支持                  |



## 3.操作系统

| 操作系统名称 | 是否支持 |
| ------------ | -------- |
| Windows      | 支持     |
| Android (.NET MAUI) | 支持 |
| 麒麟V10(飞腾S2500)  | 支持   |
| 麒麟V10(飞腾FT-2000)  | 支持   |
| 麒麟V10(x64)  | 支持   |
| Ubuntu 24.04.1 LTS | 支持 |
| 龙芯(Loongnix LoongArch 3A6000) | 支持 |
| 华为欧拉(EulerOS-鲲鹏Kunpeng) | 支持 |
| Apple Mac (M1) | 支持 |
| 统信UOS (x64) | 支持 |
