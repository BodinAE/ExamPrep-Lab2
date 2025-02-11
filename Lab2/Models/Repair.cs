using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public ApplianceTypeEnum ApplianceType { get; set; }
        public string Model { get; set; }
        public string Problem {  get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public RepairStatusEnum RepairStatus { get; set; }
        public enum RepairStatusEnum
        {
            New_Repair,
            In_Progress,
            Completed
        }

        public enum ApplianceTypeEnum
        {
            Refrigerator,
            Washing_Machine,
            TV
        }
        public override string ToString()
        {
            return $"{Date} - {Id}, {ApplianceType}, {Model}, {Problem}, {ClientName}, {Phone}, {RepairStatus}";
        }
    }
}
