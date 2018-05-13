using System;
using Evlog.Domain;
using Xunit;

namespace Evlog.UnitTests.Domain
{
	public class EventPostTests
	{
		public class IsSingleDayEvent_Should
		{
			[Fact]
			public void ReturnTrueWhenOnlyStartDateIsSpecified()
			{
				EventPost ev = new EventPost
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnTrueWhenStartAndEndDatesAreEqual()
			{
				EventPost ev = new EventPost
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0),
					EndDate = new DateTime(2018, 4, 30)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnFalseWhenStartAndEndDatesAreDifferent()
			{
				EventPost ev = new EventPost
				{
					StartDateTime = new DateTime(2018, 4, 30, 10, 10, 0),
					EndDate = new DateTime(2018, 5, 1)
				};
				Assert.False(ev.IsSingleDayEvent);
			}
		}
	}
}
