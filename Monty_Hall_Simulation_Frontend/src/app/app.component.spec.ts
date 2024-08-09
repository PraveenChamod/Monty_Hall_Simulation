import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterOutlet } from '@angular/router';
import { AppComponent } from './app.component';
import { SimulationComponent } from './components/simulation/simulation.component';
import { UI_TEXTS } from './constants/uiTexts';
import { provideHttpClient } from '@angular/common/http';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent, RouterOutlet, SimulationComponent],
      providers: [provideHttpClient()]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title '${UI_TEXTS.APPLICATION_TITLE}'`, () => {
    expect(component.title).toEqual(UI_TEXTS.APPLICATION_TITLE);
  });

  it('should render title in a p tag', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.topic-text')?.textContent).toContain('Monty Hall Simulator');
  });

  it('should render the SimulationComponent', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('app-simulation')).toBeTruthy();
  });
});
