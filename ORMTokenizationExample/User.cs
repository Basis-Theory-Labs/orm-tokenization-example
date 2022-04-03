using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.DataTokenization;

namespace ORMTokenizationExample;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Tokenized]
    public string FirstName { get; set; }

    [Required]
    [Tokenized]
    public string LastName { get; set; }

    [Required]
    [Tokenized]
    public string Email { get; set; }

    [Required]
    [Tokenized]
    public int Age { get; set; }
}
