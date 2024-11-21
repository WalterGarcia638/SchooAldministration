import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../services/student.service';
import { Student } from '../../models/Student';
import { Course } from '../../models/Course';
import { FormBuilder, FormsModule} from '@angular/forms';
import { CourseService } from '../../services/course.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import Swal from 'sweetalert2';
import { TeacherService } from '../../services/teacher.service';
import { GradeService } from '../../services/grade.service';
import { StudentGradeDetailService } from '../../services/student-grade-detail.service';
import { Teacher } from '../../models/Teacher';
import { Grade } from '../../models/Grade';
import { StudentGradeDetail } from '../../models/StudentGradeDetail ';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  templateUrl: './student.component.html',
  styleUrl: './student.component.css'
})
export class StudentComponent implements OnInit {

  // Variables para Estudiante
  firstName: string = '';
  lastName: string = '';
  age: number | null = null;
  dateOfBirth: string = '';
  address: string = '';
  courseId: number | null = null;
  searchTerm: string = '';
  gender: string = '';
  students: Student[] = [];
  courses: Course[] = [];
  editing: boolean = false;
  currentStudentId: number | null = null;

  // Variables para Curso
  courseName: string = '';
  courseDescription: string = '';
  editingCourse: boolean = false;
  currentCourseId: number | null = null;

  // Variables para Profesor
  teachers: Teacher[] = [];
  teacherFirstName: string = '';
  teacherLastName: string = '';
  teacherGender: string = '';
  editingTeacher: boolean = false;
  currentTeacherId: number | null = null;

  // Variables para Grado
  grades: Grade[] = [];
  gradeName: string = '';
  gradeTeacherId: number | null = null;
  editingGrade: boolean = false;
  currentGradeId: number | null = null;

