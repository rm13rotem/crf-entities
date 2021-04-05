using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainEntities.WebApi.Models
{
    public class MainEntity
    {
        public int Id { get; set; }
        public string GuidId { get; set; }
        public int ExperimentId { get; set; }
        public int DoctoryId { get; set; }
        public int PatientIdInTrial { get; set; }
        public int VisitGroupId { get; set; }
        public int VisitIndexInVisitGroup { get; set; }
        public int VisitId { get; set; }
        public int ModuleId { get; set; }
        public string JsonValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
