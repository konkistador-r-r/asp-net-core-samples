using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprterFeature
{
    public class Reporter
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReportSender _reportSender;
        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender) {
            _reportBuilder = reportBuilder;
            _reportSender = reportSender;
        }

        public int SendReports()
        {
            IList<IReport> reports = _reportBuilder.CreateRegularReports();

            if (reports.Count == 0)
            {
                _reportSender.Send(_reportBuilder.CreateSpecialReport());
            }

            foreach (IReport report in reports)
            {
                _reportSender.Send(report);
            }

            return reports.Count;
        }
    }
}
