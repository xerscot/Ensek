namespace ReadingsAPI
{
    public class MeterReadingService
    {
        private ReadingsDbContext? _db;
        private List<MeterReadingResult>? MeterReadingResults { get; set; }
        private List<MeterReading>? MeterReadings { get; set; }
        public MeterReadingService(ReadingsDbContext db)
        {
            InitLists();
            _db = db;
        }

        public MeterReadingService()
        {
            InitLists();
        }

        private void InitLists()
        {
            MeterReadingResults = new List<MeterReadingResult>();
            MeterReadings = new List<MeterReading>();
        }

        public async Task<bool> ProcessFileAsync(IFormFile file)
        {
            try
            {
                using (Stream? stream = file.OpenReadStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    while (reader.Peek() != -1)
                    {
                        var row = reader.ReadLine();
                        var details = row.Split(',');
                        if (details.Length > 0)
                        {
                            await Task.Factory.StartNew(() => ValidateRow(details));
                            await StoreReadingsAsync();
                        }
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return true;
        }

        private void ValidateRow(string[] row)
        {
            if (MeterReadingResults == null)
                return;

            if (row.Length > 3)
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Invalid Field Count" });
                return;
            }
            if(!IsReadingValid(row))
            {
                return;
            }

            if(!IsAccountInDb(Convert.ToInt32(row[0])))
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "No Account with that ID" });
                return;
            }

            if(IsReadingOlder(row))
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Reading Too Old" });
                return;
            }

            MeterReading reading = new MeterReading() { AccountId = Convert.ToInt32(row[0]), MeterReadingDateTime = Convert.ToDateTime(row[1]), MeterReadValue = row[2].ToString() };

            if(IsRowInDb(reading))
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Row Exists In Db" });
                return;
            }
            else
            {
                if (MeterReadings != null)
                {
                    MeterReadings.Add(reading);
                    MeterReadingResults.Add(new MeterReadingResult() { Success = true, Message = "Row Does Not Exist In Db" });
                }
            }
        }

        private bool IsReadingValid(string[] row)
        {
            var reading = row[2].ToString();
            if (reading == "")
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Invalid Reading (No Reading Data)" });
                return false;
            }

            int i = int.TryParse(reading, out i) ? i : 0;
            if(i == 0)
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Invalid Reading (None Numeric Reading Data)" });
                return false;
            }

            if(i < 0)
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Invalid Reading (Negative Value)" });
                return false;
            }

            if(reading.Length > 5)
            {
                MeterReadingResults.Add(new MeterReadingResult() { Success = false, Message = "Invalid Reading (Length)" });
                return false;
            }

            return true;
        }

        private bool IsAccountInDb(int accountId)
        {
            var accounts = _db.Accounts
                .Where(a => a.AccountId == accountId)
                .Select(a => new { a.AccountId });

            return accounts.Any();
        }

        private bool IsReadingOlder(string[] row)
        {
            var readingDate = Convert.ToDateTime(row[1]);
            var readings = _db.MeterReadings
                .Where(m => m.MeterReadingDateTime < readingDate)
                .Select(a => new { a.AccountId });

            return readings.Any();
        }

        private bool IsRowInDb(MeterReading reading)
        {
            var readings = _db.MeterReadings
                .Where(m => m.AccountId == reading.AccountId && m.MeterReadingDateTime == reading.MeterReadingDateTime && m.MeterReadValue == reading.MeterReadValue)
                .Select(a => a.AccountId);

            return readings.Any();
        }

        public List<MeterReadingResult>? GetMeterReadingResults()
        {
            return MeterReadingResults;
        }

        private async Task<int> StoreReadingsAsync()
        {
            foreach(var meterReading in MeterReadings)
            {
                await _db.MeterReadings.AddAsync(meterReading);
            }

            return 1;
        }
    }

    public class MeterReadingResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
