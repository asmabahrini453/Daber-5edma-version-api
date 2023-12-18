using System.ComponentModel.DataAnnotations.Schema;

namespace Daber_5edma_api.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;

      //  [ForeignKey("Candidat")]
        public int CandidatId { get; set; }

      //  [ForeignKey("JobOffer")]
        public int JobOfferId { get; set; }

        public virtual Candidat? Candidat { get; set; }
        public virtual JobOffer? JobOffer { get; set; }
    }
}
