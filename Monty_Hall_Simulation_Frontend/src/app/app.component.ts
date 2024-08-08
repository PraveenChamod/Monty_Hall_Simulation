import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SimulationComponent } from './components/simulation/simulation.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SimulationComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Monty_Hall_Simulation_Frontend';
}
