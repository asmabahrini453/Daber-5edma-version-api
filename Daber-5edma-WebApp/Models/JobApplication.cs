namespace Daber_5edma_WebApp.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;

        public int CandidatId { get; set; }

        public int JobOfferId { get; set; }

        public virtual Candidat? Candidat { get; set; }
        public virtual JobOffer? JobOffer { get; set; }
    }
}
