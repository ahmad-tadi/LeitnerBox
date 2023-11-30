namespace Leitner;

public static class DateMapping
{
	private static readonly DateTime ReferenceDate = DateTime.UnixEpoch;

	public static int MapDateToNumber(this DateTime date)
	{
		TimeSpan timeSpan = date - ReferenceDate;
		return (int)timeSpan.TotalDays;
	}

	public static DateTime MapNumberToDate(this int number)
	{
		return ReferenceDate.AddDays(number);
	}
}
