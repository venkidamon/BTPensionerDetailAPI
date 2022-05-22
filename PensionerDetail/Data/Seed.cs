using Microsoft.EntityFrameworkCore;
using PensionerDetail.Dtos;

namespace PensionerDetail.Data
{
    public class Seed
    {
        public static async Task SeedPensionerDetails(DataContext context)
        {
            if (await context.Pensioners.AnyAsync()) return;

            List<DataValue> pdetails = File.ReadAllLines("../PensionerDetail/Data/usersDetails.csv").Skip(1).Select(v => DataValue.FromCsv(v)).ToList();
        }
    }
    public class DataValue
    {
        string AadharNumber;
        string Name;
        string DateOfBirth;
        string PanCardNumber;
        double Salary;
        double Allowance;
        string PensionType;
        string BankName;
        string AccountNumber;
        string BankType;

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
