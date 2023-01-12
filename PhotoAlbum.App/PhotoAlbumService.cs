namespace PhotoAlbum.App
{
    public class PhotoAlbumService
    {
        private const string BAD_INPUT_RESPONSE = "Input invalid: Please enter a numeric album id.";
        public IEnumerable<string> GetPhotosByAlbumId(string? userInput)
        {
            List<string> photos = new();
            int id = -1;
            if (userInput == null || userInput == string.Empty || !int.TryParse(userInput, out id))
            {
                photos.Add(BAD_INPUT_RESPONSE);
                return photos;
            }

            return photos;
        }
    }
}