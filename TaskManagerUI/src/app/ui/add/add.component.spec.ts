import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComponent } from './add.component';

describe('AddComponent', () => {
  let component: AddComponent;
  let fixture: ComponentFixture<AddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  
  function setup() {
    const fixture = TestBed.createComponent(AddComponent);
    const app = fixture.debugElement.componentInstance;
   
    return { fixture, app };
  }
  it('should have page title', () => {
    expect(component.pageTitle).toEqual("Add Task");
  });

    
  
    it('should create the add component', () => {
      const { app } = setup();
      expect(app).toBeTruthy();
    });
});
