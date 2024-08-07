﻿using Monty_Hall_Simulation_API.Constants;
using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Services
{
    public class Simulation : ISimulation
    {
        private readonly Random _random;
        private readonly IGame _game;
        public Simulation(Random random, IGame game)
        {
            _random = random;
            _game = game;
        }
        public Result StartSimulations(int simulationCount, bool switchStatus)
        {
            if (simulationCount <= 0)
            {
                throw new InvalidOperationException(AppConstants.SIMULATION_COUNT_ERROR_MESSAGE);
            }

            int winCount = 0;

            for (var i = 0; i < simulationCount; i++)
            {
                var initialChoose = _random.Next(0, 3);

                _game.UserChoosesDoor(initialChoose);
                _game.SpeakerOpensDoor();

                var chosenDoor = switchStatus
                    ? _game.UserChoosesDoor(DoorState.Initial)
                    : _game.UserChoosesDoor(DoorState.Chosen);

                if (chosenDoor.Prize == "Car")
                {
                    winCount++;
                }

                _game.ResetGame();
            }

            double winRate = (double)winCount / simulationCount;

            int winRatePercentage = (int)(winRate * 100);

            Result result = new()
            {
                GameCount = simulationCount,
                WinCount = winCount,
                WinRate = winRate,
                WinRatePercentage = winRatePercentage
            };

            return result;
        }
    }
}
