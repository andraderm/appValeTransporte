/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FuncionariosComponent } from './Funcionarios.component';

describe('FuncionariosComponent', () => {
  let component: FuncionariosComponent;
  let fixture: ComponentFixture<FuncionariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuncionariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuncionariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
