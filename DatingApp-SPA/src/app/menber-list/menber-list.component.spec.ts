/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MenberListComponent } from './menber-list.component';

describe('MenberListComponent', () => {
  let component: MenberListComponent;
  let fixture: ComponentFixture<MenberListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenberListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
