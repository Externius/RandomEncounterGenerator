# Random Encounter Generator

![Build status](https://github.com/Externius/RandomEncounterGenerator/actions/workflows/main.yml/badge.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

This is an ASP.NET Core 10.0 + Angular project for generating random encounters using D&amp;D5th Edition SRD monsters.

## Prerequisites

You have Node.js and npm installed, also .NET 10 SDK.

## Get the code

Use `git clone` to clone the repository.

## Build and run

In your preferred IDE run the REG.WebApi project.  
Or manually in the project root folder you must run the following commands in a terminal:

``` bash
dotnet build
```

Then in the REG.WebApi folder:

``` bash
dotnet run
```

Also, you need to run the following commands in the REG.Angular folder

``` bash
npm ci
npm run build
npm run start
```

## Usage

Open the <https://localhost:4200/> address in a browser.
