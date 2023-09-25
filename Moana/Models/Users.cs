using Postgrest.Attributes;
using Postgrest.Models;
[Table("usuarios")]
public class User : BaseModel
{

    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

#nullable enable
    [Column("token")]
    public string? Token { get; set; }

    [Column("rolid")]
    public int rolId { get; set; }

    [Column("estadoid")]
    public int estadoId { get; set; }

}