import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RightsideComponent } from './rightside.component';

describe('RightsideComponent', () => {
  let component: RightsideComponent;
  let fixture: ComponentFixture<RightsideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RightsideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RightsideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
