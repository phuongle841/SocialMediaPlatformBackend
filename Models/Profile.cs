public class Profile
{
    public int user_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password_hash { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string profile_picture { get; set; }
    public string bio { get; set; }
    public DateTime date_of_birth { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool is_active { get; set; }
    public DateTime last_login { get; set; }

}
