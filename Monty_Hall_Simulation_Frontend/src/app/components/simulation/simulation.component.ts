import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SimulationService } from '../../services/simulation.service';
import { CommonModule } from '@angular/common';

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
  winRate = 0.00;
  winRatePercentage = 0;
  isLoading = false;

  constructor(private simulationService: SimulationService) {}

  onStart(): void {
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
          console.error('Error fetching simulation data', error);
        },
        complete: () => {
          this.isLoading = false;
        },
      });
  }
}
