import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Grade } from '../models/Grade';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  private apiUrlGrades = 'https://localhost:7127/api/Grade';

  constructor(private http: HttpClient) { }

  // Obtener todos los grados
  getGrades(): Observable<Grade[]> {
    return this.http.get<Grade[]>(this.apiUrlGrades);
  }

  // Obtener un grado por ID
  getGradeById(id: number): Observable<Grade> {
    return this.http.get<Grade>(`${this.apiUrlGrades}/GetById?id=${id}`);
  }

  // Buscar grados por nombre
  getGradeByName(name: string): Observable<Grade[]> {
    return this.http.get<Grade[]>(`${this.apiUrlGrades}/${name}`);
  }

  // Crear un nuevo grado
  createGrade(grade: Grade): Observable<void> {
    return this.http.post<void>(this.apiUrlGrades, grade);
  }

  // Actualizar un grado existente
  updateGrade(id: number, grade: Grade): Observable<void> {
    return this.http.patch<void>(`${this.apiUrlGrades}/${id}`, grade);
  }

  // Eliminar un grado
  deleteGrade(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrlGrades}/${id}`);
  }
}