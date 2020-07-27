--Part 1
-- (column, data_type) in Jobs table are: (Id, int), (Name, text), and (EmployerId, int).

--Part 2
select Name
from employers
where (Location = "Saint Louis");

--Part 3
select skills.name, skills.description
from skills
where skills.Id in 
	(
	select skills.Id
	from Skills 
	inner join Jobskills
	on (Skills.Id = Jobskills.SkillId)
	);
