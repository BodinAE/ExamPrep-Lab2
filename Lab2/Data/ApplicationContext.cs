using System.Collections.ObjectModel;
using Lab2.Models;

namespace Lab2.Data
{
    public class ApplicationContext : IDisposable 
    {
        private bool _isDisposed = false;
        private static ObservableCollection<Repair> _repairs = new()
        {
            new( 
                new DateOnly(2025, 6, 5), 
                ApplianceTypeEnum.Refrigerator, 
                "FGNU49", 
                "Broke", 
                "Ivanov Ivan Ivanovich", 
                "+79762417592",
                "Fixer1",
                RepairStatusEnum.New_Repair
                ),
            new(
                new DateOnly(2025, 6, 5),
                ApplianceTypeEnum.Washing_Machine,
                "GJNV89",
                "Rust",
                "Johnov John Johnovich",
                "+797568867592",
                "Fixer2",
                RepairStatusEnum.Completed
                ),
            new(
                new DateOnly(2025, 5, 5),
                ApplianceTypeEnum.TV,
                "GJNV89",
                "Cracked Screen",
                "Ilyanov Ilya Ilyanovich",
                "+7975676592",
                "Fixer1",
                RepairStatusEnum.In_Progress
                )
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
                dbRepair.Name = Repair.Name;
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
