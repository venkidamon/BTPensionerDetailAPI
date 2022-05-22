using Microsoft.EntityFrameworkCore;
using PensionerDetail.Dtos;
using PensionerDetail.Entities;

namespace PensionerDetail.Data
{
    public class Seed
    {
        public static async Task SeedPensionerDetails(DataContext context)
        {
            if (await context.Pensioners.AnyAsync()) return;

            List<DataValue> pdetails = File.ReadAllLines("../PensionerDetail/Data/usersDetails.csv").Skip(1).Select(v => DataValue.FromCsv(v)).ToList();
            foreach (var p in pdetails)
            {
                
                var pensionerdetail = new PensionerDetails();
                pensionerdetail.AadharNumber = p.AadharNumber;
                pensionerdetail.AccountNumber = p.AccountNumber;
                pensionerdetail.Name = p.Name;
                pensionerdetail.DateOfBirth = p.DateOfBirth;
                pensionerdetail.PanCardNumber = p.PanCardNumber;
                pensionerdetail.Salary = p.Salary;
                pensionerdetail.Allowance = p.Allowance;
                pensionerdetail.PensionType = p.PensionType;
                pensionerdetail.BankName = p.BankName;
                pensionerdetail.BankType = p.BankType;

                context.Pensioners.Add(pensionerdetail);
                
            }
            await context.SaveChangesAsync();
        }
    }
    public class DataValue
    {
        public string AadharNumber;
        public string Name;
        public string DateOfBirth;
        public string PanCardNumber;
        public double Salary;
        public double Allowance;
        public string PensionType;
        public string BankName;
        public string AccountNumber;
        public string BankType;

        public static DataValue FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            DataValue dataValue = new DataValue();
            dataValue.AadharNumber = values[0];
            dataValue.Name = values[1];
            dataValue.DateOfBirth = values[2];
            dataValue.PanCardNumber = values[3];
            dataValue.Salary = Convert.ToDouble(values[4]);
            dataValue.Allowance = Convert.ToDouble(values[5]);
            dataValue.PensionType = values[6];
            dataValue.BankName = values[7];
            dataValue.AccountNumber = values[8];
            dataValue.BankType = values[9];
            return dataValue;

        }
    }
}