  // Variables para Detalle de Estudiante en Grado
  studentGradeDetails: StudentGradeDetail[] = [];
  studentGradeDetailStudentId: number | null = null;
  studentGradeDetailGradeId: number | null = null;
  studentGradeDetailSection: string = '';
  editingStudentGradeDetail: boolean = false;
  currentStudentGradeDetailId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private courseService: CourseService,
    private teacherService: TeacherService,
    private gradeService: GradeService,
    private studentGradeDetailService: StudentGradeDetailService
  ) {}

  ngOnInit(): void {
    this.loadStudents();
    this.loadCourses();
    this.loadTeachers();
    this.loadGrades();
    this.loadStudentGradeDetails();
  }

  // Métodos para Estudiante
  loadStudents() {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }

  submitForm() {
    const student: Student = {
      id: this.currentStudentId ?? 0,
      firstName: this.firstName,
      lastName: this.lastName,
      age: this.age!,
      dateOfBirth: new Date(this.dateOfBirth),
      address: this.address,
      courseId: this.courseId!,
      gender: this.gender
    };

    if (this.editing && this.currentStudentId !== null) {
      this.studentService.updateStudent(this.currentStudentId, student).subscribe(() => {
        this.loadStudents();
        this.resetForm();
        Swal.fire('Actualizado!', 'Estudiante actualizado correctamente.', 'success');
      });
    } else {
      this.studentService.addStudent(student).subscribe(() => {
        this.loadStudents();
        this.resetForm();
        Swal.fire('Agregado!', 'Estudiante agregado correctamente.', 'success');
      });
    }
  }

  editStudent(student: Student) {// Depuración
    this.editing = true;
    this.currentStudentId = student.id;
    this.firstName = student.firstName;
    this.lastName = student.lastName;
    this.age = student.age;
    
    // Manejo de dateOfBirth
    if (student.dateOfBirth) {
      const date = new Date(student.dateOfBirth);
      this.dateOfBirth = date.toISOString().split('T')[0];
    } else {
      this.dateOfBirth = '';
    }
  
    this.address = student.address;
    this.courseId = student.courseId;
    this.gender = student.gender;
  }

  deleteStudent(studentId: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¿Realmente desea eliminar este estudiante?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No, Cancelar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.studentService.deleteStudent(studentId).subscribe(() => {
          this.loadStudents();
          Swal.fire('Eliminado!', 'Estudiante eliminado satisfactoriamente.', 'success');
        });
      }
    });
  }

  resetForm() {
    this.editing = false;
    this.currentStudentId = null;
    this.firstName = '';
    this.lastName = '';
    this.age = null;
    this.dateOfBirth = '';
    this.address = '';
    this.courseId = null;
    this.gender = '';
  }

  getFilteredStudents(): Student[] {
    if (!this.searchTerm) {
      return this.students;
    }
    return this.students.filter(student =>
      student.firstName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      student.lastName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  // Métodos para Curso
  loadCourses() {
    this.courseService.getCourses().subscribe(data => {
      this.courses = data;
    });
  }

  submitCourse() {
    const course: Course = {
      id: this.currentCourseId ?? 0,
      name: this.courseName,
      description: this.courseDescription
    };

    if (this.editingCourse && this.currentCourseId !== null) {
      this.courseService.updateCourse(this.currentCourseId, course).subscribe(() => {
        this.loadCourses();
        this.resetCourseForm();
        Swal.fire('Actualizado!', 'Curso actualizado correctamente.', 'success');
      });
    } else {
      this.courseService.createCourse(course).subscribe(() => {
        this.loadCourses();
        this.resetCourseForm();
        Swal.fire('Agregado!', 'Curso agregado correctamente.', 'success');
      });
    }
  }

  editCourse(course: Course) {
    this.editingCourse = true;
    this.currentCourseId = course.id;
    this.courseName = course.name;
    this.courseDescription = course.description;
  }

  deleteCourse(courseId: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¿Realmente desea eliminar este curso?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No, Cancelar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.courseService.deleteCourse(courseId).subscribe(() => {
          this.loadCourses();
          Swal.fire('Eliminado!', 'Curso eliminado satisfactoriamente.', 'success');
        });
      }
    });
  }

  resetCourseForm() {
    this.editingCourse = false;
    this.currentCourseId = null;
    this.courseName = '';
    this.courseDescription = '';
  }

  getCourseName(courseId: number): string {
    const course = this.courses.find(c => c.id === courseId);
    return course ? course.name : 'N/A';
  }

  // Métodos para Profesor
  loadTeachers() {
    this.teacherService.getTeachers().subscribe(data => {
      this.teachers = data;
    });
  }

  submitTeacher() {
    const teacher: Teacher = {
      id: this.currentTeacherId ?? 0,
      firstName: this.teacherFirstName,
      lastName: this.teacherLastName,
      gender: this.teacherGender
    };

    if (this.editingTeacher && this.currentTeacherId !== null) {
      this.teacherService.updateTeacher(this.currentTeacherId, teacher).subscribe(() => {
        this.loadTeachers();
        this.resetTeacherForm();
        Swal.fire('Actualizado!', 'Profesor actualizado correctamente.', 'success');
      });
    } else {
      this.teacherService.createTeacher(teacher).subscribe(() => {
        this.loadTeachers();
        this.resetTeacherForm();
        Swal.fire('Agregado!', 'Profesor agregado correctamente.', 'success');
      });
    }
  }

  editTeacher(teacher: Teacher) {
    this.editingTeacher = true;
    this.currentTeacherId = teacher.id;
    this.teacherFirstName = teacher.firstName;
    this.teacherLastName = teacher.lastName;
    this.teacherGender = teacher.gender;
  }

  deleteTeacher(teacherId: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¿Realmente desea eliminar este profesor?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No, Cancelar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.teacherService.deleteTeacher(teacherId).subscribe(() => {
          this.loadTeachers();
          Swal.fire('Eliminado!', 'Profesor eliminado satisfactoriamente.', 'success');
        });
      }
    });
  }

  resetTeacherForm() {
    this.editingTeacher = false;
    this.currentTeacherId = null;
    this.teacherFirstName = '';
    this.teacherLastName = '';
    this.teacherGender = '';
  }

  getTeacherName(teacherId: number): string {
    const teacher = this.teachers.find(t => t.id === teacherId);
    return teacher ? `${teacher.firstName} ${teacher.lastName}` : 'N/A';
  }

  // Métodos para Grado
  loadGrades() {
    this.gradeService.getGrades().subscribe(data => {
      this.grades = data;
    });
  }

  submitGrade() {
    const grade: Grade = {
      id: this.currentGradeId ?? 0,
      name: this.gradeName,
      teacherId: this.gradeTeacherId!
    };

    if (this.editingGrade && this.currentGradeId !== null) {
      this.gradeService.updateGrade(this.currentGradeId, grade).subscribe(() => {
        this.loadGrades();
        this.resetGradeForm();
        Swal.fire('Actualizado!', 'Grado actualizado correctamente.', 'success');
      });
    } else {
      this.gradeService.createGrade(grade).subscribe(() => {
        this.loadGrades();
        this.resetGradeForm();
        Swal.fire('Agregado!', 'Grado agregado correctamente.', 'success');
      });
    }
  }

  editGrade(grade: Grade) {
    this.editingGrade = true;
    this.currentGradeId = grade.id;
    this.gradeName = grade.name;
    this.gradeTeacherId = grade.teacherId;
  }

  deleteGrade(gradeId: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¿Realmente desea eliminar este grado?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No, Cancelar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.gradeService.deleteGrade(gradeId).subscribe(() => {
          this.loadGrades();
          Swal.fire('Eliminado!', 'Grado eliminado satisfactoriamente.', 'success');
        });
      }
    });
  }

  resetGradeForm() {
    this.editingGrade = false;
    this.currentGradeId = null;
    this.gradeName = '';
    this.gradeTeacherId = null;
  }

  getGradeName(gradeId: number): string {
    const grade = this.grades.find(g => g.id === gradeId);
    return grade ? grade.name : 'N/A';
  }

  // Métodos para Detalle de Estudiante en Grado
  loadStudentGradeDetails() {
    this.studentGradeDetailService.getStudentGradeDetails().subscribe(data => {
      this.studentGradeDetails = data;
    });
  }

  submitStudentGradeDetail() {
    const detail: StudentGradeDetail = {
      id: this.currentStudentGradeDetailId ?? 0,
      studentId: this.studentGradeDetailStudentId!,
      gradeId: this.studentGradeDetailGradeId!,
      section: this.studentGradeDetailSection
    };

    if (this.editingStudentGradeDetail && this.currentStudentGradeDetailId !== null) {
      this.studentGradeDetailService.updateStudentGradeDetail(this.currentStudentGradeDetailId, detail).subscribe(() => {
        this.loadStudentGradeDetails();
        this.resetStudentGradeDetailForm();
        Swal.fire('Actualizado!', 'Detalle actualizado correctamente.', 'success');
      });
    } else {
      this.studentGradeDetailService.createStudentGradeDetail(detail).subscribe(() => {
        this.loadStudentGradeDetails();
        this.resetStudentGradeDetailForm();
        Swal.fire('Agregado!', 'Detalle agregado correctamente.', 'success');
      });
    }
  }

  editStudentGradeDetail(detail: StudentGradeDetail) {
    this.editingStudentGradeDetail = true;
    this.currentStudentGradeDetailId = detail.id;
    this.studentGradeDetailStudentId = detail.studentId;
    this.studentGradeDetailGradeId = detail.gradeId;
    this.studentGradeDetailSection = detail.section;
  }

  deleteStudentGradeDetail(detailId: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¿Realmente desea eliminar este detalle?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No, Cancelar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.studentGradeDetailService.deleteStudentGradeDetail(detailId).subscribe(() => {
          this.loadStudentGradeDetails();
          Swal.fire('Eliminado!', 'Detalle eliminado satisfactoriamente.', 'success');
        });
      }
    });
  }

  resetStudentGradeDetailForm() {
    this.editingStudentGradeDetail = false;
    this.currentStudentGradeDetailId = null;
    this.studentGradeDetailStudentId = null;
    this.studentGradeDetailGradeId = null;
    this.studentGradeDetailSection = '';
  }

  getStudentName(studentId: number): string {
    const student = this.students.find(s => s.id === studentId);
    return student ? `${student.firstName} ${student.lastName}` : 'N/A';
  }

}