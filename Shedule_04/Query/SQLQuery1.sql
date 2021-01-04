select task_number, subject_name, classroom_name, surname
from shedule_time, subject, classroom, lecturer
where day = 'Понедельник' AND fk_subject = id_subject AND fk_classroom = id_classroom AND fk_lecturer = id_lecturer;

