# Monty Hall Simulation

This repository contains a web application that simulates the Monty Hall problem with proven the paradox concept by consider the win rate. The application features a frontend built with Angular and a backend built with .NET Core.

## Features

- Simulate a specified number of simulations.
- Option to switch doors after the Monty reveals a goat.
- Visualize simulation results on the frontend.
- Includes testing for both frontend and backend components/services.

## Prerequisites

- .NET Core SDK
- Node.js
- Angular CLI

## Backend Setup (C# / .NET Core)

1. Navigate to the `Monty_Hall_Simulator_API` directory:
   
   ```bash
   cd Monty_Hall_Simulator_API
3. Restore dependencies:
   
   ```bash
   dotnet restore
5. Build and run the backend:
   
   ```bash
   dotnet build
   dotnet run
The server will be listen on `http://localhost:5279`

## Frontend Setup (Angular)

1. Navigate to the `Monty_Hall_Simulator_Frontend` directory:
   
   ```bash
   cd Monty_Hall_Simulator_Frontend
3. Install dependencies:
   
   ```bash
   npm install
5. Serve the frontend application:
   
   ```bash
   ng serve
The frontend will be available at `http://localhost:4200`
