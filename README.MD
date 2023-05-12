# ChatGptWebAzure

[English](./README_en.md)

## 简介

ChatGptWebAzure 是一个基于 Azure OpenAI API 实现的聊天机器人 Web 应用。前端是一个简单的 HTML5 页面，后端使用 .NET 6.0 实现。

## 主要功能：

* 与 ChatGPT 聊天，不需要翻墙，速度挺快
* 后端使用了 Azure OpenAI API
* 能记住历史对话，重启浏览器时自动恢复
* UI自适应，手机电脑都可以用

![image](https://github.com/kaedei/ChatGptWebAzure/assets/2949960/879da7bc-8745-4c7a-93b0-d761fc32e7a1)

## 使用方法

1. 打开 ChatGptWebAzure
2. 在输入框中输入你想要问的问题
3. 按下「发送消息」按钮或回车键
4. ChatGPT 会返回回答

## 本地部署

1. 安装 .NET 6.0 SDK
2. 克隆代码仓库: `git clone https://github.com/kaedei/ChatGptWebAzure.git`
3. 修改 appsettings.json 文件，将 Azure API Key 替换为你自己的
4. 安装依赖: `cd ChatGptWebAzure && dotnet restore`
5. 启动应用: `dotnet run`
6. 打开浏览器，访问 [http://localhost:5211](http://localhost:5211)

## 贡献

如果你发现了 Bug 或者有新功能想要添加，欢迎提交 issue 或者 pull request。

## 许可证

本项目使用 [MIT 许可证](./LICENSE)
