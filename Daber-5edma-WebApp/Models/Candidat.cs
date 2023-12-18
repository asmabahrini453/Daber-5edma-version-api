using Microsoft.AspNetCore.Builder;

namespace Daber_5edma_WebApp.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Tel { get; set; } = null!;
       
        public string Password { get; set; } = null!;
        public DateTime DateNaiss { get; set; }

        public string Speciality { get; set; } = null!;
        public string Experience { get; set; } = null!;

        public string Education { get; set; } = null!;

        public ICollection<JobApplication>? JobApplication { get; set; }
    }
}
