using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibility;

namespace Lab2.Models
{
    public class Repair
    {
        private static int iterator_id = 0;
        
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                 id  = iterator_id + 1;
                iterator_id += 1;
            } 
        }
        public DateOnly Date { get; set; }
        public ApplianceTypeEnum ApplianceType { get; set; }
        public string Model { get; set; }
        public string Problem {  get; set; }
        public ClientName Name { get; set; }
        public string Phone { get; set; }
        public string Fixer { get; set; }
        public RepairStatusEnum RepairStatus { get; set; }
   
        public Repair(DateOnly date, ApplianceTypeEnum apptype, string model, string problem,  string name, string phone, string fixer, RepairStatusEnum status)
        {
            Id = 0; 
            Date = date;
            ApplianceType = apptype;
            Model = model;
            Problem = problem;
            Name = new(name);
            Phone = phone;
            Fixer = fixer;
            RepairStatus = status;
        }
        public override string ToString()
        {
            return $"{Id}, {Date}, {ApplianceType}, {Model}, {Problem}, {Name}, {Phone}, {Fixer}, {RepairStatus}";
        }
    }
}
