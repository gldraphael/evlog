using Evlog.Core.Entities.EventAggregate;
using System;
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
					StartTimeUtc = new DateTime(2018, 4, 30, 10, 10, 0)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnTrueWhenStartAndEndDatesAreEqual()
			{
				EventPost ev = new EventPost
				{
					StartTimeUtc = new DateTime(2018, 4, 30, 10, 10, 0),
					EndTimeUtc = new DateTime(2018, 4, 30)
				};
				Assert.True(ev.IsSingleDayEvent);
			}

			[Fact]
			public void ReturnFalseWhenStartAndEndDatesAreDifferent()
			{
				EventPost ev = new EventPost
				{
					StartTimeUtc = new DateTime(2018, 4, 30, 10, 10, 0),
					EndTimeUtc = new DateTime(2018, 5, 1)
				};
				Assert.False(ev.IsSingleDayEvent);
			}
		}
	}
}
