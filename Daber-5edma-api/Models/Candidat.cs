using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace Daber_5edma_api.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
       // [EmailAddress]
        public string Email { get; set; } = null!;
        public string Tel { get; set; } = null!;
        // [Required]
        // [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public DateTime DateNaiss { get; set; }

        public string Speciality { get; set; } = null!;
        public string Experience { get; set; } = null!;

        public string Education { get; set; } = null!;

        public ICollection<JobApplication>? JobApplication { get; set; }

    }
}
