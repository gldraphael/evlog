using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evlog.Infrastructure.Data.DataModels
{
    public class EventPostDM
    {
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 128)]
        public string Title { get; set; } = null!;

        [StringLength(maximumLength: 256)]
        public string? Description { get; set; }

        [Required, StringLength(maximumLength: 256)]
        public string Slug { get; set; } = null!;

        public string? Body { get; set; }

        public DateTime StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public IList<RegistrationDM> Registrations { get; set; } = null!;
    }
}
