using System;
using System.Windows.Media;

namespace EstateDataDTO
{
    /// <summary>
    /// DTO for representing estate information.
    /// </summary>
    public class EstateDTO
    {
        public string? EstateType { get; set; }
        public Enum? LegalForm { get; set; }
        public string? EstateName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public Enum? Country { get; set; }
        public ImageSource? Image { get; set; }
        public int? CategoryDetails { get; set; }
        public string? SpecificDetails { get; set; }

    }
}
