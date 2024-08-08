import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SimulationService } from '../../services/simulation.service';
import { CommonModule } from '@angular/common';
import { UI_TEXTS } from '../../constants/uiTexts';

@Component({
  selector: 'app-simulation',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './simulation.component.html',
  styleUrl: './simulation.component.scss',
})
export class SimulationComponent {
  simulationCount = 0;
  switchStatus = true;
  gameCount = 0;
  winCount = 0;
  winRate = 0.0;
  winRatePercentage = 0;
  isLoading = false;

  constructor(private simulationService: SimulationService) {}

  onStart(): void {
    if (this.simulationCount == 0) {
      alert(UI_TEXTS.SIMULATION_COUNT_ERROR_MESSAGE);
    } else {
      this.isLoading = true;
      this.simulationService
        .startSimulation(this.simulationCount, this.switchStatus)
        .subscribe({
          next: (response) => {
            this.gameCount = response.gameCount;
            this.winCount = response.winCount;
            this.winRate = response.winRate;
            this.winRatePercentage = response.winRatePercentage;
          },
          error: (error) => {
            this.isLoading = false;
            alert(UI_TEXTS.RESULTS_FETCHING_ERROR_MESSAGE);
            console.error(UI_TEXTS.RESULTS_FETCHING_ERROR_MESSAGE, error);
          },
          complete: () => {
            this.isLoading = false;
          },
        });
    }
  }
}
