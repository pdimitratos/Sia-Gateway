using Sia.Shared.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sia.Data.Incidents.Models
{
    public class Incident : IEntity,
        IWithManyToManyCollection<Incident, AssociateEventToIncident, Event>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
            = new HashSet<Ticket>();
        public ICollection<Engagement> Engagements { get; set; }
            = new HashSet<Engagement>();
        public ICollection<Event> Events { get; set; }
            = new HashSet<Event>();

        /// <summary>
        /// Join record for MTMEvents
        /// </summary>
        public ICollection<AssociateEventToIncident> EventAssociations { get; set; }
            = new HashSet<AssociateEventToIncident>();
        private ManyToManyCollection<Incident, AssociateEventToIncident, Event> _mtmEvents
            => new ManyToManyCollection<Incident, AssociateEventToIncident, Event>(this, EventAssociations);
        /// <summary>
        /// Many to Many Event collection backed by a join table
        /// </summary>
        public ICollection<Event> MTMEvents
            => _mtmEvents;
        ICollection<AssociateEventToIncident> IWithManyToManyCollection<Incident, AssociateEventToIncident, Event>.AssociationCollection
            => EventAssociations;
        ManyToManyCollection<Incident, AssociateEventToIncident, Event> IWithManyToManyCollection<Incident, AssociateEventToIncident, Event>.ManyToManyCollection
            => _mtmEvents;
    }
}
