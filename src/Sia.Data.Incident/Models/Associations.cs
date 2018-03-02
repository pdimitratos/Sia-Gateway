using Sia.Shared.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sia.Data.Incidents.Models
{
    public class AssociateEventToEngagement
        : BidrectionalAssociation<Event, Engagement>
    {

    }

    public class AssociateEventToIncident
        : BidrectionalAssociation<Event, Incident>
    {

    }

    public class AssociateEventToTicket
        : BidrectionalAssociation<Event, Ticket>
    {

    }

    public class AssociateEventToEvent
        : BidrectionalAssociation<Event, Event>
    {

    }
}
