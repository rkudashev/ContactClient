namespace Api.Model;
public class Contact
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}

    public static Contact Unknown => new() {Id = -1, Name = "Unknown", Email = "Unknown"};
}