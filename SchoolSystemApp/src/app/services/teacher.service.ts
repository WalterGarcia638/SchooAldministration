import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Teacher } from '../models/Teacher';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  private apiUrlTeachers = 'https://localhost:7127/api/Teacher';

  constructor(private http: HttpClient) {}

  // Obtener todos los profesores
  getTeachers(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.apiUrlTeachers);
  }

  // Obtener un profesor por ID
  getTeacherById(id: number): Observable<Teacher> {
    return this.http.get<Teacher>(`${this.apiUrlTeachers}/GetById?id=${id}`);
  }

  // Buscar profesores por nombre
  getTeacherByName(name: string): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(`${this.apiUrlTeachers}/${name}`);
  }

  // Crear un nuevo profesor
  createTeacher(teacher: Teacher): Observable<void> {
    return this.http.post<void>(this.apiUrlTeachers, teacher);
  }

  // Actualizar un profesor existente
  updateTeacher(id: number, teacher: Teacher): Observable<void> {
    return this.http.patch<void>(`${this.apiUrlTeachers}/${id}`, teacher);
  }

  // Eliminar un profesor
  deleteTeacher(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrlTeachers}/${id}`);
  }
}