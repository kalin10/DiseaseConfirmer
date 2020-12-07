namespace DiseaseConfirmer.Web.ViewModels.Doctors
{
    using System.Collections.Generic;

    public class DoctorsViewModel
    {
        public string CategoryName { get; set; }

        public IEnumerable<string> CategoiesNames { get; set; }

        public IEnumerable<IndexDoctorViewModel> Doctors { get; set; }
    }
}
