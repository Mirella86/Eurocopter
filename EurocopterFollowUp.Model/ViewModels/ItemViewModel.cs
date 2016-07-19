using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EurocopterFollowUp.Model.Infrastructure;
using EurocopterFollowUp.Model.Enums;

namespace EurocopterFollowUp.Model.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("WO")]
        public string WO { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("WP")]
        public string WP { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Ud")]
        public string Ud { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Subsystem ECP")]
        public string Subsystem_ECP { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Issue")]
        public string Issue { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Installation")]
        public string Installation { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("RPT VCI")]
        public string RPT_VCI { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Indice")]
        public string Indice { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Designation")]
        public string Designation { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("TypeIU")]
        public string TypeIU { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Conf No")]
        public string ConfNo { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Effectivity")]
        public string Effectivity { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Aircraft")]
        public string Aircraft { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("DataIn")]
        public DateTime DataIn { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Deadline")]
        public DateTime Deadline { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("DataOut")]
        public DateTime? DataOut { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Daos Description")]
        public string DaosDescription { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        public string Daos { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Author")]
        public Guid? AuthorId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Status")]
        public short? StatusId { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Proof Reader")]
        public Guid? ProofReaderId { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Authoring %")]
        public decimal AuthoringPercent { get; set; }

        [Required(ErrorMessage = "*")]
        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Cross Check %")]
        public decimal CrossCheckPercent { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Final %")]
        public decimal FinalPercent { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Figure")]
        public string Figure { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [ReadOnlyAuthorize("Administrator, Manager")]
        [DisplayName("Proof Reader")]
        public string ProofReader { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
    }
}
