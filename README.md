# digit-duel

A realtime, competitive Sudoku game where players compete on a single board to solve the most number of cells.

## Stack

- Next.js static web client
- React Native mobile client
- Asp.NET backend / Azure SQL
- Azure App Service, Functions, & Static Web App

## Running & debugging locally

**node-functions**

- Requires [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=macos%2Cportal%2Cv2%2Cbash&pivots=programming-language-javascript#v2) and [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli).

Debug with the `debug: node-functions` vscode launch configuration or launch manually with:

```
cd packages/node-functions
func start
```

**public-client**

- Requires [Node 16.8 or later](https://nodejs.org/en)

Debug with the `debug: public-client` vscode launch configuration or launch maunally with:

```
cd packages/public-client
npm run dev
```

**server**

- Requires [.NET 7 or later](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Debug with the `debug: server` vscode launch configuration or launch manually with:

```
cd packages/server
dotnet run
```
