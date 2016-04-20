using System.ComponentModel;
using System.Threading;

namespace HuyangReservation
{
    internal class Worker : BackgroundWorker
    {
        private bool _cancel;

        public Worker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public int Interval { private get; set; }
        public string Cookie { private get; set; }
        public BookingList BookingList { private get; set; }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            var bookingList = BookingList.Booking;
            while (!CancellationPending)
            {
                foreach (var booking in bookingList)
                {
                    if (CancellationPending)
                    {
                        CancelAsync();
                    }

                    if (_cancel) continue;
                    
                    HttpManager.CheckSite(Cookie, booking.FcltId, booking.RsrvtQntt, booking.YyyMMdd,
                        booking.Dprtm, booking.FcltMdcls);
                    
                    var resultHtml = HttpManager.Booking(Cookie, booking.FcltId, booking.YyyMMdd,
                        booking.RsrvtQntt,
                        booking.Dprtm);

                    string message;
                    if (resultHtml.Contains("예약번호"))
                    {
                        message = string.Format("{0} - {1} - {2} - {3}", "성공", BookingList.Facility,
                            BookingList.Lodge, booking.SiteName);

                        new GcmManager().SendNotification(message, "캠핑예약");
                        CancelAsync();
                        _cancel = true;
                    }
                    else
                    {
                        const string searchText = "<p><strong>Message</strong></p>";
                        var resultText =
                            resultHtml.Substring(resultHtml.IndexOf(searchText) + searchText.Length,
                                resultHtml.IndexOf("</p>", resultHtml.IndexOf(searchText)) -
                                resultHtml.IndexOf(searchText)).Replace("<p>", "").Trim();

                        message = string.Format("{0} - {1} - {2} - {3}", "실패", BookingList.Lodge, booking.SiteName,
                            resultText);
                    }

                    ReportProgress(0, message);
                }

                Thread.Sleep(1000*Interval);
            }
        }
    }
}