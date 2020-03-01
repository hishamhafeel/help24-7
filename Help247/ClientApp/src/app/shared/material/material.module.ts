import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; import {
  MatTooltipModule,
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatTableModule,
  MatPaginatorModule,
  MatDialogModule,
  MatProgressSpinnerModule,
  MatSelectModule,
  MatCardModule,
  MatFormFieldModule
}
  from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatTooltipModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
  ],
  exports: [
    MatTooltipModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatSelectModule
  ]
})
export class MaterialModule { }
