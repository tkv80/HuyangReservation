using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HuyangReservation
{
    public partial class ReservationFrm : Form
    {
        private readonly string _cookieString;
        private readonly Worker worker = new Worker();
        private string _userName;

        public ReservationFrm()
        {
            InitializeComponent();

            numInterval.Value = 3;

            gboption.Enabled = gbReservation.Enabled = gbSite.Enabled = gboption.Enabled = false;

            IList<string> cookie = HttpManager.GetCoockie();
            _cookieString = cookie[0] + "," + cookie[1].Replace("Path=/", "") + cookie[2];

            //textBox1.Focus();
            textBox1.Select();

            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void CbFacilityOnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            cblSite.DataSource = HttpManager.GetSite(_cookieString, cbLodge.SelectedValue.ToString(),
                cbFacility.SelectedValue.ToString(),
                DateTime.Now.ToString("yyyyMM"));
            cblSite.ValueMember = "Code";
            cblSite.DisplayMember = "Name";
        }

        private void cbLodge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLodge.SelectedValue.ToString() != "0")
            {
                cbFacility.DataSource = HttpManager.GetFacility(_cookieString, cbLodge.SelectedValue.ToString());
                cbFacility.ValueMember = "Code";
                cbFacility.DisplayMember = "Name";
            }
            else
            {
                cbFacility.DataSource = null;
            }
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                for (int i = 0; i < cblSite.Items.Count; i++)
                {
                    cblSite.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < cblSite.Items.Count; i++)
                {
                    cblSite.SetItemChecked(i, false);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var bookingList = new BookingList {Booking = new List<Booking>()};

            string text = string.Format("{0} - {1}",
                ((Lodge) cbLodge.SelectedItem).Name,
                ((Facility) cbFacility.SelectedItem).Name);

            string siteString = "";
            int checkSite = 0;

            for (int i = 0; i < cblSite.Items.Count; i++)
            {
                if (cblSite.GetItemChecked(i))
                {
                    var book = new Booking
                    {
                        FcltId = ((Site) cblSite.Items[i]).FacilityId,
                        Dprtm = ((Site) cblSite.Items[i]).Code,
                        YyyMMdd = dateTime.Value.ToString("yyyyMMdd"),
                        RsrvtQntt = cbPeriod.SelectedValue.ToString(),
                        FcltMdcls = ((Facility) cbFacility.SelectedItem).Code,
                        SiteName = ((Site) cblSite.Items[i]).Name
                    };

                    bookingList.Booking.Add(book);

                    if (siteString == "")
                    {
                        siteString = ((Site) cblSite.Items[i]).Name;
                    }

                    checkSite++;
                }
            }
            text += " - " + siteString + " 외 " + (checkSite - 1) + " 사이트 " + dateTime.Value.ToString("yyyy년 MM월 dd일");

            bookingList.Lodge = ((Lodge) cbLodge.SelectedItem).Name;
            bookingList.Facility = ((Facility) cbFacility.SelectedItem).Name;
            bookingList.Desc = text;
            //lbReservation.Items.Add(bookingList);
            cbReservation.Items.Add(bookingList);
            cbReservation.SetItemCheckState(cbReservation.Items.Count - 1, CheckState.Checked);
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (txtLog.Lines.Length <= 150)
            {
                Logging(e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                Logging(e.UserState.ToString());
            }

            toolStripStatusLabel1.Text = "[실행] " + e.UserState;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logging("완료~!!");
            btnStart.Enabled = true;
            btnStart.Text = "시작";
            toolStripStatusLabel1.Text = "[완료]";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = @"예약 시작";

            foreach (object item in cbReservation.CheckedItems)
            {
                if (worker.IsBusy)
                {
                    worker.CancelAsync();
                    btnStart.Text = "중지 증...";
                    btnStart.Enabled = false;
                }
                else
                {
                    ;
                    worker.Interval = (int) numInterval.Value;
                    worker.BookingList = (BookingList) item;
                    worker.Cookie = _cookieString;
                    worker.RunWorkerAsync();

                    btnStart.Text = "중지";
                }
                /*

                var bookingList = ((BookingList)item).Booking;
                foreach (var booking in bookingList)
                {
                    HttpManager.CheckSite(_cookieString, booking.fcltId, booking.rsrvtQntt, booking.yyyMMdd,
                        booking.dprtm, booking.fcltMdcls);
                    var resultHtml = HttpManager.Booking(_cookieString, booking.fcltId, booking.yyyMMdd, booking.rsrvtQntt, booking.dprtm);
                    
                    if (resultHtml.Contains("예약번호"))
                    {
                        Logging(string.Format("{0} - {1} - {2} - {3}","성공" ,((BookingList)item).Facility, ((BookingList)item).Lodge, booking.SiteName));
                        var message = string.Format("{0} {1} {2}", DateTime.Now.ToString("HH:mm:ss"), booking.SiteName, ((BookingList)item).Lodge);
                        new GCMManager().SendNotification(message, "캠핑예약");
                        return;
                    }
                    else
                    {
                        const string searchText = "<p><strong>Message</strong></p>";
                        var resultText = resultHtml.Substring(resultHtml.IndexOf(searchText) + searchText.Length, resultHtml.IndexOf("</p>", resultHtml.IndexOf(searchText)) - resultHtml.IndexOf(searchText)).Replace("<p>", "").Trim();

                        Logging(string.Format("{0} - {1} - {2} - {3}", "실패", ((BookingList)item).Lodge, ((BookingList)item).Lodge, booking.SiteName), resultText);
                    }

                    Application.DoEvents();
                    Thread.Sleep(300);
                }*/
            }

            toolStripStatusLabel1.Text = "예약 종료";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cbReservation.Items.RemoveAt(cbReservation.SelectedIndex);
            //lbReservation.Items.RemoveAt(lbReservation.SelectedIndex);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string resultHtml = HttpManager.Login(textBox1.Text, textBox2.Text, _cookieString);
            if (resultHtml.Contains("<div class=\"login_error\">"))
            {
                const string searchText = "<div class=\"login_error\">";
                string resultText =
                    resultHtml.Substring(resultHtml.IndexOf(searchText) + searchText.Length,
                        resultHtml.IndexOf("</p>", resultHtml.IndexOf(searchText)) - resultHtml.IndexOf(searchText) -
                        searchText.Length)
                        .Replace("<p>", "")
                        .Replace("<strong>", "")
                        .Replace("</strong>", "")
                        .Trim();
                MessageBox.Show(resultText);
                Logging(textBox1.Text + " 아이디 로그인 에러 ", resultText);
                return;
            }
            else
            {
                resultHtml = HttpManager.GetMain(_cookieString);
                const string searchText = "<span class=\"name\">";
                string resultText =
                    resultHtml.Substring(resultHtml.IndexOf(searchText) + searchText.Length,
                        resultHtml.IndexOf("</span>", resultHtml.IndexOf(searchText)) - resultHtml.IndexOf(searchText) -
                        searchText.Length)
                        //.Replace("<p>", "")
                        //.Replace("<strong>", "")
                        //.Replace("</strong>", "")
                        .Trim();
                Logging(textBox1.Text + " 로그인", resultText, Color.Blue);
                _userName = resultText;

                toolStripStatusLabel1.Text = _userName + @" 로그인";
            }


            gboption.Enabled = gbReservation.Enabled = gbSite.Enabled = gboption.Enabled = true;

            cbLodge.DataSource = HttpManager.GetForestLodge(_cookieString);
            cbLodge.ValueMember = "Code";
            cbLodge.DisplayMember = "Name";

            //lbReservation.DisplayMember = "Desc";
            cbReservation.DisplayMember = "Desc";

            var data = new[]
            {
                new {Value = "1", Name = "1박2일"},
                new {Value = "2", Name = "2박3일"},
                new {Value = "3", Name = "3박4일"}
            };

            cbPeriod.DataSource = data;
            cbPeriod.ValueMember = "Value";
            cbPeriod.DisplayMember = "Name";


            cbLodge.SelectedValueChanged += cbLodge_SelectedIndexChanged;
            cbFacility.SelectedIndexChanged += CbFacilityOnSelectedIndexChanged;

            gbAccont.Enabled = false;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(btnLogin, e);
            }
        }

        #region logging

        private void Logging(string log)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}\r\n", log));
        }

        private void Logging(string log, Color color)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, color, string.Format(" - {0}\r\n", log));
        }

        private void Logging(string log, string log1, Color color)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}", log));
            AppendText(txtLog, color, string.Format(" - {0}\r\n", log1));
        }

        private void Logging(string log, string error)
        {
            AppendText(txtLog, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(txtLog, Color.Black, string.Format(" - {0}", log));
            AppendText(txtLog, Color.Red, string.Format(" - {0}\r\n", error));
        }

        private void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        #endregion
    }
}
    ;