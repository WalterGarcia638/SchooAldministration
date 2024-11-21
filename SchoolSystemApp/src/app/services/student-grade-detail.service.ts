import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudentGradeDetail } from '../models/StudentGradeDetail ';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentGradeDetailService {
  private apiUrlStudentGradeDetails = 'https://localhost:7127/api/StudentGradeDetail';

  constructor(private http: HttpClient) {}

  // Obtener todos los detalles de estudiantes en grados
  getStudentGradeDetails(): Observable<StudentGradeDetail[]> {
    return this.http.get<StudentGradeDetail[]>(this.apiUrlStudentGradeDetails);
  }

  // Obtener un detalle por ID
  getStudentGradeDetailById(id: number): Observable<StudentGradeDetail> {
    return this.http.get<StudentGradeDetail>(`${this.apiUrlStudentGradeDetails}/GetById?id=${id}`);
  }

  // Crear un nuevo detalle de estudiante en grado
  createStudentGradeDetail(studentGradeDetail: StudentGradeDetail): Observable<void> {
    return this.http.post<void>(this.apiUrlStudentGradeDetails, studentGradeDetail);
  }

  // Actualizar un detalle de estudiante en grado existente
  updateStudentGradeDetail(id: number, studentGradeDetail: StudentGradeDetail): Observable<void> {
    return this.http.patch<void>(`${this.apiUrlStudentGradeDetails}/${id}`, studentGradeDetail);
  }

  // Eliminar un detalle de estudiante en grado
  deleteStudentGradeDetail(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrlStudentGradeDetails}/${id}`);
  }
}