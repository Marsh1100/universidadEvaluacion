# Proyecto Universidad <br> 
Una universidad busca implementar una base de datos para gestionar la información de sus estudiantes, profesores, cursos y asignaturas. La base de datos se suministra con la información necesaria para facilitar el seguimiento de la asignación de profesores a cursos y asignaturas. La universidad proporciona los enunciados de las consultas específicas que se deben realizar en la base de datos, con el objetivo de obtener información relevante según sus necesidades, como la carga laboral de los profesores y otros aspectos cruciales para la gestión académica.

1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

    ```sql
      # Consulta Aqui
    ```
.
.

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

     ```sql
       # Consulta Aqui
     ```

30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.

     ```sql
       # Consulta Aqui
     ```

31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

     ```sql
       # Consulta Aqui
     ```