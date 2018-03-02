using Microsoft.EntityFrameworkCore;
using Sia.Shared.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sia.Data.Incidents.Models
{
    public class Event 
        : IEntity, 
        IJsonDataString,
        IWithManyToManyCollection<Event, AssociateEventToEngagement, Engagement>,
        IWithManyToManyCollection<Event, AssociateEventToIncident, Incident>,
        IWithManyToManyCollection<Event, AssociateEventToTicket, Ticket>,
        IWithManyToManyCollection<Event, AssociateEventToEvent, Event>
    {
        public long Id { get; set; }
        public long? IncidentId { get; set; }
        public long EventTypeId { get; set; }
        public DateTime Occurred { get; set; }
        public DateTime EventFired { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Data { get; set; }

        public ICollection<AssociateEventToEngagement> EngagementAssociations { get; set; }
            = new HashSet<AssociateEventToEngagement>();
        private ManyToManyCollection<Event, AssociateEventToEngagement, Engagement> _engagements
            => new ManyToManyCollection<Event, AssociateEventToEngagement, Engagement>(this, EngagementAssociations);
        public ICollection<Engagement> Engagements
            => _engagements;
        ManyToManyCollection<Event, AssociateEventToEngagement, Engagement> IWithManyToManyCollection<Event, AssociateEventToEngagement, Engagement>.ManyToManyCollection
            => _engagements;
        ICollection<AssociateEventToEngagement> IWithManyToManyCollection<Event, AssociateEventToEngagement, Engagement>.AssociationCollection
            => EngagementAssociations;

        public ICollection<AssociateEventToIncident> IncidentAssociations { get; set; }
            = new HashSet<AssociateEventToIncident>();
        public ICollection<Incident> Incidents
            => _incidents;
        public ManyToManyCollection<Event, AssociateEventToIncident, Incident> _incidents
            => new ManyToManyCollection<Event, AssociateEventToIncident, Incident>(this, IncidentAssociations);
        ICollection<AssociateEventToIncident> IWithManyToManyCollection<Event, AssociateEventToIncident, Incident>.AssociationCollection
            => IncidentAssociations;
        ManyToManyCollection<Event, AssociateEventToIncident, Incident> IWithManyToManyCollection<Event, AssociateEventToIncident, Incident>.ManyToManyCollection
            => _incidents;

        public ICollection<AssociateEventToTicket> TicketAssociations { get; set; }
            = new HashSet<AssociateEventToTicket>();
        public ICollection<Ticket> Tickets
            => _tickets;
        public ManyToManyCollection<Event, AssociateEventToTicket, Ticket> _tickets
            => new ManyToManyCollection<Event, AssociateEventToTicket, Ticket>(this, TicketAssociations);
        ICollection<AssociateEventToTicket> IWithManyToManyCollection<Event, AssociateEventToTicket, Ticket>.AssociationCollection 
            => TicketAssociations;
        ManyToManyCollection<Event, AssociateEventToTicket, Ticket> IWithManyToManyCollection<Event, AssociateEventToTicket, Ticket>.ManyToManyCollection
            => _tickets;

        public ICollection<AssociateEventToEvent> EventAssociations { get; set; }
            = new HashSet<AssociateEventToEvent>();
        public ICollection<Event> Events
            => _events;
        public ManyToManyCollection<Event, AssociateEventToEvent, Event> _events
            => new ManyToManyCollection<Event, AssociateEventToEvent, Event>(this, EventAssociations);
        ICollection<AssociateEventToEvent> IWithManyToManyCollection<Event, AssociateEventToEvent, Event>.AssociationCollection
            => EventAssociations;
        ManyToManyCollection<Event, AssociateEventToEvent, Event> IWithManyToManyCollection<Event, AssociateEventToEvent, Event>.ManyToManyCollection
            => _events;
    }
}
