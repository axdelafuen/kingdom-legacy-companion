[![.NET](https://github.com/axdelafuen/kingdom-legacy-companion/actions/workflows/dotnet.yml/badge.svg)](https://github.com/axdelafuen/kingdom-legacy-companion/actions/workflows/dotnet.yml)

# Kingdom Legacy Companion

_Keep track of your kingdoms_

> Discover the game : [Kingdom Legacy](https://www.kingdomlegacygame.com/)

## 🚧 Work in Progress

This application is still under development and does not yet have an official release. To use it, you must compile the source code yourself.

## Acknowledgment

You can find more about the original creators, **fryxgames**, of the board game _Kingdom Legacy_ [here](https://fryxgames.se/).

## 🛠 Getting Started

### Prerequisites

Ensure you have the following installed:
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with .NET MAUI workload installed)
- [.NET SDK](https://dotnet.microsoft.com/download)
- MAUI prerequisites for your platform:
  - [windows](https://learn.microsoft.com/en-us/dotnet/maui/windows/setup)
  - [android](https://learn.microsoft.com/en-us/dotnet/maui/android/setup)
  - [ios](https://learn.microsoft.com/en-us/dotnet/maui/ios/setup)

### Clone the Repository

```sh
git clone https://github.com/axdelafuen/kingdom-legacy-companion.git
```
```sh
cd kingdom-legacy-companion/Sources/
```

### Build and Run

_you can use VisualStudio or CLI:_

```sh
dotnet restore
```

```sh
dotnet build ./Model/Model.csproj
```

```sh
dotnet build ./KingdomLegacyCompanion/KingdomLegacyCompanion.csproj -f net8.0-{platform}
```

```sh
dotnet maui run {platform}
```