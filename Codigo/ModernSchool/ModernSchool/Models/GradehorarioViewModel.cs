using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GradehorarioViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdComponente { get; set; }
        [Required]
        public int IdTurma { get; set; }
        [Required]
        public string? DiaSemana { get; set; }
        [Required]
        public string? HoraInicio { get; set; }
        [Required]
        public string? HoraFim { get; set; }
        [Required]
        public int IdProfessor { get; set; }
    }
}