public class PhotoAlbumService 
{
    public const string BAD_INPUT_RESPONSE = "Input invalid: Please enter a numeric album id.";
    public IEnumerable<string> GetPhotosByAlbumId(string? userInput)
    {
        List<string> photos = new();

        if (userInput == null) 
        {
            photos.Add(BAD_INPUT_RESPONSE);
            return photos;
        }

        return photos;
    }
}