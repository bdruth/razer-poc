using System.ComponentModel.DataAnnotations;

public class AddressModel
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string StreetAddress { get; set; } = string.Empty;

  [Required]
  public string City { get; set; } = string.Empty;

  [Required]
  public string State { get; set; } = string.Empty;

  [Required]
  public string ZipCode { get; set; } = string.Empty;
}
