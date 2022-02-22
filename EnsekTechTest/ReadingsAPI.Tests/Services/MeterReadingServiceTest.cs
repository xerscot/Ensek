using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReadingsAPI.Tests.Services
{
    public class MeterReadingServiceTest
    {
        private readonly string _meterReading = "2344,22/04/2019 09:24,01002";
        private readonly string _wrongLength = "1241,11/04/2019 09:24,00436,X";
        private readonly string _emptyReading = "4534,11/05/2019 09:24,";
        private readonly string _wrongFormat = "2349,22/04/2019 12:25,VOID";
        private readonly string _wrongReading = "2346,22/04/2019 12:25,999999";
        private readonly string _negativeReading = "6776,09/05/2019 09:24,-06575";

        [Fact]
        public void ValidReading()
        {
            var service = new MeterReadingService();

            string[] row = _meterReading.Split(',');

            Assert.True(service.IsReadingValid(row));
        }

        [Fact]
        public void WrongLengthCheck()
        {
            var service = new MeterReadingService();

            string[] row = _wrongLength.Split(',');

            string message = "";

            Assert.True(!service.IsReadingValid(row));

            message = service.MeterReadingResults.FirstOrDefault().Message;

            Assert.Equal("Invalid Field Count", message);
        }

        [Fact]
        public void EmptyReadingCheck()
        {
            var service = new MeterReadingService();

            string[] row = _emptyReading.Split(',');

            string message = "";

            Assert.True(!service.IsReadingValid(row));

            message = service.MeterReadingResults.FirstOrDefault().Message;

            Assert.Equal("Invalid Reading (No Reading Data)", message);
        }

        [Fact]
        public void WrongFormatReadingCheck()
        {
            var service = new MeterReadingService();

            string[] row = _wrongFormat.Split(',');

            string message = "";

            Assert.True(!service.IsReadingValid(row));

            message = service.MeterReadingResults.FirstOrDefault().Message;

            Assert.Equal("Invalid Reading (None Numeric Reading Data)", message);
        }

        [Fact]
        public void WrongReadingCheck()
        {
            var service = new MeterReadingService();

            string[] row = _wrongReading.Split(',');

            string message = "";

            Assert.True(!service.IsReadingValid(row));

            message = service.MeterReadingResults.FirstOrDefault().Message;

            Assert.Equal("Invalid Reading (Length)", message);
        }

        [Fact]
        public void NegativeReadingCheck()
        {
            var service = new MeterReadingService();

            string[] row = _negativeReading.Split(',');

            string message = "";

            Assert.True(!service.IsReadingValid(row));

            message = service.MeterReadingResults.FirstOrDefault().Message;

            Assert.Equal("Invalid Reading (Negative Value)", message);
        }
    }
}
