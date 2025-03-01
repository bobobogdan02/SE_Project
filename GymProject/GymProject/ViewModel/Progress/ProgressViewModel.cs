﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.ViewModel.Progress
{
    public class ProgressViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public float Kg { get; set; }
        public string Month { get; set; }
        public float ArmLeft { get; set; }
        public float ArmRight { get; set; }
        public float Shoulders { get; set; }
        public float Chest { get; set; }
        public float Belly { get; set; }
        public float Fesier { get; set; }
        public float Legs { get; set; }
        public string Gender { get; set; }
    }
}
