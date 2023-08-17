namespace date;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{GetAggregatedCashbacksDateRange().Item1}, {GetAggregatedCashbacksDateRange().Item2}");
    }

    public static (DateTime, DateTime) GetAggregatedCashbacksDateRange() { 
       var today = DateTime.Today;
       var month = new DateTime(today.Year, today.Month, 1);
       var first = month.AddMonths(-1);
       var last = month.AddDays(-1);
       return (first, last);
    }

}

