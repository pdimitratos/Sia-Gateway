using Sia.Shared.Data;
using System;
using System.Collections.Generic;

namespace Sia.Data.Incidents.Models
{
    public class Engagement : IEntity
    {
        public long Id { get; set; }
        public long IncidentId { get; set; }
        public DateTime TimeEngaged { get; set; }
        public DateTime? TimeDisengaged { get; set; }
        public Participant Participant { get; set; }
        public ICollection<AssociateEventToEngagement> EventAssociations { get; set; }
            = new HashSet<AssociateEventToEngagement>();
        public ICollection<Event> Events
            => new ManyToManyCollection<Engagement, AssociateEventToEngagement, Event>(this, EventAssociations);
    }
}
