# Proyecto Universidad <br> 
Una universidad busca implementar una base de datos para gestionar la información de sus estudiantes, profesores, cursos y asignaturas. La base de datos se suministra con la información necesaria para facilitar el seguimiento de la asignación de profesores a cursos y asignaturas. La universidad proporciona los enunciados de las consultas específicas que se deben realizar en la base de datos, con el objetivo de obtener información relevante según sus necesidades, como la carga laboral de los profesores y otros aspectos cruciales para la gestión académica.


# data BD
Datos a insertar [Click aquí](https://github.com/Marsh1100/universidadEvaluacion/blob/main/Data.txt)

# CRUD
En cada uno de los controladores se realizó el CRUD correspondiente de las tablas. En el siguiente link [Peticiones](https://github.com/Marsh1100/universidadEvaluacion/blob/main/api-university.postman_collection), es un archivo contenido en el proyecto, puede importarse a Postman o Insomia para visualizar cada una de las peticiones realizadas.
# Endpoints

1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

    ```
    http://localhost:5000/api/Person/allStudents
    ```
2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.

    ```
    http://localhost:5000/api/Person/studentsWithoutPhone
    ```

3. Devuelve el listado de los alumnos que nacieron en `1999`.

    ```
    http://localhost:5000/api/Person/Students1999
    ```

4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.

    ```
    http://localhost:5000/api/Person/TeacherWithoutPhoneK
    ```

5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso, del grado que tiene el identificador `7`.

    ```
      http://localhost:5000/api/Subject/subjectsCourse3
    ```

6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

    ```
    http://localhost:5000/api/Person/womansGrade
    ```

7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

    ```
    http://localhost:5000/api/Subject/subjectsGrade4
    ```

8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

    ```
    http://localhost:5000/api/Teacher/teacherAndDepartament
    ```

9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.

    ```
    http://localhost:5000/api/Person/studentNif
    ```

10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`.

     ```
     http://localhost:5000/api/Departament/departamentsGrade4
     ```

11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.

     ```
     http://localhost:5000/api/Person/students2018_2019
     ```

12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.

     ```
     http://localhost:5000/api/Teacher/allTeachersDep
     ```

13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.

     ```
     http://localhost:5000/api/Teacher/teacherWithoutDepartament
     ```

14. Devuelve un listado con los profesores que no imparten ninguna asignatura.

     ```
     http://localhost:5000/api/Person/teachersWithoutSubject
     ```
15. Devuelve un listado con las asignaturas que no tienen un profesor asignado. 

    ```
     http://localhost:5000/api/Subject/withoutTeacher
    ```
     
16. Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca.

    ```
    http://localhost:5000/api/Departament/subjectDepartament
    ```
17. Devuelve el número total de **alumnas** que hay.

    ```
    http://localhost:5000/api/Person/womanStudents
    ```

18. Calcula cuántos alumnos nacieron en `1999`.

    ```
    http://localhost:5000/api/Person/studentsBirthday1999
    ```
19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

     ```
     http://localhost:5000/api/Departament/teachersByDepartment
     ```

20. Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.

     ```
     http://localhost:5000/api/Departament/teachersByDepartmentAll
     ```
21. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas.

     ```
     http://localhost:5000/api/Grade/subjectsbyGrades
     ```

22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.

     ```
     http://localhost:5000/api/Grade/more40subj
     ```
   

23. Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de crédidos.

     ```
     http://localhost:5000/api/Grade/subjectsTypeByGrades
     ```
24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.

     ```
     http://localhost:5000/api/Schoolyear/studentsTuition/
     ```

25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

     ```
     http://localhost:5000/api/Subject/subjectsByTeacher
     ```

26. Devuelve todos los datos del alumno más joven.

     ```
       http://localhost:5000/api/Person/youngestStudent
     ```

27. Devuelve un listado con los profesores que no están asociados a un departamento.

     ```
       http://localhost:5000/api/Person/teachersWithoutDepartment
     ```

28. Devuelve un listado con los departamentos que no tienen profesores asociados.

     ```
       http://localhost:5000/api/Departament/departamentsWithoutTeachers
     ```

29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.

     ```
       http://localhost:5000/api/Person/teachersWithOutSubject
     ```

30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

     ```
     http://localhost:5000/api/Subject/withoutTeacher
     ```

31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

     ```
     http://localhost:5000/api/Departament/departamentsWithoutSubjects
     ```
