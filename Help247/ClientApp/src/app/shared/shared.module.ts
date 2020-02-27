import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatTooltipModule,
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatTableModule,
  MatPaginatorModule,
  MatDialogModule,
  MatProgressSpinnerModule,
  MatSelectModule
}
  from '@angular/material';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTooltipModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule
  ],
  exports: [
    MatTooltipModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule
  ]
})
export class SharedModule { }
