namespace Shared.Dtos
{
    public class UserManagerResponseDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
    }
}
