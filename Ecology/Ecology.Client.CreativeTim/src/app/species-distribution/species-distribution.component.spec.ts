import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeciesDistributionComponent } from './species-distribution.component';

describe('SpeciesDistributionComponent', () => {
  let component: SpeciesDistributionComponent;
  let fixture: ComponentFixture<SpeciesDistributionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpeciesDistributionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpeciesDistributionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
