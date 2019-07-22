import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewComponent } from './view.component';

describe('ViewComponent', () => {
  let component: ViewComponent;
  let fixture: ComponentFixture<ViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
   const fixture = TestBed.createComponent(ViewComponent);
    const app = fixture.debugElement.componentInstance;   
    fixture.detectChanges();
  });
  function setup() {
    const fixture = TestBed.createComponent(ViewComponent);
    const app = fixture.debugElement.componentInstance;   
    return { fixture, app };
  }
 
  
    it('should create the view component ', () => {
      const { app } = setup();
      expect(app).toBeTruthy();
    });
});
