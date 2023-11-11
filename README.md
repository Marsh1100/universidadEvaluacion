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
    http://localhost:5000/api/Departament/subjectDepartament2
    ```
17. Devuelve el número total de **alumnas** que hay.

    ```
       http://localhost:5000/api/Person/womanStudents
    ```

18. Calcula cuántos alumnos nacieron en `1999`.

    ```
    http://localhost:5000/api/Person/studentsBirthday1999
    ```