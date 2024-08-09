import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { SimulationComponent } from './simulation.component';
import { SimulationService } from '../../services/simulation.service';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('SimulationComponent', () => {
  let component: SimulationComponent;
  let fixture: ComponentFixture<SimulationComponent>;
  let simulationService: jasmine.SpyObj<SimulationService>;

  beforeEach(async () => {
    const spy = jasmine.createSpyObj('SimulationService', ['startSimulation']);

    await TestBed.configureTestingModule({
      imports: [FormsModule, CommonModule, SimulationComponent],
      providers: [
        { provide: SimulationService, useValue: spy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(SimulationComponent);
    component = fixture.componentInstance;
    simulationService = TestBed.inject(SimulationService) as jasmine.SpyObj<SimulationService>;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call startSimulation with correct parameters when onStart is called', () => {
    const simulationCount = 10;
    const switchStatus = true;
    const mockResponse = {
      gameCount: 10,
      winCount: 5,
      winRate: 0.5,
      winRatePercentage: 50
    };

    component.simulationCount = simulationCount;
    component.switchStatus = switchStatus;

    simulationService.startSimulation.and.returnValue(of(mockResponse));

    component.onStart();

    expect(simulationService.startSimulation).toHaveBeenCalledWith(simulationCount, switchStatus);
    expect(component.gameCount).toBe(mockResponse.gameCount);
    expect(component.winCount).toBe(mockResponse.winCount);
    expect(component.winRate).toBe(mockResponse.winRate);
    expect(component.winRatePercentage).toBe(mockResponse.winRatePercentage);
    expect(component.isLoading).toBeFalse();
  });

  it('should display the correct results when simulation data is available', () => {
    const mockResponse = {
      gameCount: 10,
      winCount: 5,
      winRate: 0.5,
      winRatePercentage: 50
    };

    simulationService.startSimulation.and.returnValue(of(mockResponse));
    component.simulationCount = 10;
    component.switchStatus = true;

    component.onStart();
    fixture.detectChanges();

    const resultTexts = fixture.debugElement.queryAll(By.css('.display-result')).map(el => el.nativeElement.textContent.trim());
    
    expect(resultTexts).toContain('You Have Wins 5 Out Of 10 Simulations.');
    expect(resultTexts).toContain('Win Rate 0.5 or 50%.');
  });
});
