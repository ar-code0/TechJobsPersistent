﻿using System;
using TechJobsPersistent.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class JobDetailViewModel
    {
        [Required]
        public int JobId { get; set; }
        public string Name { get; set; }
        public string EmployerName { get; set; }
        public string SkillText { get; set; }
        public string EmployerLocation { get; set; }

        public JobDetailViewModel(Job theJob, List<JobSkill> jobSkills)
        {
            JobId = theJob.Id;
            Name = theJob.Name;
            EmployerName = theJob.Employer.Name;
            EmployerLocation = theJob.Employer.Location;

            SkillText = "";
            for (int i = 0; i < jobSkills.Count; i++)
            {
                SkillText += jobSkills[i].Skill.Name;
                if (i < jobSkills.Count - 1)
                {
                    SkillText += ", ";
                }
            }
        }
    }
}
