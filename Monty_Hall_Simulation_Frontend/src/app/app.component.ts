import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SimulationComponent } from './components/simulation/simulation.component';
import { UI_TEXTS } from './constants/uiTexts';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SimulationComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = UI_TEXTS.APPLICATION_TITLE;
}
