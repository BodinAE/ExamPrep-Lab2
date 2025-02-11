using System.Collections.ObjectModel;
using Lab2.Models;

namespace Lab2.Data
{
    public class ApplicationContext : IDisposable 
    {
        private bool _isDisposed = false;
        private static ObservableCollection<Repair> _repairs = new()
        {
            new() {
                Id = 1, 
                Date = new DateOnly(2025, 6, 5), 
                ApplianceType = Repair.ApplianceTypeEnum.Refrigerator, 
                Model = "FGNU49", 
                Problem = "Broke", 
                ClientName = "Ivanov II", 
                Phone = "+79762417592", RepairStatus = Repair.RepairStatusEnum.New_Repair
                },
            new() {
                Id = 2,
                Date = new DateOnly(2025, 6, 5),
                ApplianceType = Repair.ApplianceTypeEnum.Washing_Machine,
                Model = "GJNV89",
                Problem = "Rust",
                ClientName = "John II",
                Phone = "+797568867592", RepairStatus = Repair.RepairStatusEnum.Completed
                },
            new() {
                Id = 1,
                Date = new DateOnly(2025, 5, 5),
                ApplianceType = Repair.ApplianceTypeEnum.TV,
                Model = "GJNV89",
                Problem = "Cracked Screen",
                ClientName = "Josef II",
                Phone = "+7975676592", RepairStatus = Repair.RepairStatusEnum.In_Progress
                }
        };
        public ObservableCollection<Repair> Repairs { get => _repairs;}

        public void Add(Repair repair)
        {
            Repairs.Add(repair);
        }
        public void Remove(Repair Repair)
        {
            Repairs.Remove(Repair);
        }
        public Repair? Find(int? id)
        {
            return Repairs.First(x => x.Id == id);
        }
        public void Update(Repair Repair)
        {
            Repair? dbRepair = Repairs.First(x => x.Id == Repair.Id);
            if (dbRepair != null)
            {
                dbRepair.Date = Repair.Date;
                dbRepair.ApplianceType = Repair.ApplianceType;
                dbRepair.Model = Repair.Model;
                dbRepair.Problem = Repair.Problem;
                dbRepair.ClientName = Repair.ClientName;
                dbRepair.Phone = Repair.Phone;
                dbRepair.RepairStatus = Repair.RepairStatus;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            // check if already disposed 
            if (!_isDisposed)
            {
                // set the bool value to true 
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            // Invoke the above virtual 
            // dispose(bool disposing) method 
            Dispose(disposing: true);

            // Notify the garbage collector 
            // about the cleaning event 
            GC.SuppressFinalize(this);
        }
    }
}
