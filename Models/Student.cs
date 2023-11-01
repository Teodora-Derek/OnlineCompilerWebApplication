using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OnlineCompilerWebApplication.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FacultyNumber { get; set; }

        [Required]
        [NineDigitNumeric]
        [Column(TypeName = "nvarchar(10)")]
        public string? FacultyName { get; set; } = string.Empty;

        [Required]
        [MemberNotNull(nameof(FirstName))]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MemberNotNull(nameof(MiddleName))]
        [Column(TypeName = "nvarchar(100)")]
        public string MiddleName { get; set; } = string.Empty;

        [Required]
        [MemberNotNull(nameof(LastName))]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MemberNotNull(nameof(AcademicDegreeName))]
        [Column(TypeName = "nvarchar(100)")]
        public string AcademicDegreeName { get; set; } = string.Empty;

        [Required]
        [MemberNotNull(nameof(Email))]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DegreeType AcademicDegreeType { get; set; }

        [Required]
        public short Stream { get; set; }

        [Required]
        public short Group { get; set; }

        [Required]
        public short Semester { get; set; }

        [Required]
        public short Course { get; set; }

        [Required]
        public StudyType StudyType { get; set; }

        [Required]
        public Status Status { get; set; }
    }

    public enum DegreeType
    {
        Bachelor,
        Master
    }

    public enum StudyType
    {
        FullTime,
        PartTime
    }

    public enum Status
    {
        Active,
        Disabled
    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NineDigitNumericAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string facultyNumber)
            {
                if (facultyNumber.Length == 9 && facultyNumber.All(char.IsDigit))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("FacultyNumber must be a 9-digit string containing only numeric digits.");
        }
    }
}
