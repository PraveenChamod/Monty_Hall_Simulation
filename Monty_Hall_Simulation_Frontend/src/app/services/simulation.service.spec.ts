import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { SimulationService } from './simulation.service';
import { environment } from '../../environments/environment';

describe('SimulationService', () => {
  let service: SimulationService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SimulationService]
    });

    service = TestBed.inject(SimulationService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call startSimulation with correct URL and params', () => {
    const simulationCount = 10;
    const switchStatus = true;
    const mockResponse = {};

    service.startSimulation(simulationCount, switchStatus).subscribe(response => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(
      `${environment.API_URL}?simulationCount=${simulationCount}&switchStatus=${switchStatus}`
    );
    expect(req.request.method).toBe('POST');
    req.flush(mockResponse);
  });
});
