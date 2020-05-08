﻿using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.AppLogic.Services
{
    public class ProgressServices
    {
        private readonly IProgressRepository progressRepository;
        public ProgressServices(IProgressRepository progressRepository)
        {
            this.progressRepository = progressRepository;
        }
        public void AddStats(Guid UserId, float Kg, float ArmLeft, float ArmRight, float Height, float Shoulders, float Chest, float Belly, float Fesier, float Legs, string Gender)
        {
            progressRepository.Add(new Progress() { Id = Guid.NewGuid(), UserId = UserId, Kg = Kg, ArmLeft = ArmLeft, ArmRight = ArmRight, Height = Height, Shoulders = Shoulders, Chest = Chest, Belly = Belly, Fesier = Fesier, Legs = Legs, Gender = Gender });
        }
    }
}
