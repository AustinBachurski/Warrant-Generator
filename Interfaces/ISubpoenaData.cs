namespace WarrantGenerator.Interfaces

{
    public interface ISubpoenaData
    {
        public string AttorneyName { get; }
        public string AttorneyGender { get; }
        public string CityStateZip { get; }
        public string CompanyName { get; }
        public string CompanyAddress { get; }
        public string DateTrapped { get; }
        public string EndTime { get; }
        public string OutputFile { get; }
        public string PhoneNumber { get; }
        public string ReportNumber { get; }
        public string StartTime { get; }
        public string TodaysDate { get; }

        public bool GenerateWarrantApplicationDocument { get; }
        public bool GenerateWarrantDocument { get; }

    }

}

