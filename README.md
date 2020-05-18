# SAFE Template
This template can be used to generate a full-stack web application using the [SAFE Stack](https://safe-stack.github.io/). It was created using the dotnet [SAFE Template](https://safe-stack.github.io/docs/template-overview/). If you want to learn more about the template why not start with the [quick start](https://safe-stack.github.io/docs/quickstart/) guide?

## Install pre-requisites
You'll need to install the following pre-requisites in order to build SAFE applications

* The [.NET Core SDK](https://www.microsoft.com/net/download)
* [npm](https://nodejs.org/en/download/) package manager.
* [Node LTS](https://nodejs.org/en/download/) installed for the front end components.

## Work with the application
Before you run the project **for the first time only** you should install its local tools with this command:

```bash
dotnet tool restore
```

Start the server:
```bash
dotnet run -p src\\server
```

Start the client:
```bash
cd src\\client
npm install
node_modules\.bin\\webpack-dev-server
```

## SAFE Stack Documentation
You will find more documentation about the used F# components at the following places:

* [Saturn](https://saturnframework.org/docs/)
* [Fable](https://fable.io/docs/)
* [Elmish](https://elmish.github.io/elmish/)

If you want to know more about the full Azure Stack and all of it's components (including Azure) visit the official [SAFE documentation](https://safe-stack.github.io/docs/).