using System;
using Evlog.Domain;
using Xunit;

namespace Evlog.UnitTests.Domain
{
	public class EventTests
	{
		public class IsSingleDayEvent_Should
		{
			[Fact]
			public void ReturnTrueWhenOnlyStartDateIsSpecified()
			{
				Event ev = new Event
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnTrueWhenStartAndEndDatesAreEqual()
			{
				Event ev = new Event
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0),
					EndDate = new DateTime(2018, 4, 30)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnFalseWhenStartAndEndDatesAreDifferent()
			{
				Event ev = new Event
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0),
					EndDate = new DateTime(2018, 5, 1)
				};
				Assert.False(ev.IsSingleDayEvent);
			}
		}
	}
}
