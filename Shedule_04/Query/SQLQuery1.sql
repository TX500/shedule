--select * from shedule_table

--SELECT group_name FROM groups

--select id_shTable From shedule_table
--where fk_group = '1' AND semester = 'Осенний' AND year = '2025/2026';

--SELECT g.group_name, sh.semester, sh.year
--                               FROM shedule_table sh join  groups g on sh.fk_group=g.id_group
--                               Where group_name = 'АД-21' AND semester = 'Весенний' AND year = '2020/2021'
--							   --group by g.group_name, sh.semester, sh.year;

--SELECT shed_time, id_group
--FROM shedule_table JOIN groups on fk_group = id_group
--WHERE year = '2020/2021' AND semester = 'Осенний' AND id_group = '1'


	--select day, task_number, subject_name, classroom_name, surname--, id_subject, id_classroom, id_lecturer
	--from shedule_time JOIN subject on fk_subject = id_subject JOIN classroom on fk_classroom = id_classroom JOIN lecturer on fk_lecturer = id_lecturer
	--where id_shTime in ('1','2') AND day = 'Понедельник'

select * from shedule_time
select * from shedule_table

-- id=8
select id_shTime
from shedule_time JOIN shedule_table on shed_time = id_shTime Join classroom on fk_classroom = id_classroom
where year = '2020/2021' AND semester = 'Осенний' AND classroom_name = 'А-101' AND day = 'Понедельник' AND task_time = '08:30-10:00'

select group_name
from shedule_time JOIN shedule_table on shed_time = id_shTime Join classroom on fk_classroom = id_classroom JOIN groups on fk_group = id_group
where year = '2020/2021' AND semester = 'Осенний' AND classroom_name = 'А-101' AND day = 'Понедельник' AND task_time = '08:30-10:00'

select classroom_name, group_name
from shedule_time JOIN shedule_table on shed_time = id_shTime Join lecturer on fk_lecturer = id_lecturer Join classroom on fk_classroom = id_classroom JOIN groups on fk_group = id_group
where year = '2020/2021' AND semester = 'Осенний' AND day = 'Понедельник' AND task_time = '08:30-10:00' AND surname = 'Александрова'