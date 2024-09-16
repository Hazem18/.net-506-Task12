﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!; 
        public ResourceType Type { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

    }
}
