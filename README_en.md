# ChatGptWebAzure

[中文](./README.md)

## Introduction

ChatGptWebAzure is a web application of a chatbot based on Azure OpenAI API. The frontend is a simple HTML5 page, and the backend is implemented using .NET 6.0.

## Main Features:

* Chat with ChatGPT without needing a VPN, with fast speed
* Backend uses Azure OpenAI API
* Remembers chat history and automatically restores it when the browser is restarted
* UI adapts to both mobile and computer screens

## Usage

1. Open ChatGptWebAzure
2. Type in the question you want to ask in the input box
3. Press the "Send Message" button or Enter key
4. ChatGPT will return an answer

## Local Deployment

1. Install .NET 6.0 SDK
2. Clone the code repository: `git clone https://github.com/kaedei/ChatGptWebAzure.git`
3. Modify the appsettings.json file to replace the Azure API Key with your own
4. Install dependencies: `cd ChatGptWebAzure && dotnet restore`
5. Start the application: `dotnet run`
6. Open a web browser and navigate to [http://localhost:5211](http://localhost:5211)

## Contribution

If you find a bug or want to add new features, please submit an issue or pull request.

## License

This project is licensed under the [MIT License](./LICENSE).
