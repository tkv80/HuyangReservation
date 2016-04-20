using System.Collections.Generic;

namespace HuyangReservation
{
    public class Site
    {
        public string FacilityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Lodge
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Facility
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Booking
    {
        public string FcltId { get; set; }
        public string YyyMMdd { get; set; }
        public string RsrvtQntt { get; set; }
        public string Dprtm { get; set; }
        public string FcltMdcls { get; set; }
        public string SiteName { get; set; }
    }

    public class BookingList
    {
        public List<Booking> Booking { get; set; }
        public string Lodge { get; set; }
        public string Facility { get; set; }
        public string Desc { get; set; }
    }
}